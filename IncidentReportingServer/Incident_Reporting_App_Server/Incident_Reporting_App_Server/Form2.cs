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

namespace Incident_Reporting_App_Server
{
    public partial class Form2 : Form
    {
        int menu_Selected_Index = 0;
        ServerClass server_Class_Obj = new ServerClass();
        Incident_WS IncidentReporting_WS_Obj = new Incident_WS();

        public Form2()
        {
            InitializeComponent();
            pictureBox5.MouseWheel += PictureBox5_MouseWheel;
            TreeNode mainNode = new TreeNode();
            mainNode.Name = "mainNode";
            mainNode.Text = "Main";
            this.treeView1.Nodes.Add(mainNode);
        }
        #region Cities
            Users[] User;
        #endregion
        #region treeview
        public delegate void load_trv_delegate();

        /// <summary>
        /// load the Cities from the Array Cities and Display them on the treeview and load the combo box City name with the current Cities 
        /// </summary>
        public void load_trv_TETRACities_Cities_Tab()
        {
            try
            {
                if (treeView3.InvokeRequired)
                {
                    treeView3.Invoke(new load_trv_delegate(load_trv_TETRACities_Cities_Tab));
                }
                else
                {

                    #region Accounts
                    int User_length = User != null ? User.Length : 0;
                    #region Cities add, edit
                    if (User_length != 0)
                    {
                        treeView3.BeginUpdate();

                        for (int i = 0; i < User_length; i++)
                        {
                            bool Find_Flag = false;
                            for (int j = 0; j < treeView3.Nodes[0].Nodes.Count; j++)
                            {
                                Users selected_User = (Users)treeView3.Nodes[0].Nodes[j].Tag;
                                if (User[i].UserID == selected_User.UserID)
                                {
                                    //edit 
                                    Find_Flag = true;
                                    treeView3.Nodes[0].Nodes[j].Tag = User[i];
                                    treeView3.Nodes[0].Nodes[j].Text = User[i].Username;
                                    break;
                                }
                            }
                            if (Find_Flag == false)
                            {
                                //add
                                TreeNode new_User_node = new TreeNode();
                                new_User_node.Text = User[i].Username;
                                new_User_node.Tag = User[i];
                                treeView3.Nodes[0].Nodes.Add(new_User_node);
                            }
                        }
                        treeView3.EndUpdate();

                        load_comboBox_User_Names_in_Radios_Tab();

                    }
                    else
                    {
                        treeView3.Nodes[0].Nodes.Clear();

                        load_comboBox_City_Names_in_Radios_Tab();
                        return;

                    }
                    #endregion

                    #region User delete

                    if (User_length != 0 && treeView3.Nodes[0].Nodes.Count > 0)
                    {
                        treeView3.BeginUpdate();

                        for (int j = 0; j < treeView3.Nodes[0].Nodes.Count; j++)
                        { // delete operation
                            bool Find_Flag = false;
                            Users current_User_obj = (Users)treeView3.Nodes[0].Nodes[j].Tag;
                            for (int i = 0; i < User.Length; i++)
                            {
                                if (current_User_obj.UserID == User[i].UserID)
                                {
                                    Find_Flag = true;
                                    break;
                                }
                            }
                            if (Find_Flag == false)
                            {
                                //delete
                                treeView3.Nodes[0].Nodes[j].Remove();
                            }
                        }
                        treeView3.EndUpdate();
                    }
                    #endregion
                    #endregion

                    #region radios 

                    #region radios ADD
                    int radios_length = radios != null ? radios.Length : 0;

                    if (radios_length > 0)
                    {
                        for (int i = 0; i < radios_length; i++)
                        {
                            for (int j = 0; j < treeView3.Nodes[0].Nodes.Count; j++)
                            {
                                City checked_city = (City)treeView3.Nodes[0].Nodes[j].Tag;

                                if (checked_city.CityID == radios[i].CityID)
                                {
                                    bool radios_detected = false;
                                    // if the radio belong to this site in db
                                    for (int loop = 0; loop < treeView3.Nodes[0].Nodes[j].Nodes.Count; loop++)
                                    {
                                        Radios current_Radio_Obj = (Radios)treeView3.Nodes[0].Nodes[j].Nodes[loop].Tag;

                                        if (current_Radio_Obj.Radio_ID == radios[i].Radio_ID)
                                        {// if the site is already a subnode of its site node

                                            treeView3.Nodes[0].Nodes[j].Nodes[loop].Text = radios[i].Radio_Name;
                                            radios_detected = true;
                                            break;
                                        }
                                    }

                                    if (radios_detected == false)
                                    {
                                        // add the site as a subnode to that zone
                                        TreeNode radio_subnode = new TreeNode();
                                        radio_subnode.Text = radios[i].Radio_Name;
                                        radio_subnode.Tag = radios[i];
                                        treeView3.Nodes[0].Nodes[j].Nodes.Add(radio_subnode);
                                    }
                                    break;
                                }

                            }
                        }
                    }
                    #endregion

                    #region radios Delete
                    if (radios.Length > 0)
                    {
                        for (int j = 0; j < treeView3.Nodes[0].Nodes.Count; j++)
                        {
                            City current_City_Obj = (City)treeView3.Nodes[0].Nodes[j].Tag;
                            for (int loop = 0; loop < treeView3.Nodes[0].Nodes[j].Nodes.Count; loop++)
                            {
                                bool radios_detected = false;
                                Radios Radio_obj = (Radios)treeView3.Nodes[0].Nodes[j].Nodes[loop].Tag;
                                //check if the subnode is in radios db   
                                for (int i = 0; i < radios_length; i++)
                                {
                                    if (Radio_obj.Radio_ID == radios[i].Radio_ID && radios[i].CityID == Radio_obj.CityID)
                                    {
                                        radios_detected = true;
                                        break;
                                    }
                                }
                                if (radios_detected == false)
                                {
                                    //remove this subnode
                                    treeView3.Nodes[0].Nodes[j].Nodes.RemoveAt(loop);
                                }
                            }
                        }
                    }
                    #endregion
                    #endregion

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

        private void Add_Account_Click(object sender, EventArgs e)
        {
            try
            {
                Users user=new Users();
                user.Username = accountName.Text;
                if (string.Compare(accountPassword.Text, ReAccountPassword.Text)==0)
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

        private void EditAccount_Click(object sender, EventArgs e)
        {

        }

        private void AddCompany_Click(object sender, EventArgs e)
        {
            try
            {
                Company company= new Company();
                company.Name = companyName.Text;
                company.Address = address.Text;
                company.LandlinePhoneNumber = landlinePhone.Text;
                //company.BackCompanyBusiness =;
                company.BuildingsNumber = Convert.ToInt32( BuildingsNumber.Text);
                company.ElectricalPanelLocation = ElectricalPanelLocation.Text;
                company.GasTrapLocation = GasTrapLocation.Text;
                company.OxygenTrapLocation = OxygenTrapLocation.Text;

                DangerousPlaces place = new DangerousPlaces();
                place.Location = DangerouseLocation.Text;
                place.HazardousSubstance = HazardousSubstance.Text;
                place.FireMediator = FireMediator.Text;

                Floors floor = new Floors();
                floor.FloorNumber = (string)dataGridView1.CurrentRow.Cells[0].Value;
                floor.FireHydrantsNumber = (string)dataGridView1.CurrentRow.Cells[1].Value;
                floor.PowderExtinguishersNumber = (string)dataGridView1.CurrentRow.Cells[2].Value;
                floor.PowderExtinguishersWeight = (int)dataGridView1.CurrentRow.Cells[3].Value;
                floor.CarbonDioxideExtinguishersNumbers= (string)dataGridView1.CurrentRow.Cells[4].Value;
                floor.CarbonDioxideExtinguishersWeight = (int)dataGridView1.CurrentRow.Cells[5].Value;
                floor.FoamExtinguishersNumbers= (string)dataGridView1.CurrentRow.Cells[6].Value;
                floor.FoamExtinguishersWeight= (int)dataGridView1.CurrentRow.Cells[7].Value;

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

        }

        private void RemoveAccount_Click(object sender, EventArgs e)
        {

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
        
    }
}
