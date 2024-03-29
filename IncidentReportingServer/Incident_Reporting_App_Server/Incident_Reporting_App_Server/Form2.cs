﻿using Incident_Reporting_App_Server.Code;
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
using System.IO;

namespace Incident_Reporting_App_Server
{
    public partial class Form2 : Form
    {
        int menu_Selected_Index = 0;
        ServerClass server_Class_Obj = new ServerClass();
        Incident_WS IncidentReporting_WS_Obj = new Incident_WS();
        byte[] imagenu = null;
        Users U1;
        Users[] User;
        Users[] UsersOfUser;
        Company[] companies;
        Buildings[] buildings;
        Managers[] admins;
        DangerousPlaces[] places;
        FFstations[] points;
        FFstations station;
        FF_ManPower men;
        int Selected_User_ID;
        public Form2()
        {
            InitializeComponent();
            pictureBox5.MouseWheel += PictureBox5_MouseWheel;
            
            //load acounts treeview
            User = server_Class_Obj.Select_Users_of_Users();
            
            int User_length = User != null ? User.Length : 0;
            if (User_length != 0)
            {
                treeView3.BeginUpdate();
                for (int i = 0; i < User_length; i++)
                {
                    TreeNode user_node = new TreeNode();
                    user_node.Text = User[i].Username==null?"": User[i].Username;
                    user_node.Tag = User[i].UserID;
                    user_node.Name = "User";

                    treeView3.Nodes[0].Nodes.Add(user_node);

                    companies = User[i].User_Companies;

                    int Companies_length = companies != null ? companies.Length : 0;
                    if (Companies_length != 0)
                    {
                        for (int j = 0; j < Companies_length; j++)
                        {
                            TreeNode company_node = new TreeNode();
                            company_node.Text = companies[j].Name==null?"": companies[j].Name;
                            company_node.Tag = companies[j];
                            company_node.Name = "Company";

                            treeView3.Nodes[0].Nodes[i].Nodes.Add(company_node);
                            
                        }

                        Users[] UsersOfUser = server_Class_Obj.Select_Users_of_User(User[i].Username, User[i].Password, User[i].UserID);
                        int UsersOfUser_length = UsersOfUser != null ? UsersOfUser.Length : 0;
                        
                        for (int k = 0; k < UsersOfUser_length; k++)
                        {
                            TreeNode userOfUser_node = new TreeNode();
                            userOfUser_node.Text = UsersOfUser[k].Username==null?"": UsersOfUser[k].Username;
                            userOfUser_node.Tag = UsersOfUser[k].UserID;
                            userOfUser_node.Name = "User";
                            treeView3.Nodes[0].Nodes[i].Nodes.Add(userOfUser_node);
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
           

            Thread Main_Thread = new Thread(load_all_treeviews_cycle);
            Main_Thread.Start();
        }

        #region load_Data
        private void Load_Data(int Selected_User_ID , int Selected_Company_ID )
        {

            //load account info

             U1 = server_Class_Obj.Select_User(Selected_User_ID);
            accountName.Text = U1.Username==null?"": U1.Username;
            AccountInfo.Text = U1.Info==null?"": U1.Info;
            accountPassword.Clear();
            ReAccountPassword.Clear();
            for (int i = 0; i < U1.Password.Length; i++)
            {
                accountPassword.Text += "*";
                ReAccountPassword.Text += "*";
            }

            //load selected company Data


            Company selectedCompany = server_Class_Obj.Select_Company(Selected_Company_ID);
            companyName.Text = selectedCompany.Name==null?"": selectedCompany.Name;
            govern.Text = selectedCompany.Address==null?"": selectedCompany.Address;
            address.Text = selectedCompany.Address==null?"": selectedCompany.Address;
            landlinePhone.Text = selectedCompany.LandlinePhoneNumber==null?"": selectedCompany.LandlinePhoneNumber;
            BuildingsNumber.Text = Convert.ToString(selectedCompany.BuildingsNumber)==null?"": Convert.ToString(selectedCompany.BuildingsNumber);
            ElectricalPanelLocation.Text = selectedCompany.ElectricalPanelLocation==null?"": selectedCompany.ElectricalPanelLocation;
            GasTrapLocation.Text = selectedCompany.GasTrapLocation==null?"": selectedCompany.GasTrapLocation;
            OxygenTrapLocation.Text = selectedCompany.OxygenTrapLocation==null?"": selectedCompany.OxygenTrapLocation;
            c1PictureBox1.Image = selectedCompany.RightCompanyImage==null? Image.FromStream(new System.IO.MemoryStream(imagenu)): Image.FromStream(new System.IO.MemoryStream(selectedCompany.RightCompanyImage));



            //Loading the neighboring companies

            PictureBox P1 = new PictureBox();
            P1.Image= Image.FromStream(new System.IO.MemoryStream(selectedCompany.BackCompanyImage));


            //load buildings of selected company


            buildings = selectedCompany.companyBuildings;
            int buildings_length = buildings != null ? buildings.Length : 0;
            buildingCB.Items.Clear();
            for (int i = 0; i < buildings_length; i++)
            {
                buildingCB.Items.Add(buildings[i].BuildingNumber);
            }

            //load admins of the selected company
            Managers[] managers = selectedCompany.companyManagers;
            int managers_length = managers != null ? managers.Length : 0;
            Managers.Items.Clear();
            for (int i = 0; i < managers_length; i++)
            {
                Managers.Items.Add(managers[i].Name);
            }

            //load Dangerous places of the selected company

            places = selectedCompany.CompanyDangerousPlaces;
            int places_length = places != null ? places.Length : 0;
            Dangerous.Items.Clear();
            for (int i = 0; i < places_length; i++)
            {
                Dangerous.Items.Add(places[i].Location);
            }

            //load points 

            points = U1.User_FFstations;
            int points_length = points != null ? points.Length : 0;
            comboBox11.Items.Clear();
            for (int i = 0; i < points_length; i++)
            {
                comboBox11.Items.Add(points[i].FF_ID);
            }
            

        }

        
        #endregion

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
        /// update the users-Company treeview 
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
                            for (int j = 0; j < treeView3.Nodes[0].Nodes.Count; j++)
                            {
                                treeView3.Nodes[0].Nodes[j].Tag = User[i].UserID;
                                treeView3.Nodes[0].Nodes[j].Text = User[i].Username==null?"": User[i].Username;
                                treeView3.Nodes[0].Nodes[j].Name = "User";
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
                                    treeView3.Nodes[0].Nodes[i].Nodes[j].Text = companies[j].Name==null?"": companies[j].Name;
                                    treeView3.Nodes[0].Nodes[i].Nodes[j].Name = "Company";
                                }
                                
                                UsersOfUser = server_Class_Obj.Select_Users_of_User(User[i].Username, User[i].Password, User[i].UserID);
                                int UsersOfUser_length = UsersOfUser != null ? UsersOfUser.Length : 0;
                                for (int k = 0; k < UsersOfUser_length; k++)
                                {
                                    treeView3.Nodes[0].Nodes[i].Nodes[k+Companies_length].Tag = UsersOfUser[k].UserID;
                                    treeView3.Nodes[0].Nodes[i].Nodes[k+Companies_length].Text = UsersOfUser[k].Username==null?"": UsersOfUser[k].Username;
                                    treeView3.Nodes[0].Nodes[i].Nodes[k + Companies_length].Name = "User";
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

                case 3:
                    panel3.BackgroundImage = Properties.Resources.menu_item_4;
                    pictureBox5.BackgroundImage = Properties.Resources.Phone_BookSH1_MainForm;
                    c1DockingTab1.SelectedTab = c1DockingTabPage10;
                    break;
            }
        }

        private void Add_FFstations_FFpump_Click(object sender, EventArgs e)
        {
            try
            {
               
                FFstations temp = new FFstations();
                temp.CarsNumber = CarsNumber.Text;
                temp.SoliderNumber = SoliderNumber.Text;
                temp.Sector = sector.Text;
                temp.Signs = signs.Text;
                temp.Street = street.Text;
                temp.ZoneNumber = area.Text;
                temp.Additional_info = Additional_info.Text;
                temp.UserID = Selected_User_ID;
                men = new FF_ManPower();
                men.OfficerName = (string)ff_ManPowerGrid.CurrentRow.Cells[0].Value;
                men.Sector = (string)ff_ManPowerGrid.CurrentRow.Cells[1].Value;
                men.Area = (string)ff_ManPowerGrid.CurrentRow.Cells[2].Value;
                men.Rank = (string)ff_ManPowerGrid.CurrentRow.Cells[3].Value;
                men.Job = (string)ff_ManPowerGrid.CurrentRow.Cells[4].Value;
                men.Additional_info = (string)ff_ManPowerGrid.CurrentRow.Cells[5].Value;

                FF_ManPower[] manpower = temp.Station_ManPower;
               
                Array.Resize(ref manpower, manpower.Length + 1);
                manpower[manpower.GetUpperBound(0)] = men;
                temp.Station_ManPower = manpower;
                server_Class_Obj.Add_FFstations_FF_ManPower(temp);
                //FF_pumps pump = new FF_pumps();
                //pump.Additional_info = pumpInfo.Text;
                //pump.Address = pumpAddress.Text;
                //pump.Area = pumpArea.Text;
                //pump.PumpNumber = PumpNumber.Text;
                //pump.Status = Status.Text;
                //pump.Signs = pumpSign.Text;
                //pump.Sector = pumpSector.Text;
                //pump.PumpType = PumpType.Text;

                //server_Class_Obj.Add_FFstations_FFpump(station, men);

            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
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

        

        private CFP Add_Edit_Company()
        {
            Company c1 = new Company();
            
            c1.Name = companyName.Text;
            c1.Address = address.Text;
            c1.LandlinePhoneNumber = landlinePhone.Text;
            c1.BackCompanyBusiness = "";
            c1.BuildingsNumber = Convert.ToInt32(BuildingsNumber.Text);
            c1.ElectricalPanelLocation = ElectricalPanelLocation.Text;
            c1.GasTrapLocation = GasTrapLocation.Text;
            c1.OxygenTrapLocation = OxygenTrapLocation.Text;
            c1.RightCompanyName = "";
            c1.RightCompanyImageURL = "";
            c1.RightCompanyImage = imagenu;
            c1.RightCompanyBusiness = "";
            c1.LeftCompanyBusiness = "";
            c1.LeftCompanyImage = imagenu;
            c1.LeftCompanyImageURL = "";
            c1.LeftCompanyName = "";
            c1.BackCompanyBusiness = "";
            c1.BackCompanyImage = imagenu;
            c1.BackCompanyImageURL = "";
            c1.BackCompanyName = "";
            c1.FrontCompanyBusiness = "";
            c1.FrontCompanyImage = imagenu;
            c1.FrontCompanyImageURL = "";
            c1.FrontCompanyName = "";
            c1.Longitude = 0;
            c1.Latitude = 0;
            c1.UserID = 1;
            

            DangerousPlaces place = new DangerousPlaces();
            place.Location = DangerouseLocation.Text;
            place.HazardousSubstance = HazardousSubstance.Text;
            place.FireMediator = FireMediator.Text;
            place.Image = imagenu;
            place.ImageURL = "";
            Buildings building = new Buildings();
            building.
            c1.CompanyDangerousPlaces = places;
            c1.companyBuildings
            Floors floor = new Floors();
            floor.FloorNumber = (string)dataGridView1.CurrentRow.Cells[0].Value;
            floor.FireHydrantsNumber = (string)dataGridView1.CurrentRow.Cells[1].Value;
            floor.PowderExtinguishersNumber = (string)dataGridView1.CurrentRow.Cells[2].Value;
            floor.PowderExtinguishersWeight = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);
            floor.CarbonDioxideExtinguishersNumbers = (string)dataGridView1.CurrentRow.Cells[4].Value;
            floor.CarbonDioxideExtinguishersWeight = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);
            floor.FoamExtinguishersNumbers = (string)dataGridView1.CurrentRow.Cells[6].Value;
            floor.FoamExtinguishersWeight = Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value);

            CFPe.company = c1;
            CFPe.floor = floor;
            CFPe.place = place;
            return CFPe;
        }

        private void AddCompany_Click_1(object sender, EventArgs e)
        {
            try
            {
                CFP C1 = Add_Edit_Company();

                server_Class_Obj.Add_Company(C1.company, C1.place, C1.floor);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        private void treeView3_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name == "Company")
            {
                int Selected_Company_ID = Convert.ToInt32(e.Node.Tag);
                 Selected_User_ID = Convert.ToInt32(e.Node.Parent.Tag);
                Load_Data(Selected_User_ID, Selected_Company_ID);
            }
            else if (e.Node.Name == "User")
            {
                 Selected_User_ID = Convert.ToInt32(e.Node.Tag);
                Users U1 = server_Class_Obj.Select_User(Selected_User_ID);
                accountName.Text = U1.Username==null?"": U1.Username;
                AccountInfo.Text = U1.Info;
                accountPassword.Clear();
                ReAccountPassword.Clear();
                for (int i=0;i<U1.Password.Length;i++)
                {
                    accountPassword.Text += "*";
                    ReAccountPassword.Text += "*";
                }
            }
        }

        private void buildingCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            if (buildings.Length >= selectedIndex)
            {
                int buildingID = buildings[selectedIndex].BuildingID;
                Floors[] floor = server_Class_Obj.Select_Floors(buildingID);
                int floor_length = floor != null ? floor.Length : 0;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < floor_length; i++)
                {
                    string[] row = new string[] { floor[i].FloorNumber, floor[i].FireHydrantsNumber, floor[i].PowderExtinguishersNumber,
                    Convert.ToString(floor[i].PowderExtinguishersWeight),
                    floor[i].CarbonDioxideExtinguishersNumbers,
                    Convert.ToString(floor[i].CarbonDioxideExtinguishersWeight),
                    floor[0].PowderExtinguishersNumber,
                    Convert.ToString(floor[0].PowderExtinguishersWeight)};

                    dataGridView1.Rows.Add(row);
                }
                Images[] img = server_Class_Obj.Select_Images(buildingID);
                int img_length = img != null ? img.Length : 0;
                if (img_length > 0)
                {
                    c1PictureBox1.Image = Image.FromStream(new System.IO.MemoryStream(img[0].Image));
                    if (img_length > 1)
                    {
                        c1PictureBox2.Image = Image.FromStream(new System.IO.MemoryStream(img[1].Image));
                        if(img_length>2)
                        c1PictureBox3.Image = Image.FromStream(new System.IO.MemoryStream(img[2].Image));
                    }
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            int Managerid = admins[selectedIndex].ManagerID;
            Managers Manager = server_Class_Obj.Select_Manager(Managerid);
            SelectedUserName.Text = Manager.Name==null?"": Manager.Name;
            richTextBox41.Text = Manager.CurrentPosition==null?"": Manager.CurrentPosition;
            richTextBox40.Text = Manager.PhoneNumber==null?"": Manager.PhoneNumber;
            SelectedUserInfo.Text = Manager.Info==null?"": Manager.Info;
        }

        private void Dangerous_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            int placesid = places[selectedIndex].DangerousPlaceID;
            DangerousPlaces place = server_Class_Obj.Select_DangerousePlace(placesid);
            HazardousSubstance.Text = place.HazardousSubstance==null?"": place.HazardousSubstance;
            DangerouseLocation.Text = place.Location==null?"": place.Location;
            FireMediator.Text = place.FireMediator==null?"": place.FireMediator;
        }

        private void DeleteCompany_Click_1(object sender, EventArgs e)
        {
            server_Class_Obj.Delete_Company(companyName.Text);
        }

        private void RemoveAccount_Click_1(object sender, EventArgs e)
        {
            server_Class_Obj.Delete_Account(accountName.Text);
        }


        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            int FF_ManPowerID = points[selectedIndex].FF_ManPowerID;
            FF_ManPower point = server_Class_Obj.Select_point(FF_ManPowerID);
            pointNumber.Text = point.Point;
            sector.Text = point.Sector;
            comboBox18.Text= point.Sector;
            pumpSector.Text= point.Sector;

            point_number.Text= point.Point;
            richTextBox37.Text = point.OfficerName;
            richTextBox35.Text=point.Rank;
            richTextBox33.Text = point.Additional_info;
            richTextBox34.Text = point.Area;
            area.Text= point.Area;
        }

        private void EditCompany_Click_1(object sender, EventArgs e)
        {
            CFP C1 = Add_Edit_Company();

            server_Class_Obj.Update_Company(C1.company);
            server_Class_Obj.Update_Floor(C1.floor);
            server_Class_Obj.Update_DangerousePlaces(C1.place);
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            station.CarsNumber = CarsNumber.Text;
            station.SoliderNumber = SoliderNumber.Text;
            station.Sector = sector.Text;
            station.Signs = signs.Text;
            station.Street = street.Text;
            station.ZoneNumber = area.Text;
            station.Additional_info = Additional_info.Text;
            station.UserID = Selected_User_ID;
            men = new FF_ManPower();
            men.OfficerName = (string)ff_ManPowerGrid.CurrentRow.Cells[0].Value;
            men.Sector = (string)ff_ManPowerGrid.CurrentRow.Cells[1].Value;
            men.Area = (string)ff_ManPowerGrid.CurrentRow.Cells[2].Value;
            men.Rank = (string)ff_ManPowerGrid.CurrentRow.Cells[3].Value;
            men.Job = (string)ff_ManPowerGrid.CurrentRow.Cells[4].Value;
            men.Additional_info = (string)ff_ManPowerGrid.CurrentRow.Cells[5].Value;

            FF_ManPower[] manpower = station.Station_ManPower;
            Array.Resize(ref manpower, manpower.Length + 1);
            manpower[manpower.GetUpperBound(0)] = men;
            station.Station_ManPower = manpower;
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            server_Class_Obj.Add_FFstations_FF_ManPower(station);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FF_pumps pump = new FF_pumps();
            pump.Additional_info = pumpInfo.Text;
            pump.Address = pumpAddress.Text;
            pump.Area = pumpArea.Text;
            pump.PumpNumber = PumpNumber.Text;
            pump.Status = Status.Text;
            pump.Signs = pumpSign.Text;
            pump.Sector = pumpSector.Text;
            pump.PumpType = PumpType.Text;
            pump.UserID = Selected_User_ID;
            server_Class_Obj.Add_FFPump(pump);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PumpNumber.Text = "";
            pumpArea.Text = "";
            pumpSector.Text = "";
            PumpType.Text = "";
            Status.Text = "";
            pumpAddress.Text = "";
            pumpSign.Text = "";
            pumpInfo.Text = "";
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PumpNumber.Text= (string)dataGridView3.CurrentRow.Cells[0].Value;
            pumpArea.Text = (string)dataGridView3.CurrentRow.Cells[1].Value;
            pumpSector.Text= (string)dataGridView3.CurrentRow.Cells[2].Value;
            PumpType.Text= (string)dataGridView3.CurrentRow.Cells[3].Value;
            Status.Text = (string)dataGridView3.CurrentRow.Cells[4].Value;
            pumpAddress.Text= (string)dataGridView3.CurrentRow.Cells[5].Value;
            pumpSign.Text = (string)dataGridView3.CurrentRow.Cells[6].Value;
            pumpInfo.Text = (string)dataGridView3.CurrentRow.Cells[7].Value;

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }

    internal class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
    }
}
