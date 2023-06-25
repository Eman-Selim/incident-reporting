using Incident_Reporting_App_Server.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Incident_Reporting_App_Server.localhost;
using SDS_Remote_Control_Application_Server.Code;
using System.Threading;

namespace Incident_Reporting_App_Server
{
    public partial class Form2 : Form
    {
       // static string userName, passWord;
        int menu_Selected_Index = 0;
        ServerClass server_Class_Obj = new ServerClass();
        Incident_WS IncidentReporting_WS_Obj = new Incident_WS();
        byte[] imagenu = null;
        Users[] User;
        Company[] companies;
        Buildings[] buildings;
        int Selected_User_ID=1;
        int Selected_Company_ID=1;
        public Form2()
        {
            InitializeComponent();
            pictureBox5.MouseWheel += PictureBox5_MouseWheel;
            
            //load acounts treeview
            User = server_Class_Obj.Select_Account();
            
            int User_length = User != null ? User.Length : 0;
            if (User_length != 0)
            {
                treeView3.BeginUpdate();
                for (int i = 0; i < User_length; i++)
                {
                    TreeNode user_node = new TreeNode();
                    user_node.Text = User[i].Username;
                    user_node.Tag = User[i].UserID;
                    treeView3.Nodes[0].Nodes.Add(user_node);
                    companies = server_Class_Obj.Select_Companies(User[i].UserID);
                    int Companies_length = companies != null ? companies.Length : 0;
                    if (Companies_length != 0)
                    {
                        for (int j = 0; j < Companies_length; j++)
                        {
                            TreeNode company_node = new TreeNode();
                            company_node.Text = companies[j].Name;
                            company_node.Tag = companies[j];
                            treeView3.Nodes[0].Nodes[i].Nodes.Add(company_node);
                        }
                    }
                }
                treeView3.EndUpdate();
            }
            else
            {
                treeView3.Nodes.Clear();
                return;
            }
            //load selected company Data


            Company selectedCompany = server_Class_Obj.Select_Company(Selected_Company_ID);
            companyName.Text = selectedCompany.Name;
            govern.Text = selectedCompany.Address;
            address.Text = selectedCompany.Address;
            landlinePhone.Text = selectedCompany.LandlinePhoneNumber;
            BuildingsNumber.Text = Convert.ToString( selectedCompany.BuildingsNumber);
            ElectricalPanelLocation.Text = selectedCompany.ElectricalPanelLocation;
            GasTrapLocation.Text = selectedCompany.GasTrapLocation;
            OxygenTrapLocation.Text = selectedCompany.OxygenTrapLocation;


            //load buildings of selected company


            buildings = server_Class_Obj.Select_Buildings(Selected_Company_ID);
            int buildings_length = buildings != null ? buildings.Length : 0;
            for (int i = 0; i < buildings_length; i++)
            {
                buildingCB.Items.Add(buildings[i].BuildingNumber);
            }
            

            Thread Main_Thread = new Thread(load_all_treeviews_cycle);
            Main_Thread.Start();
        }
        
        #region treeview
        public delegate void load_trv_delegate();

        public void load_all_treeviews_cycle()
        {
            try
            {
                while (true)
                {
                    //companies = server_Class_Obj.Select_Companies();
                    load_trv_User_Tab();
                    Thread.Sleep(20000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Auditing.Error(ex.Message);
            }
        }
        /// <summary>
        /// load the Cities from the Array Cities and Display them on the treeview and load the combo box City name with the current Cities 
        /// </summary>
        public void load_trv_User_Tab()
       {
            try
            {
                if (treeView3.InvokeRequired)
                {
                    treeView3.Invoke(new load_trv_delegate(load_trv_User_Tab));
                }
                else
                {
                    treeView3.BeginUpdate();
                    int User_length = User != null ? User.Length : 0;
                    if (User_length != 0)
                    {
                        for (int i = 0; i < User_length; i++)
                        {
                            bool Find_Flag = false;
                            for (int j = 0; j < treeView3.Nodes[0].Nodes.Count; j++)
                            {
                                treeView3.Nodes[0].Nodes[j].Tag = User[i].UserID;
                                treeView3.Nodes[0].Nodes[j].Text = User[i].Username;
                                break;
                            }
                        }
                        for (int i = 0; i < User_length; i++)
                        {
                            companies = server_Class_Obj.Select_Companies(User[i].UserID);
                            int Companies_length = companies != null ? companies.Length : 0;
                            if (Companies_length != 0)
                            {
                                for (int j = 0; j < Companies_length; j++)
                                {
                                    treeView3.Nodes[0].Nodes[i].Nodes[j].Tag = companies[j].CompanyID;
                                    treeView3.Nodes[0].Nodes[i].Nodes[j].Text = companies[j].Name;
                                }
                            }
                        }
                        treeView3.EndUpdate();
                    }
                    else
                    {
                        treeView3.Nodes.Clear();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
            }
        }
        #endregion
        private void PictureBox5_MouseWheel(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Delta == 120)
            {
                menu_Selected_Index++;
                if (menu_Selected_Index >= 4)
                {
                    menu_Selected_Index = 0;
                }
            }
            else
            {
                menu_Selected_Index--;
                if (menu_Selected_Index <= -1)
                {
                    menu_Selected_Index = 3;
                }
            }


            switch (menu_Selected_Index)
            {
                case 0:
                    panel3.BackgroundImage = Properties.Resources.menu_item_5;
                    pictureBox5.BackgroundImage = Properties.Resources.BuildingSH1_MainForm;
                    c1DockingTab1.SelectedTab = c1DockingTabPage1;
                    break;

                case 1:
                    panel3.BackgroundImage = Properties.Resources.menu_item_4;
                    pictureBox5.BackgroundImage = Properties.Resources.Fire_FighterSH1_MainForm2;
                    c1DockingTab1.SelectedTab = c1DockingTabPage9;
                    break;

                case 2:
                    panel3.BackgroundImage = Properties.Resources.menu_item_5;
                    pictureBox5.BackgroundImage = Properties.Resources.UsersSH1_MainForm;
                    c1DockingTab1.SelectedTab = c1DockingTabPage11;
                    break;

                case 3:
                    panel3.BackgroundImage = Properties.Resources.menu_item_4;
                    pictureBox5.BackgroundImage = Properties.Resources.Phone_BookSH1_MainForm;
                    c1DockingTab1.SelectedTab = c1DockingTabPage10;
                    break;
            }
        }

        private void c1DockingTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void c1DockingTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

       

        private void EditAccount_Click(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Add_FFstations_FFpump_Click(object sender, EventArgs e)
        {
            try
            {
                FFstations station = new FFstations();
                station.CarsNumber = CarsNumber.Text;
                station.SoliderNumber = SoliderNumber.Text;
                station.Sector = sector.Text;
                station.Signs = signs.Text;
                station.Street = street.Text;
                station.ZoneNumber = zoneNumber.Text;
                station.Additional_info = Additional_info.Text;
                FF_pumps pump = new FF_pumps();
                pump.Additional_info = pumpInfo.Text;
                pump.Address = pumpAddress.Text;
                pump.Area = pumpArea.Text;
                pump.PumpNumber = PumpNumber.Text;
                pump.Status = Status.Text;
                pump.Signs = pumpSign.Text;
                pump.Sector = pumpSector.Text;
                pump.PumpType = PumpType.Text;
                server_Class_Obj.Add_FFstations_FFpump(station,pump);
                
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        private void DeleteCompany_Click(object sender, EventArgs e)
        {
            server_Class_Obj.Delete_Company(companyName.Text);
        }

        private void RemoveAccount_Click(object sender, EventArgs e)
        {
            try
            {
                server_Class_Obj.Delete_Account(accountName.Text);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        private void Edit_FFstations_FFpump_Click(object sender, EventArgs e)
        {

        }

        private void Delete_FFstations_FFpump_Click(object sender, EventArgs e)
        {

        }

        private void EditCompany_Click(object sender, EventArgs e)
        {

        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void Add_Account_Click_1(object sender, EventArgs e)
        {
            try
            {
                Users user = new Users();
                user.Username = accountName.Text;
                user.AdminMode = "";
                user.Info = "fhgh";
                if (string.Compare(accountPassword.Text, ReAccountPassword.Text) == 0)
                {
                    user.Password = accountPassword.Text;
                }

                user.Info = AccountInfo.Text;
                server_Class_Obj.Add_Account(user);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        private void AddCompany_Click_1(object sender, EventArgs e)
        {
            try
            {
                Company company = new Company();
                company.Name = companyName.Text;
                company.Address = address.Text;
                company.LandlinePhoneNumber = landlinePhone.Text;
                company.BackCompanyBusiness = "";
                company.BuildingsNumber = Convert.ToInt32(BuildingsNumber.Text);
                company.ElectricalPanelLocation = ElectricalPanelLocation.Text;
                company.GasTrapLocation = GasTrapLocation.Text;
                company.OxygenTrapLocation = OxygenTrapLocation.Text;
                company.RightCompanyName = "";
                company.RightCompanyImageURL = "";
                company.RightCompanyImage = imagenu;
                company.RightCompanyBusiness = "";
                company.LeftCompanyBusiness = "";
                company.LeftCompanyImage = imagenu;
                company.LeftCompanyImageURL = "";
                company.LeftCompanyName = "";
                company.BackCompanyBusiness = "";
                company.BackCompanyImage = imagenu;
                company.BackCompanyImageURL = "";
                company.BackCompanyName = "";
                company.FrontCompanyBusiness = "";
                company.FrontCompanyImage = imagenu;
                company.FrontCompanyImageURL = "";
                company.FrontCompanyName = "";
                company.Longitude = 0;
                company.Latitude = 0;
                company.UserID = 1;

                DangerousPlaces place = new DangerousPlaces();
                place.Location = DangerouseLocation.Text;
                place.HazardousSubstance = HazardousSubstance.Text;
                place.FireMediator = FireMediator.Text;
                place.Image = imagenu;
                place.ImageURL = "";

                Floors floor = new Floors();
                floor.FloorNumber = (string)dataGridView1.CurrentRow.Cells[0].Value;
                floor.FireHydrantsNumber = (string)dataGridView1.CurrentRow.Cells[1].Value;
                floor.PowderExtinguishersNumber = (string)dataGridView1.CurrentRow.Cells[2].Value;
                floor.PowderExtinguishersWeight = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);
                floor.CarbonDioxideExtinguishersNumbers = (string)dataGridView1.CurrentRow.Cells[4].Value;
                floor.CarbonDioxideExtinguishersWeight = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);
                floor.FoamExtinguishersNumbers = (string)dataGridView1.CurrentRow.Cells[6].Value;
                floor.FoamExtinguishersWeight = Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value);

                server_Class_Obj.Add_Company(company, place, floor);

                //for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
                //{
                //    for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                //    {
                //        string value = dataGridView1.Rows[rows].Cells[col].Value.ToString();

                //    }
                //}
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        private void treeView3_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            Selected_Company_ID = Convert.ToInt32(e.Node.Tag);
            Selected_User_ID = Convert.ToInt32(e.Node.Parent.Tag);

        }

        private void buildingCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void companyName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
