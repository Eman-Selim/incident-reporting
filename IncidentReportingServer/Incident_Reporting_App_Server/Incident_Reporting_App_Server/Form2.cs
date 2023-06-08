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
        }
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

        private void button5_Click(object sender, EventArgs e)
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

        private void c1Button9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
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
                server_Class_Obj.Add_FFstations_FFpump(station,pump);
                
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }
    }
}
