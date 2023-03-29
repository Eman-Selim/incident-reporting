using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDS_Remote_Control_WS.Code_Files.CBL;
using SDS_Remote_Control_WS.Code_Files.COL;
using SDS_Remote_Control_WS.Code_Files.DAL;
using SDS_Remote_Control_WS.Code_Files.ENL;
using System.Data;

public class BuildingSBL
{
	public BuildingSBL()
	{
        ChkCBL Chk = new ChkCBL();
        BuildingsDAL BuildingsDAL_Obj = new BuildingsDAL();

        public bool Buildings_Delete(string username, string password, int BuildingID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return BuildingsDAL_Obj.Buildings_Delete( username, password, BuildingID);
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

        public Buildings Buildings_Insert(string username, string password, Buildings buildings)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AccidentDAL_Obj.Buildings_Insert( username, password, buildings);
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

        public BuildingsCollection Buildings_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return BuildingsDAL.Buildings_Select_All( username, password);
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

        public Buildings Buildings_Select_By_BuildingID(string username, string password, int ID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return BuildingsDAL_Obj.Buildings_Select_By_BuildingID( username, password, ID);
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

        public BuildingsCollection Buildings_Select_By_BuildingNumber(string username, string password, int BuildingNumber)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return BuildingsDAL_Obj.Buildings_Select_By_BuildingNumber( username, password, BuildingNumber);
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

        public BuildingsCollection Buildings_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return BuildingsDAL_Obj.Buildings_Select_By_CompanyID( username, password, CompanyID);
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

        public BuildingsCollection Buildings_Select_By_FloorsNumber(string username, string password, int FloorsNumber)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return BuildingsDAL_Obj.Buildings_Select_By_FloorsNumber( username, password, FloorsNumber);
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
