using System;
using SDS_Remote_Control_WS.Code_Files.CBL;
using SDS_Remote_Control_WS.Code_Files.COL;
using SDS_Remote_Control_WS.Code_Files.DAL;
using SDS_Remote_Control_WS.Code_Files.ENL;

public class FFstationsSBL
{
	public FFstationsSBL()
	{
        ChkCBL Chk = new ChkCBL();
        FFstationsDAL FFstationsDAL_Obj = new FFstationsDAL();

        public bool FFstations_Delete(string username, string password, int FFstationsID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FFstationsDAL_Obj.FFstations_Delete( username, password, FFstationsID);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FFstations FFstations_Insert(string username, string password, FFstations FFstations)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FFstationsDAL_Obj.FFstations_Insert( username, password, FFstations);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FFstationsCollection FFstations_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FFstationsDAL_Obj.FFstations_Select_All( username, password);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FFstationsCollection FFstations_Select_By_AreaName(string username, string password, string AreaName)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FFstationsDAL_Obj.FFstations_Select_By_AreaName( username, password,AreaName);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FFstationsCollection FFstations_Select_By_CarsNumber(string username, string password, string CarsNumber)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FFstationsDAL_Obj.FFstations_Select_By_CarsNumber(username, password, CarsNumber);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FFstationsCollection FFstations_Select_By_Equipments(string username, string password, string Equipments)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FFstationsDAL_Obj.FFstations_Select_By_Equipments( username, password, Equipments);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FFstationsCollection FFstations_Select_By_FF_ID(string username, string password, int FF_ID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FFstationsDAL_Obj.FFstations_Select_By_FF_ID( username, password, FF_ID);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FFstationsCollection FFstations_Select_By_OfficersNumber(string username, string password, string OfficersNumber)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FFstationsDAL_Obj.FFstations_Select_By_OfficersNumber( username, password, OfficersNumber);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FFstationsCollection FFstations_Select_By_Sector(string username, string password, string Sector)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FFstationsDAL_Obj.FFstations_Select_By_Sector( username, password, Sector);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FFstationsCollection FFstations_Select_By_Signs(string username, string password, string Signs)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FFstationsDAL_Obj.FFstations_Select_By_Signs( username, password, Signs);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FFstationsCollection FFstations_Select_By_SoliderNumber(string username, string password, string SoliderNumber)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FFstationsDAL_Obj.FFstations_Select_By_SoliderNumber( username, password, SoliderNumber);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FFstationsCollection FFstations_Select_By_Street(string username, string password, string Street)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FFstationsDAL_Obj.FFstations_Select_By_Street( username, password, Street);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FFstationsCollection FFstations_Select_By_UserID(string username, string password, int UserID)
        { 
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FFstationsDAL_Obj.FFstations_Select_By_UserID( username, password, UserID);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FFstationsCollection FFstations_Select_By_ZoneNumber(string username, string password, string ZoneNumber)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FFstationsDAL_Obj.FFstations_Select_By_ZoneNumber( username, password, ZoneNumber);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
