using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using IncidentReporting_WS.Code_Files.CBL;
using IncidentReporting_WS.Code_Files.COL;
using IncidentReporting_WS.Code_Files.SBL;
using IncidentReporting_WS.Code_Files.ENL;

namespace IncidentReporting_WS
{
    /// <summary>
    /// Summary description for IncidentReporting_WS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class IncidentReporting_WS : System.Web.Services.WebService
    {
        #region UsersSBL
        UsersSBL UsersSBL_Obj = new UsersSBL();

        [WebMethod]
        public bool Users_Delete(string username, string password, int user_id)
        {
            try
            {

                return UsersSBL_Obj.Users_Delete( username, password, user_id);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public Users Users_Insert(string username, string password, Users Users)
        {
            try
            {
                return UsersSBL_Obj.Users_Insert( username, password, Users);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public UsersCollection Users_Select_All(string username, string password)
        {
            try
            {
                Users users = new Users();
                users = UsersSBL_Obj.Users_Select_All( username, password);
                return users;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public Users Users_SelectByUserId(string username, string password, int UserId)
        {
            try
            {
                Users users = new Users();
                users = UsersSBL_Obj.Users_SelectByUserId( username, password, UserId);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public UsersCollection Users_Select_Super_Admin(string username, string password)
        {
            try
            {
                UsersCollection users = new UsersCollection();
                users = UsersSBL_Obj.Users_Select_Super_Admin( username, password);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        
        #endregion

        #region Users_AdminSBL
        Users_AdminSBL Users_AdminSBL_Obj = new Users_AdminSBL();

        [WebMethod]
        public bool Users_Admin_Delete(string username, string password, int user_id, int Admin_id)
        {
            try
            {

                return Users_AdminSBL_Obj.Users_Admin_Delete( username, password, user_id, Admin_id);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public Users_Admin Users_Admin_Insert(string username, string password, Users_Admin Users_Admin)
        {
            try
            {
                return Users_AdminSBL_Obj.Users_Admin_Insert( username, password, Users_Admin);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public Users_AdminCollection Users_Admin_Select_All(string username, string password)
        {
            try
            {
                Users users = new Users();
                users = Users_AdminSBL_Obj.Users_Admin_Select_All( username, password);
                return users;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public Users_Admin Users_Admin_SelectByAdminId(string username, string password, int Admin_ID)
        {
            try
            {
                Users users = new Users();
                users = Users_AdminSBL_Obj.Users_Admin_SelectByAdminId( username, password, Admin_ID);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public Users_Admin Users_Admin_SelectByUserID(string username, string password, int User_ID)
        {
            try
            {
                UsersCollection users = new UsersCollection();
                users = Users_AdminSBL_Obj.Users_Admin_SelectByUserID( username, password, User_ID);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        
        #endregion

        #region InjuredSBL
        InjuredSBL InjuredSBL_Obj = new InjuredSBL();

        [WebMethod]
        public bool Injured_Delete(string username, string password, int InjuredID)
        {
            try
            {

                return InjuredSBL_Obj.Injured_Delete( username, password, InjuredID);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public Injured Injured_Insert(string username, string password, Injured Injured)
        {
            try
            {
                return InjuredSBL_Obj.Injured_Insert( username, password, Injured);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public InjuredCollection Injured_Select_All(string username, string password)
        {
            try
            {
                InjuredCollection users = new InjuredCollection();
                users = InjuredSBL.Injured_Select_All( username, password);
                return users;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public InjuredCollection Injured_Select_By_AccidentID(string username, string password, int AccidentID)
        {
            try
            {
                InjuredCollection users = new InjuredCollection();
                users = InjuredSBL.Injured_Select_By_AccidentID( username, password, AccidentID);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public InjuredCollection Injured_Select_By_Age(string username, string password, int Age)
        {
            try
            {
                InjuredCollection users = new InjuredCollection();
                users = InjuredSBL_Obj.Injured_Select_By_Age( username, password, Age);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public InjuredCollection Injured_Select_By_Civil_Military(string username, string password, string Civil_Military)
        {
            try
            {
                InjuredCollection users = new InjuredCollection();
                users = InjuredSBL_Obj.Injured_Select_By_Civil_Military( username, password,Civil_Military);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public InjuredCollection Injured_Select_By_Date(string username, string password, DateTime Date)
        {
            try
            {
                InjuredCollection users = new InjuredCollection();
                users = InjuredSBL_Obj.Injured_Select_By_Date( username, password, Date);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public InjuredCollection Injured_Select_By_InjuredID(string username, string password, int InjuredID)
        {
            try
            {
                InjuredCollection users = new InjuredCollection();
                users = InjuredSBL_Obj.Injured_Select_By_InjuredID(username,password,InjuredID);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public InjuredCollection Injured_Select_By_Name(string username, string password, string Name)
        {
            try
            {
                InjuredCollection users = new InjuredCollection();
                users = InjuredSBL_Obj.Injured_Select_By_Name( username, password, Name);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        
        [WebMethod]
        public InjuredCollection Injured_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
                InjuredCollection users = new InjuredCollection();
                users = InjuredSBL_Obj.Injured_Select_By_Rank( username, password, Rank);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region ImagesSBL
        ImagesSBL ImagesSBL_Obj = new ImagesSBL();

        [WebMethod]
        public Images Images_Insert(string username, string password, Images Images)
        {
            try
            {

                return ImagesSBL_Obj.Images_Insert( username, password, Images);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public ImagesCollection Images_Select_All(string username, string password)
        {
            try
            {
                return ImagesSBL_Obj.Images_Select_All( username, password);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public ImagesCollection Images_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                ImagesCollection Images = new ImagesCollection();
                Images = ImagesSBL_Obj.Images_Select_By_BuildingID( username, password,  BuildingID);
                return Images;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public ImagesCollection Images_Select_By_ImageDescription(string username, string password, string ImageDescription)
        {
            try
            {
                ImagesCollection Images = new ImagesCollection();
                Images = ImagesSBL.Images_Select_By_ImageDescription(username,password, ImageDescription);
                return Images;

            }
            catch (Exception e)
            {
                return null;
            }
        }

       
        #endregion

        #region FloorsSBL
        FloorsSBL FloorsSBL_Obj = new FloorsSBL();

        [WebMethod]
        public Floors Floors_Insert(string username, string password, Floors Floors)
        {
            try
            {

                return FloorsSBL_Obj.Floors_Insert( username,password,Floors);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public FloorsCollection Floors_Select_All(string username, string password)
        {
            try
            {
                return FloorsSBL_Obj.Floors_Select_All(username,password);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public FloorsCollection Floors_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                Floors = ImagesSBL.Floors_Select_By_BuildingID(username,password,BuildingID);
                return Floors;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public FloorsCollection Floors_Select_By_CarbonDioxideExtinguishersNumbers(string username, string password, String CarbonDioxideExtinguishersNumbers)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                Floors = FloorsSBL_Obj.Floors_Select_By_CarbonDioxideExtinguishersNumbers( username, password, CarbonDioxideExtinguishersNumbers);
                return Floors;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public FloorsCollection Floors_Select_By_PowderExtinguishersNumber(string username, string password, String PowderExtinguishersNumber)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                Floors = FloorsSBL_Obj.Floors_Select_By_PowderExtinguishersNumber(username,password,PowderExtinguishersNumber);
                return Floors;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FloorsCollection Floors_Select_By_FoamExtinguishersNumbers(string username, string password, String FoamExtinguishersNumbers)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                Floors = FloorsSBL_Obj.Floors_Select_By_FoamExtinguishersNumbers( username, password, FoamExtinguishersNumbers);
                return Floors;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FloorsCollection Floors_Select_By_PowderExtinguishersWeight(string username, string password, int PowderExtinguishersWeight)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                Floors = FloorsSBL_Obj.Floors_Select_By_PowderExtinguishersWeight( username, password, PowderExtinguishersWeight);
                return Floors;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FloorsCollection Floors_Select_By_CarbonDioxideExtinguishersWeight(string username, string password, int CarbonDioxideExtinguishersWeight)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                Floors = FloorsSBL_Obj.Floors_Select_By_CarbonDioxideExtinguishersWeight(username,password,CarbonDioxideExtinguishersWeight);
                return Floors;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FloorsCollection Floors_Select_By_FoamExtinguishersWeight(string username, string password, int FoamExtinguishersWeight)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                Floors = FloorsSBL_Obj.Floors_Select_By_FoamExtinguishersWeight(username, password, FoamExtinguishersWeight);
                return Floors;

            }
            catch (Exception e)
            {
                return null;
            }
        }       
        #endregion

        #region FFstationsSBL
        FFstationsSBL FFstationsSBL_Obj = new FFstationsSBL();

        [WebMethod]
        public bool FFstations_Delete(string username, string password, int FFstationsID)
        {
            try
            {

                return FFstationsSBL_Obj.FFstations_Delete( username, password, FFstationsID);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public FFstations FFstations_Insert(string username, string password, FFstations FFstations)
        {
            try
            {
                return FFstationsSBL_Obj.FFstations_Insert( username, password, FFstations);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public FFstationsCollection FFstations_Select_All(string username, string password)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                FFstations = FFstationsSBL_Obj.FFstations_Select_All( username, password);
                return FFstations;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_AreaName(string username, string password, string AreaName)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                FFstations = FFstationsSBL_Obj.FFstations_Select_By_AreaName( username, password, AreaName);
                return FFstations;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_CarsNumber(string username, string password, string CarsNumber)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                FFstations = FFstationsSBL_Obj.FFstations_Select_By_CarsNumber( username, password, CarsNumber);
                return FFstations;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_Equipments(string username, string password, string Equipments)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
               FFstations = FFstationsSBL_Obj.FFstations_Select_By_Equipments(username,password,Equipments);
                return FFstations;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_FF_ID(string username, string password, int FF_ID)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                FFstations = FFstationsSBL_Obj.FFstations_Select_By_FF_ID(username,password,FF_ID);
                return Floors;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_OfficersNumber(string username, string password, string OfficersNumber)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                FFstations = FFstationsSBL_Obj.FFstations_Select_By_OfficersNumber(username,password,OfficersNumber);
                return FFstations;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_Sector(string username, string password, string Sector)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                FFstations  = FFstationsSBL_Obj.FFstations_Select_By_Sector( username, password, Sector);
                return FFstations;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_Signs(string username, string password, string Signs)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                FFstations  = FFstationsSBL_Obj.FFstations_Select_By_Signs(username,password,Signs);
                return FFstations;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_SoliderNumber(string username, string password, string SoliderNumber)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                FFstations  = FFstationsSBL_Obj.FFstations_Select_By_SoliderNumber(username,password,SoliderNumber);
                return FFstations;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_Street(string username, string password, string Street)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                FFstations  = FFstationsSBL_Obj.FFstations_Select_By_Street(username,password,Street);
                return FFstations;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                FFstations  = FFstationsSBL_Obj.FFstations_Select_By_UserID(username,password,UserID);
                return FFstations;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_ZoneNumber(string username, string password, string ZoneNumber)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                FFstations  = FFstationsSBL_Obj.FFstations_Select_By_ZoneNumber(username,password,ZoneNumber);
                return FFstations;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        #endregion

        #region FF_pumpsSBL
        FF_pumpsSBL FF_pumpsSBL_Obj = new FF_pumpsSBL();

        [WebMethod]
        public bool FF_pumps_Delete(string username, string password, int FF_pumpsID)
        {
            try
            {

                return FF_pumpsSBL_Obj.FF_pumps_Delete( username,password,FF_pumpsID);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public FF_pumps FF_pumps_Insert(string username, string password, FF_pumps FF_pumps)
        {
            try
            {
                return FF_pumpsSBL_Obj.FF_pumps_Insert(username,password,FF_pumps);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_All(string username, string password)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                FF_pumps = FF_pumpsSBL_Obj.FF_pumps_Select_All(username,password);
                return FF_pumps;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_By_Address(string username, string password, string Address)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                FF_pumps = FF_pumpsSBL_Obj.FF_pumps_Select_By_Address( username, password, Address);
                return FF_pumps;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_By_Area(string username, string password, string Area)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                FF_pumps = FF_pumpsSBL_Obj.FF_pumps_Select_By_Area( username, password, Area);
                return FF_pumps;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_By_FF_pumpsID(string username, string password, int FF_pumpsID)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
               FF_pumps = FF_pumpsSBL_Obj.FF_pumps_Select_By_FF_pumpsID( username, password, FF_pumpsID);
                return FF_pumps;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_By_PumpNumber(string username, string password, string PumpNumber)
        {
            try
            {
                FF_pumpsCollection FF_pumps= new FF_pumpsCollection();
                FF_pumps = FF_pumpsSBL_Obj.FF_pumps_Select_By_PumpNumber( username, password, PumpNumber);
                return FF_pumps;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_By_Sector(string username, string password, string Sector)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                FF_pumps = FF_pumpsSBL_Obj.FF_pumps_Select_By_Sector(username,password,Sector);
                return FF_pumps;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_By_Signs(string username, string password, string Signs)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                FF_pumps  = FF_pumpsSBL_Obj.FF_pumps_Select_By_Signs( username, password, Signs);
                return FF_pumps;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_By_Status(string username, string password, string Status)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                FF_pumps  = FF_pumpsSBL_Obj.FF_pumps_Select_By_Status(username, password, Status);
                return FF_pumps;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        #endregion

        #region FF_ManPowerSBL
        FF_ManPowerSBL FF_ManPowerSBL_Obj = new FF_ManPowerSBL();

        [WebMethod]
        public bool FF_ManPower_Delete(string username, string password, int FF_ManPowerID)
        {
            try
            {

                return FF_ManPowerSBL_Obj.FF_ManPower_Delete( username, password, FF_ManPowerID);

            }
            catch (Exception ex)
            {
                return false;
            }
        }
         
        [WebMethod]
        public FF_ManPower FF_ManPower_Insert(string username, string password, FF_ManPower ManPower)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Insert(username,password,ManPower);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_All(string username, string password)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_All(username,password);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_Area(string username, string password, int AccidentNumber)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_Area( username, password, AccidentNumber);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_Availability(string username, string password, string Availability)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_Availability(username,password,Availability);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_FF_ManPowerID(string username, string password, int FF_ManPowerID)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_FF_ManPowerID(username,password,FF_ManPowerID);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_Job(string username, string password, string Job)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_Job( username, password, Job);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_OfficerName(string username, string password, string OfficerName)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_OfficerName(username,password,OfficerName);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_Point(string username, string password, string Point)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_Point(username,password,Point);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_Rank(username,password,Rank);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_Sector(string username, string password, string Sector)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_Sector(username,password,Sector);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_TimeSlot(string username, string password, string TimeSlot)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_TimeSlot(username,password,TimeSlot);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_UserID(string username, string password, string UserID)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_UserID(username,password,UserID);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       
        #endregion

        #region ExitPathwaysSBL
         ExitPathwaysSBL ExitPathwaysSBL_Obj = new ExitPathwaysSBL();

        [WebMethod]
        public ExitPathways ExitPathways_Insert(string username, string password, ExitPathways ExitPathway)
        {
            try
            {
               ExitPathways ExitPathways= new ExitPathways();
                ExitPathways  =ExitPathwaysSBL_Obj.ExitPathways_Insert( username, password, ExitPathway);
                return ExitPathways;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public ExitPathwaysCollection ExitPathways_Select_All(string username, string password)
        {
            try
            {
                ExitPathwaysCollection ExitPathways= new ExitPathwaysCollection();
                ExitPathways  =ExitPathwaysSBL_Obj.ExitPathways_Select_All(username, password);
                return ExitPathways;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public ExitPathwaysCollection ExitPathways_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                ExitPathwaysCollection ExitPathways= new ExitPathwaysCollection();
                ExitPathways  =ExitPathwaysSBL_Obj.ExitPathways_Select_By_BuildingID(username,password,BuildingID);
                return ExitPathways;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion

        #region DeathSBL
            DeathSBL DeathSBL_Obj= new DeathSBL();

        [WebMethod]
        public bool Death_Delete(string username, string password, int DeathID)
        {
            try
            {
                return DeathSBL_Obj.Death_Delete( username,password, DeathID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public Death Death_Insert(string username, string password, Death death)
        {
            try
            {
               Death Death= new Death();
                Death  =DeathSBL_Obj.Death_Insert( username,  password, death);
                return Death;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public DeathCollection Death_Select_All(string username, string password)
        {
            try
            {
               DeathCollection Death= new DeathCollection();
                Death  =DeathSBL_Obj.Death_Select_All( username, password);
                return Death;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public DeathCollection Death_Select_By_AccidentID(string username, string password, int AccidentID)
        {
            try
            {
               DeathCollection Death= new DeathCollection();
                Death  =DeathSBL_Obj.Death_Select_By_AccidentID( username, password,AccidentID);
                return Death;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public DeathCollection Death_Select_By_Age(string username, string password, int Age)
        {
            try
            {
               DeathCollection Death= new DeathCollection();
                Death  =DeathSBL_Obj.Death_Select_By_Age( username, password, Age);
                return Death;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public DeathCollection Death_Select_By_Civil_Military(string username, string password, string Civil_Military)
        {
            try
            {
               DeathCollection Death= new DeathCollection();
                Death  =DeathSBL_Obj.Death_Select_By_Civil_Military( username, password, Civil_Military);
                return Death;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public DeathCollection Death_Select_By_Date(string username, string password, DateTime Date)
        {
            try
            {
               DeathCollection Death= new DeathCollection();
                Death  =DeathSBL_Obj.Death_Select_By_Date( username, password, Date);
                return Death;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public DeathCollection Death_Select_By_DeathID(string username, string password, int DeathID)
        {
            try
            {
               DeathCollection Death= new DeathCollection();
                Death  =DeathSBL_Obj.Death_Select_By_DeathID( username, password, DeathID);
                return Death;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public DeathCollection Death_Select_By_Name(string username, string password, string Name)
        {
            try
            {
               DeathCollection Death= new DeathCollection();
                Death  =DeathSBL_Obj.Death_Select_By_Name( username,  password, Name);
                return Death;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public DeathCollection Death_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
               DeathCollection Death= new DeathCollection();
                Death  =DeathSBL_Obj.Death_Select_By_Rank( username, password, Rank);
                return Death;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
        
        #region DangerousPlacesSBL
        DangerousPlacesSBL DangerousPlacesSBL_Obj =new DangerousPlacesSBL();

        [WebMethod]
        public DangerousPlaces DangerousPlaces_Insert(string username, string password, DangerousPlaces DangerousPlaces)
        {
            try
            {
               DangerousPlaces DangerousPlaces= new DangerousPlaces();
                DangerousPlaces  =DangerousPlacesSBL_Obj.DangerousPlaces_Insert( username, password, DangerousPlaces);
                return DangerousPlaces;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public DangerousPlacesCollection DangerousPlaces_Select_All(string username, string password)
        {
            try
            {
               DangerousPlacesCollection DangerousPlaces= new DangerousPlacesCollection();
                DangerousPlaces  =DangerousPlacesSBL_Obj.DangerousPlaces_Select_All( username, password);
                return DangerousPlaces;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public DangerousPlacesCollection DangerousPlaces_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
               DangerousPlacesCollection DangerousPlaces= new DangerousPlacesCollection();
                DangerousPlaces  =DangerousPlacesSBL_Obj.DangerousPlaces_Select_By_CompanyID( username, password, CompanyID);
                return DangerousPlaces;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public DangerousPlacesCollection DangerousPlaces_Select_By_FireMediator(string username, string password, string FireMediator)
        {
            try
            {
               DangerousPlacesCollection DangerousPlaces= new DangerousPlacesCollection();
                DangerousPlaces  =DangerousPlacesSBL_Obj.DangerousPlaces_Select_By_FireMediator( username, password, FireMediator);
                return DangerousPlaces;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public DangerousPlacesCollection DangerousPlaces_Select_By_HazardousSubstance(string username, string password, string HazardousSubstance)
        {
            try
            {
               DangerousPlacesCollection DangerousPlaces= new DangerousPlacesCollection();
                DangerousPlaces  =DangerousPlacesSBL_Obj.DangerousPlaces_Select_By_HazardousSubstance( username, password, HazardousSubstance);
                return DangerousPlaces;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public DangerousPlacesCollection DangerousPlaces_Select_By_Location(string username, string password, string Location)
        {
            try
            {
               DangerousPlacesCollection DangerousPlaces= new DangerousPlacesCollection();
                DangerousPlaces  =DangerousPlacesSBL_Obj.DangerousPlaces_Select_By_Location(username,password,Location);
                return DangerousPlaces;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region CompanySBL
            CompanySBL CompanySBL_Obj=new CompanySBL();
            
        [WebMethod]
        public bool Company_Delete(string username, string password, int CompanyID)
        {
            try
            {
                return CompanySBL_Obj.Company_Delete( username, password, CompanyID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public Company Company_Insert(string username, string password, Company company)
        {
            try
            {
                Company Company= new Company();
                Company=CompanySBL_Obj.Company_Insert( username, password, company);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_All(string username, string password)
        {
            try
            {
                CompanyCollection Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_All( username, password);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_Address(string username, string password, string address)
        {
            try
            {
               CompanyCollection Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_Address(username,password,address);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_BackCompanyBusiness(string username, string password, string BackCompanyBusiness)
        {
            try
            {
                CompanyCollection Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_BackCompanyBusiness(username,password,BackCompanyBusiness);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_BackCompanyName(string username, string password, string BackCompanyName)
        {
            try
            {
                CompanyCollection Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_BackCompanyName( username, password, BackCompanyName);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_BackFireMediator(string username, string password, string BackFireMediator)
        {
            try
            {
                CompanyCollection Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_BackFireMediator( username, password, BackFireMediator);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_BuildingsNumber(string username, string password, string BuildingsNumber)
        {
            try
            {
                CompanyCollection Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_BuildingsNumber( username, password,BuildingsNumber);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

         [WebMethod]
        public CompanyCollection Company_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                CompanyCollection Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_CompanyID( username, password, CompanyID);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_ElectricalPanelLocation(string username, string password, string ElectricalPanelLocation)
        {
            try
            {
                CompanyCollection Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_ElectricalPanelLocation(username,password,ElectricalPanelLocation);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_FrontCompanyBusiness(string username, string password, string FrontCompanyBusiness)
        {
            try
            {
                CompanyCollection Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_FrontCompanyBusiness( username, password, FrontCompanyBusiness);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_FrontCompanyName(string username, string password, string FrontCompanyName)
        {
            try
            {
                CompanyCollection Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_FrontCompanyName( username, password, FrontCompanyName);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_FrontFireMediator(string username, string password, string FrontFireMediator)
        {
            try
            {
                CompanyCollection Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_FrontFireMediator( username, password, FrontFireMediator);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_GasTrapLocation(string username, string password, string GasTrapLocation)
        {
            try
            {
                CompanyCollection Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_GasTrapLocation( username, password, GasTrapLocation);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_LandlinePhoneNumber(string username, string password, string LandlinePhoneNumber)
        {
            try
            {
                CompanyCollection Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_LandlinePhoneNumber( username, password, LandlinePhoneNumber);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_LeftCompanyBusiness(string username, string password, string LeftCompanyBusiness)
        {
            try
            {
                CompanyCollection Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_LeftCompanyBusiness( username, password, LeftCompanyBusiness);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_LeftCompanyName(string username, string password, string LeftCompanyName)
        {
            try
            {
                CompanyCollection Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_LeftCompanyName( username, password, LeftCompanyName);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_LeftFireMediator(string username, string password, string LeftFireMediator)
        {
            try
            {
                CompanyCollection Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_LeftFireMediator( username ,password, LeftFireMediator);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_Name(string username, string password, string Name)
        {
            try
            {
                CompanyCollection  Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_Name( username, password, Name);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_OxygenTrapLocation(string username, string password, string OxygenTrapLocation)
        {
            try
            {
                CompanyCollection  Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_OxygenTrapLocation( username, password, OxygenTrapLocation);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_RightCompanyBusiness(string username, string password, string RightCompanyBusiness)
        {
            try
            {
                CompanyCollection  Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_RightCompanyBusiness( username, password, RightCompanyBusiness);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_RightCompanyName(string username, string password, string RightCompanyName)
        {
            try
            {
                CompanyCollection  Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_RightCompanyName( username, password, RightCompanyName);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_RightFireMediator(string username, string password, string RightFireMediator)
        {
            try
            {
                CompanyCollection  Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_RightFireMediator( username, password,  RightFireMediator);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                CompanyCollection  Company= new CompanyCollection();
                Company=CompanySBL_Obj.Company_Select_By_UserID( username, password, UserID);
                return Company;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region BuildingSBL
         BuildingSBL BuildingSBL_Obj=new BuildingSBL();

        [WebMethod]
        public bool Buildings_Delete(string username, string password, int BuildingID)
        {
            try
            {
                return BuildingSBL_Obj.Buildings_Delete( username, password, BuildingID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public Buildings Buildings_Insert(string username, string password, Buildings buildings)
        {
            try
            {
                Buildings Buildings= new Buildings();
                Buildings=BuildingSBL_Obj.Buildings_Insert( username, password, buildings);
                return Buildings;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public BuildingsCollection Buildings_Select_All(string username, string password)
        {
            try
            {
                BuildingsCollection Buildings= new BuildingsCollection();
                Buildings=BuildingSBL_Obj.Buildings_Select_All(username, password);
                return Buildings;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public Buildings Buildings_Select_By_BuildingID(string username, string password, int ID)
        {
            try
            {
                Buildings Buildings= new Buildings();
                Buildings=BuildingSBL_Obj.Buildings_Select_By_BuildingID(username,password,ID);
                return Buildings;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public BuildingsCollection Buildings_Select_By_BuildingNumber(string username, string password, int BuildingNumber)
        {
            try
            {
                BuildingsCollection Buildings= new BuildingsCollection();
                Buildings=BuildingSBL_Obj.Buildings_Select_By_BuildingNumber(  username, password, BuildingNumber);
                return Buildings;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public BuildingsCollection Buildings_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                BuildingsCollection Buildings= new BuildingsCollection();
                Buildings=BuildingSBL_Obj.Buildings_Select_By_CompanyID( username, password, CompanyID);
                return Buildings;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public BuildingsCollection Buildings_Select_By_FloorsNumber(string username, string password, int FloorsNumber)
        {
            try
            {
                BuildingsCollection Buildings= new BuildingsCollection();
                Buildings=BuildingSBL_Obj.Buildings_Select_By_FloorsNumber(username,password,FloorsNumber);
                return Buildings;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion

        #region AccidentSBL
        AccidentSBL AccidentSBL_Obj=new AccidentSBL();
        [WebMethod]
        public bool Accident_Delete(string username, string password, int accidentid)
        {
            try
            {
                return AccidentSBL_Obj.Accident_Delete(username,password,accidentid);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

         [WebMethod]
        public Accident Accident_Insert(string username, string password, Accident accident)
        {
            try
            {
                Accident Accident= new Accident();
                Accident=AccidentSBL_Obj.Accident_Insert( username,  password,  accident);
                return Accident;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_All(string username, string password)
        {
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_All( username, password);
                return Accident;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public Accident Accident_Select_By_AccidentNumber(string username, string password, int AccidentNumber)
        {
            try
            {
                Accident Accident= new Accident();
                Accident=AccidentSBL_Obj.Accident_Select_By_AccidentNumber( username, password, AccidentNumber);
                return Accident;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_By_CompanyID( username, password, CompanyID);
                return Accident;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_By_Date(string username, string password, DateTime date)
        {
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_By_Date( username, password, date);
                return Accident;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_By_Equipments(string username, string password, string equipments)
        {
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_By_Equipments( username, password, equipments);
                return Accident;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public Accident Accident_Select_By_ID(string username, string password, int ID)
        {
            try
            {
                Accident Accident= new Accident();
                Accident=AccidentSBL_Obj.Accident_Select_By_ID( username, password, ID);
                return Accident;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_By_LossesType(string username, string password, string LossesType)
        {
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_By_LossesType( username, password, LossesType);
                return Accident;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_By_TimeToArrive(string username, string password, DateTime TimeToArrive)
        { 
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_By_TimeToArrive( username, password, TimeToArrive);
                return Accident;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_By_TimeToSend(string username, string password, DateTime TimeToSend)
        { 
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_By_TimeToSend( username, password, TimeToSend);
                return Accident;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_By_Type(string username, string password, string AccidentType)
        { 
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_By_Type( username, password, AccidentType);
                return Accident;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_By_VehiclesToAccident(string username, string password, string VehiclesToAccident)
        { 
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_By_VehiclesToAccident(username, password, VehiclesToAccident);
                return Accident;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion  
    }
}
