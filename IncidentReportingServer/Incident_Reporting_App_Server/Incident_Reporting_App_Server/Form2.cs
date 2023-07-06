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
using System.IO;

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
        Users[] UsersOfUser;
        Company[] companies;
        Buildings[] buildings;
        Users[] admins;
        DangerousPlaces[] places;
        FF_ManPower[] points;
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
                    user_node.Text = User[i].Username;
                    user_node.Tag = User[i].UserID;
                    user_node.Name = "User";

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
                            company_node.Name = "Company";

                            treeView3.Nodes[0].Nodes[i].Nodes.Add(company_node);
                            
                        }

                        Users[] UsersOfUser = server_Class_Obj.Select_Users_of_User(User[i].Username, User[i].Password, User[i].UserID);
                        int UsersOfUser_length = UsersOfUser != null ? UsersOfUser.Length : 0;
                        
                        for (int k = 0; k < UsersOfUser_length; k++)
                        {
                            TreeNode userOfUser_node = new TreeNode();
                            userOfUser_node.Text = UsersOfUser[k].Username;
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
            Users U1 = server_Class_Obj.Select_User(Selected_User_ID);
            accountName.Text = U1.Username;
            AccountInfo.Text = U1.Info;
            accountPassword.Text = "*******";
            //load selected company Data


            Company selectedCompany = server_Class_Obj.Select_Company(Selected_Company_ID);
            companyName.Text = selectedCompany.Name;
            govern.Text = selectedCompany.Address;
            address.Text = selectedCompany.Address;
            landlinePhone.Text = selectedCompany.LandlinePhoneNumber;
            BuildingsNumber.Text = Convert.ToString(selectedCompany.BuildingsNumber);
            ElectricalPanelLocation.Text = selectedCompany.ElectricalPanelLocation;
            GasTrapLocation.Text = selectedCompany.GasTrapLocation;
            OxygenTrapLocation.Text = selectedCompany.OxygenTrapLocation;
            c1PictureBox1.Image = Image.FromStream(new System.IO.MemoryStream(selectedCompany.RightCompanyImage));



            //Loading the neighboring companies

            DataTable Inbox_datatable = new DataTable("Inbox_Datatable");
            Inbox_datatable.Columns.Add("إتجاه المنشأة", typeof(string));
            Inbox_datatable.Columns.Add("إسم المنشأة", typeof(string));
            Inbox_datatable.Columns.Add("نشاط المنشأة", typeof(string));
            Inbox_datatable.Columns.Add("مصدر الخطورة بالمنشأة", typeof(string));
            Inbox_datatable.Columns.Add("الوسيط الإطفائي", typeof(string));
            Inbox_datatable.Columns.Add("صورة المنشأة", typeof(Image));

            MemoryStream ms = new MemoryStream();
            PictureBox P1 = new PictureBox();
            P1.Image= Image.FromStream(new System.IO.MemoryStream(selectedCompany.BackCompanyImage));
            //byte[] img = ms.ToArray();


            DataRow Back_Row = Inbox_datatable.NewRow();

            Back_Row[0] = "المنشأة المجاورة خلفي";
            Back_Row[1] = selectedCompany.BackCompanyName;
            Back_Row[2] = selectedCompany.BackCompanyBusiness;
            Back_Row[3] = selectedCompany.BackCompanyImageURL;
            Back_Row[4] = selectedCompany.BackFireMediator;
            Back_Row[5] = P1.Image;
            Inbox_datatable.Rows.Add(Back_Row);

            DataRow Front_Row = Inbox_datatable.NewRow();
            P1.Image = Image.FromStream(new System.IO.MemoryStream(selectedCompany.FrontCompanyImage));
            P1.BackgroundImage = Image.FromStream(new System.IO.MemoryStream(selectedCompany.FrontCompanyImage));
            P1.BackgroundImageLayout = ImageLayout.Center;

            Front_Row[0] = "المنشأة المجاورة أمامي";
            Front_Row[1] = selectedCompany.FrontCompanyName;
            Front_Row[2] = selectedCompany.FrontCompanyBusiness;
            Front_Row[3] = selectedCompany.FrontCompanyImageURL;
            Front_Row[4] = selectedCompany.FrontFireMediator;
            Front_Row[5] = P1.BackgroundImage;

            Inbox_datatable.Rows.Add(Front_Row);

            DataRow Right_Row = Inbox_datatable.NewRow();
            P1.Image = Image.FromStream(new System.IO.MemoryStream(selectedCompany.RightCompanyImage));

            Right_Row[0] = "المنشأة المجاورة يمين";
            Right_Row[1] = selectedCompany.RightCompanyName;
            Right_Row[2] = selectedCompany.RightCompanyBusiness;
            Right_Row[3] = selectedCompany.RightCompanyImageURL;
            Right_Row[4] = selectedCompany.RightFireMediator;
            Right_Row[5] = P1.Image;
            Inbox_datatable.Rows.Add(Right_Row);

            DataRow Left_Row = Inbox_datatable.NewRow();
            P1.Image = Image.FromStream(new System.IO.MemoryStream(selectedCompany.LeftCompanyImage));

            Left_Row[0] = "المنشأة المجاورة يسار";
            Left_Row[1] = selectedCompany.LeftCompanyName;
            Left_Row[2] = selectedCompany.LeftCompanyBusiness;
            Left_Row[3] = selectedCompany.LeftCompanyImageURL;
            Left_Row[4] = selectedCompany.LeftFireMediator;
            Left_Row[5] = P1.Image;
            Inbox_datatable.Rows.Add(Left_Row);

            dataGridView2.DataSource = Inbox_datatable;

           

            //load buildings of selected company


            buildings = server_Class_Obj.Select_Buildings(Selected_Company_ID);
            int buildings_length = buildings != null ? buildings.Length : 0;
            buildingCB.Items.Clear();
            for (int i = 0; i < buildings_length; i++)
            {
                buildingCB.Items.Add(buildings[i].BuildingNumber);
            }

            //load admins of the selected company
             admins = server_Class_Obj.Select_Admins(Selected_Company_ID);
            int admins_length = admins != null ? admins.Length : 0;
            Admins.Items.Clear();
            for (int i = 0; i < admins_length; i++)
            {
                Admins.Items.Add(admins[i].Username);
            }

            //load Dangerous places of the selected company

            places = server_Class_Obj.Select_DangerousePlaces(Selected_Company_ID);
            int places_length = places != null ? places.Length : 0;
            Dangerous.Items.Clear();
            for (int i = 0; i < places_length; i++)
            {
                Dangerous.Items.Add(places[i].Location);
            }

            //load points 

            points = server_Class_Obj.Select_points(Selected_User_ID);
            int points_length = points != null ? points.Length : 0;
            comboBox11.Items.Clear();
            for (int i = 0; i < points_length; i++)
            {
                comboBox11.Items.Add(points[i].Point);
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
                                    treeView3.Nodes[0].Nodes[i].Nodes[j].Text = companies[j].Name;
                                    treeView3.Nodes[0].Nodes[i].Nodes[j].Name = "Company";


                                }
                                
                                UsersOfUser = server_Class_Obj.Select_Users_of_User(User[i].Username, User[i].Password, User[i].UserID);
                                int UsersOfUser_length = UsersOfUser != null ? UsersOfUser.Length : 0;
                                for (int k = 0; k < UsersOfUser_length; k++)
                                {
                                    treeView3.Nodes[0].Nodes[i].Nodes[k+Companies_length].Tag = UsersOfUser[k].UserID;
                                    treeView3.Nodes[0].Nodes[i].Nodes[k+Companies_length].Text = UsersOfUser[k].Username;
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
            if (e.Node.Name == "Company")
            {
                int Selected_Company_ID = Convert.ToInt32(e.Node.Tag);
                int Selected_User_ID = Convert.ToInt32(e.Node.Parent.Tag);
                Load_Data(Selected_User_ID, Selected_Company_ID);
            }
            else if (e.Node.Name == "User")
            {
                int Selected_User_ID = Convert.ToInt32(e.Node.Tag);
                Users U1 = server_Class_Obj.Select_User(Selected_User_ID);
                Load_Data(Selected_User_ID,U1.CompanyID);
            }
           

        }

        private void buildingCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            if (buildings.Length >= selectedIndex)
            {
                int buildingID = buildings[selectedIndex].BuildingID;
                //Buildings building = server_Class_Obj.Select_Building(buildingID);
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

        private void companyName_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            int userid = admins[selectedIndex].UserID;
            Users user = server_Class_Obj.Select_User(userid);
            SelectedUserName.Text = user.Username;
            SelectedUserInfo.Text = user.Info;
        }

        private void Dangerous_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            int placesid = places[selectedIndex].DangerousPlaceID;
            DangerousPlaces place = server_Class_Obj.Select_DangerousePlace(placesid);
            HazardousSubstance.Text = place.HazardousSubstance;
            DangerouseLocation.Text = place.Location;
            FireMediator.Text = place.FireMediator;
        }

        private void DeleteCompany_Click_1(object sender, EventArgs e)
        {
            server_Class_Obj.Delete_Company(companyName.Text);
        }

        private void RemoveAccount_Click_1(object sender, EventArgs e)
        {
            server_Class_Obj.Delete_Account(accountName.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            int FF_ManPowerID = points[selectedIndex].FF_ManPowerID;
            FF_ManPower point = server_Class_Obj.Select_point(FF_ManPowerID);
            richTextBox20.Text = point.Point;
            sector.Text = point.Sector;
            richTextBox36.Text= point.Point;
            richTextBox37.Text = point.OfficerName;
            richTextBox35.Text=point.Rank;
            richTextBox33.Text = point.Additional_info;

        }
    }

    internal class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
    }
}
