using SDS_Remote_Control_Application_Server.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Incident_Reporting_App_Server.localhost;

namespace Incident_Reporting_App_Server.Code
{
    class ServerClass
    {
        public delegate void del_Update_Log(string text);
        public event del_Update_Log log_Handler;
        Incident_WS IncidentReporting_WS_Obj = new Incident_WS();

        #region Login Info
        public string UserName { get; set; }
        public string Password { get; set; }
        #endregion

        #region Connect

        /// <summary>
        /// Intializes the connectivty variables then starts the authentication thread
        /// </summary>
        /// <param name="userName">Contains the Super admin user name</param>
        /// <param name="passWord">Contains the Super admin Password</param>
        public void Start_Server(string userName, string passWord)
        {
            try
            {
                this.UserName = userName;
                this.Password = passWord;
                if (IncidentReporting_WS_Obj.Users_Admin_Select_All(UserName, Password)!=null)
                {
                    Form2 f2 = new Form2();
                    f2.Show();
                }
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        public void Add_Account(Users user)
        {
            try
            {
                IncidentReporting_WS_Obj.Users_Insert(this.UserName, this.Password, user);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        public void Add_Company(Company company, DangerousPlaces place, Floors floor)
        {
            try
            {
                IncidentReporting_WS_Obj.Company_Insert(this.UserName, this.Password, company);
                IncidentReporting_WS_Obj.DangerousPlaces_Insert(this.UserName, this.Password, place);
                IncidentReporting_WS_Obj.Floors_Insert(this.UserName, this.Password, floor);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }
        
        public void Add_FFstations_FFpump(FFstations station,FF_pumps pump)
        {
            try
            {
                IncidentReporting_WS_Obj.FFstations_Insert(this.UserName, this.Password, station);
                IncidentReporting_WS_Obj.FF_pumps_Insert(this.UserName, this.Password, pump);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }
        #endregion
    }
}