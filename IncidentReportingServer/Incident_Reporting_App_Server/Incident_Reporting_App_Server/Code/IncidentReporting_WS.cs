using Incident_Reporting_App_Server.localhost;
using SDS_Remote_Control_Application_Server.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incident_Reporting_App_Server.Code
{
    class IncidentReporting_WS
    {
        IncidentReporting_WS IncidentReporting_WS_Obj = new IncidentReporting_WS();

        #region Users

        public bool Users_Delete(string username, string password, int user_id)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Delete(username, password,user_id);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public Users Users_Insert(string username, string password, Users Users)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Insert(username, password, Users);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Users[] Users_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Select_All(username,password);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Users Users_SelectByUserId(string username, string password, int UserId)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_SelectByUserId(username, password, UserId);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Users[] Users_Select_Super_Admin(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Select_Super_Admin(username,password);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        #endregion

        #region  Users_Admin
        public bool Users_Admin_Delete(string username, string password, int user_id, int Admin_id)
        {
            try 
            {
                return IncidentReporting_WS_Obj.Users_Admin_Delete(username,password,user_id,Admin_id);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public Users_Admin Users_Admin_Insert(string username, string password, Users_Admin Users_Admin)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Admin_Insert(username,password,Users_Admin);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Users_Admin[] Users_Admin_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Admin_Select_All(username, password);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Users_Admin Users_Admin_SelectByAdminId(string username, string password, int Admin_ID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Admin_SelectByAdminId(username, password, Admin_ID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;

            }
        }

        public Users_Admin Users_Admin_SelectByUserID(string username, string password, int User_ID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Admin_SelectByUserID(username, password, User_ID);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        #endregion
        #region InjuredSBL
        public bool Injured_Delete(string username, string password, int InjuredID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Delete(username, password, InjuredID);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public Injured Injured_Insert(string username, string password, Injured Injured)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Insert(username, password, Injured);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Injured[] Injured_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Select_All(username, password);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Injured[] Injured_Select_By_AccidentID(string username, string password, int AccidentID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Select_By_AccidentID(username,password, AccidentID);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Injured[] Injured_Select_By_Age(string username, string password, int Age)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Select_By_Age(username, password, Age);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Injured[] Injured_Select_By_Civil_Military(string username, string password, string Civil_Military)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Select_By_Civil_Military(username, password, Civil_Military);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Injured[] Injured_Select_By_Date(string username, string password, DateTime Date)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Select_By_Date(username, password, Date);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Injured Injured_Select_By_InjuredID(string username, string password, int InjuredID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Select_By_InjuredID(username, password, InjuredID);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Injured[] Injured_Select_By_Name(string username, string password, string Name)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Select_By_Name(username, password, Name);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Injured[] Injured_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Select_By_Rank(username, password, Rank);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        #endregion
        #region ImagesSBL
        public Images Images_Insert(string username, string password, Images Images)
        {
            try
            {
                return IncidentReporting_WS_Obj.Images_Insert(username, password, Images);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Images[] Images_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Images_Select_All(username, password);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Images[] Images_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Images_Select_By_BuildingID(username, password, BuildingID);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Images[] Images_Select_By_ImageDescription(string username, string password, string ImageDescription)
        {
            try
            {
                return IncidentReporting_WS_Obj.Images_Select_By_ImageDescription(username, password, ImageDescription);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        #endregion

        #region Floors
        public Floors Floors_Insert(string username, string password, Floors Floors)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Insert(username, password, Floors);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Floors[] Floors_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Select_All(username, password);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Floors[] Floors_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Select_By_BuildingID(username, password, BuildingID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Floors[] Floors_Select_By_CarbonDioxideExtinguishersNumbers(string username, string password, String CarbonDioxideExtinguishersNumbers)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Select_By_CarbonDioxideExtinguishersNumbers(username, password, CarbonDioxideExtinguishersNumbers);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Floors[] Floors_Select_By_PowderExtinguishersNumber(string username, string password, String PowderExtinguishersNumber)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Select_By_PowderExtinguishersNumber(username, password, PowderExtinguishersNumber);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Floors[] Floors_Select_By_FoamExtinguishersNumbers(string username, string password, String FoamExtinguishersNumbers)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Select_By_FoamExtinguishersNumbers(username, password, FoamExtinguishersNumbers);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Floors[] Floors_Select_By_PowderExtinguishersWeight(string username, string password, int PowderExtinguishersWeight)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Select_By_PowderExtinguishersWeight(username, password, PowderExtinguishersWeight);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Floors[] Floors_Select_By_CarbonDioxideExtinguishersWeight(string username, string password, int CarbonDioxideExtinguishersWeight)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Select_By_CarbonDioxideExtinguishersWeight(username, password, CarbonDioxideExtinguishersWeight);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        #endregion
        #region FFstations
        public bool FFstations_Delete(string username, string password, int FFstationsID)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Delete(username, password, FFstationsID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public FFstations[] FFstations_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_All(username, password);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_AreaName(string username, string password, string AreaName)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_AreaName(username, password, AreaName);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }
        public FFstations[] FFstations_Select_By_CarsNumber(string username, string password, string CarsNumber)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_CarsNumber(username, password, CarsNumber);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_Equipments(string username, string password, string Equipments)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_Equipments(username, password, Equipments);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_FF_ID(string username, string password, int FF_ID)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_FF_ID(username, password, FF_ID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_OfficersNumber(string username, string password, string OfficersNumber)
        {
            try 
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_OfficersNumber(username, password, OfficersNumber);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_Sector(string username, string password, string Sector)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_Sector(username, password, Sector);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_Signs(string username, string password, string Signs)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_Signs(username, password, Signs);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_SoliderNumber(string username, string password, string SoliderNumber)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_SoliderNumber(username, password, SoliderNumber);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_Street(string username, string password, string Street)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_Street(username, password, Street);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_UserID(username, password, UserID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_ZoneNumber(string username, string password, string ZoneNumber)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_ZoneNumber(username, password, ZoneNumber);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        #endregion
    }
}
