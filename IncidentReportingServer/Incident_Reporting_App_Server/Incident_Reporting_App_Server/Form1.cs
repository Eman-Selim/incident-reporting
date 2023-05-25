﻿using Incident_Reporting_App_Server.Code;
using SDS_Remote_Control_Application_Server.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Incident_Reporting_App_Server
{
    public partial class Form1 : Form
    {
        ServerClass server_Class_Obj = new ServerClass();
        public Form1()
        {
            InitializeComponent();
            server_Class_Obj.log_Handler += log_Handler;
        }
        public delegate void txt_log_Update_Delegate(string text);
        public void log_Handler(string text)
        {
            try
            {
                if (true)
                {
                    txt_log_Update_Delegate method = new txt_log_Update_Delegate(this.log_Handler);
                   // this.txt_log.Invoke(method, new object[] { text });
                }
                else
                {
                    //this.txt_log.AppendText("- " + text + "\r\n");
                }
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }
        private void panel3_MouseHover(object sender, EventArgs e)
        {
            panel3.BackgroundImage = Properties.Resources.Fire_FighterSH1;

        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackgroundImage = Properties.Resources.Fire_FighterN1;

        }

        private void panel3_Click(object sender, EventArgs e)
        {
            //tableLayoutPanel2.BackgroundImage = Properties.Resources.Fire_Fighter_S_H;
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Properties.Resources.BuildingSH1;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Properties.Resources.BuildingN1;
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            panel5.BackgroundImage = Properties.Resources.Phone_BookSH1;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackgroundImage = Properties.Resources.Phone_BookN1;
        }

        private void panel4_MouseHover(object sender, EventArgs e)
        {
            panel4.BackgroundImage = Properties.Resources.UsersSH1;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackgroundImage = Properties.Resources.UsersN1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Login_txt_Username.Text == "" && Login_txt_Password.Text == "")
                {
                    log_Handler("check all required data");
                }
                else if ((Login_txt_Username.Text == "" || Login_txt_Password.Text == ""))
                {
                    if ((Login_txt_Username.Text == ""))
                        log_Handler("Please Enter your User name");
                    if ((Login_txt_Password.Text == ""))
                        log_Handler("Please Enter your Password");
                }
                else
                {
                    
                    server_Class_Obj.Start_Server(Login_txt_Username.Text, Login_txt_Password.Text);
                }
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        private void txt_log_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_txt_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_txt_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
