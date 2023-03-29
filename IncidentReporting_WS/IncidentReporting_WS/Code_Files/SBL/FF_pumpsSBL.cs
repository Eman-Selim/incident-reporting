using System;
using SDS_Remote_Control_WS.Code_Files.CBL;
using SDS_Remote_Control_WS.Code_Files.COL;
using SDS_Remote_Control_WS.Code_Files.DAL;
using SDS_Remote_Control_WS.Code_Files.ENL;

public class FF_pumpsSBL
{
	public FF_pumpsSBL()
	{
        ChkCBL Chk = new ChkCBL();
        FF_pumpsDAL FF_pumpsDAL_Obj = new FF_pumpsDAL();

        public bool FF_pumps_Delete(string username, string password, int FF_pumpsID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_pumpsDAL_Obj.FF_pumps_Delete( username, password, FF_pumpsID);
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

        public FF_pumps FF_pumps_Insert(string username, string password, FF_pumps FF_pumps)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_pumpsDAL_Obj.FF_pumps_Insert( username, password, FF_pumps);
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

        public FF_pumpsCollection FF_pumps_Select_All(string username, string password)
    {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_pumpsDAL_Obj.FF_pumps_Select_All( username, password);
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

        public FF_pumpsCollection FF_pumps_Select_By_Address(string username, string password, string Address)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_pumpsDAL_Obj.FF_pumps_Select_By_Address( username, password, Address);
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

        public FF_pumpsCollection FF_pumps_Select_By_Area(string username, string password, string Area)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_pumpsDAL_Obj.FF_pumps_Select_By_Area( username, password, Area);
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

        public FF_pumpsCollection FF_pumps_Select_By_FF_pumpsID(string username, string password, int FF_pumpsID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_pumpsDAL_Obj.FF_pumps_Select_By_FF_pumpsID( username, password, FF_pumpsID);
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

        public FF_pumpsCollection FF_pumps_Select_By_PumpNumber(string username, string password, string PumpNumber)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_pumpsDAL_Obj.FF_pumps_Select_By_PumpNumber( username, password, PumpNumber);
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

        public FF_pumpsCollection FF_pumps_Select_By_Sector(string username, string password, string Sector)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_pumpsDAL_Obj.FF_pumps_Select_By_Sector( username, password, Sector);
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

        public FF_pumpsCollection FF_pumps_Select_By_Signs(string username, string password, string Signs)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_pumpsDAL_Obj.FF_pumps_Select_By_Signs( username, password, Signs);
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

        public FF_pumpsCollection FF_pumps_Select_By_Status(string username, string password, string Status)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_pumpsDAL_Obj.FF_pumps_Select_By_Status( username, password, Status);
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

        public FF_pumpsCollection FF_pumps_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_pumpsDAL_Obj.FF_pumps_Select_By_UserID( username, password, UserID);
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
