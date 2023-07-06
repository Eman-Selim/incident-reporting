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
        public static string UserName { get; set; }
        public static string Password { get; set; }
        #endregion
        #region Connect
        //public ServerClass(string userName, string passWord)
        //{
        //    UserName = userName;
        //    Password = passWord;
        //}
        /// <summary>
        /// Intializes the connectivty variables then starts the authentication thread
        /// </summary>
        /// <param name="userName">Contains the Super admin user name</param>
        /// <param name="passWord">Contains the Super admin Password</param>
        public void Start_Server(string userName, string passWord)
        {
            try
            {
                UserName = userName;
                Password = passWord;
                if (IncidentReporting_WS_Obj.Users_Select_All(UserName, Password)!=null)
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

        public Users[] Select_Account()
        {
            try
            {
               return IncidentReporting_WS_Obj.Users_Select_All(UserName, Password);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public Users[] Select_Users_of_Users()
        {
            try
            {
                Users user = IncidentReporting_WS_Obj.Users_SelectByName(UserName, Password, UserName);
                return IncidentReporting_WS_Obj.Users_Select_Users_Of_User(UserName, Password,user.UserID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public Users[] Select_Users_of_User(string username,string password,int UserId)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Select_Users_Of_User(username, password, UserId);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public Users Select_User(string username, string password, int UserId)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_SelectByUserId(username, password, UserId);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public Company[] Select_Companies(int userID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_UserID(UserName, Password, userID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public FF_ManPower[] Select_points(int userID)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Select_By_UserID(UserName, Password, userID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public FF_ManPower Select_point(int FF_ManPowerID)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Select_By_FF_ManPowerID(UserName, Password, FF_ManPowerID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public Images[] Select_Images(int BuildingID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Images_Select_By_BuildingID(UserName, Password, BuildingID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public Company Select_Company(int CompanyID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_CompanyID(UserName, Password, CompanyID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public Company Update_Company(Company company)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Update(UserName, Password, company);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public Users[] Select_Admins(int CompanyID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_SelectByCompanyId(UserName, Password, CompanyID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public DangerousPlaces[] Select_DangerousePlaces(int CompanyID)
        {
            try
            {
                return IncidentReporting_WS_Obj.DangerousPlaces_Select_By_CompanyID(UserName, Password, CompanyID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public DangerousPlaces Select_DangerousePlace(int placeID)
        {
            try
            {
                return IncidentReporting_WS_Obj.DangerousPlaces_Select_By_ID(UserName, Password, placeID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public Buildings[] Select_Buildings(int companyID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Buildings_Select_By_CompanyID(UserName, Password, companyID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public Buildings Select_Building(int BuildingID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Buildings_Select_By_BuildingID(UserName, Password, BuildingID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public Floors[] Select_Floors(int BuildingID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Select_By_BuildingID(UserName, Password, BuildingID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public Users Select_User(int UserID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_SelectByUserId(UserName, Password, UserID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public void Add_Account(Users user)
        {
            try
            {
                IncidentReporting_WS_Obj.Users_Insert(UserName, Password, user);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        public void Delete_Account(string Name)
        {
            try
            {
                Users user=IncidentReporting_WS_Obj.Users_SelectByName(UserName, Password, Name);
                IncidentReporting_WS_Obj.Users_Delete(UserName, Password, user.UserID);
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
                IncidentReporting_WS_Obj.Company_Insert(UserName, Password, company);
                IncidentReporting_WS_Obj.DangerousPlaces_Insert(UserName, Password, place);
                IncidentReporting_WS_Obj.Floors_Insert(UserName, Password, floor);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }
        public void Delete_Company(string Name)
        {
            try
            {
                Company[] companies = IncidentReporting_WS_Obj.Company_Select_By_Name(UserName, Password, Name);
                IncidentReporting_WS_Obj.Company_Delete(UserName, Password, companies[0].CompanyID);
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
                IncidentReporting_WS_Obj.FFstations_Insert(UserName, Password, station);
                IncidentReporting_WS_Obj.FF_pumps_Insert(UserName, Password, pump);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }
       
        #endregion
    }
}