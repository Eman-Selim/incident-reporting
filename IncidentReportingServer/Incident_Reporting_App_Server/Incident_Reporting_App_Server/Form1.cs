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
        public Form1()
        {
            InitializeComponent();
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
    }
}
