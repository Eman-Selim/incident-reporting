using System;
using SDS_Remote_Control_WS.Code_Files.CBL;
using SDS_Remote_Control_WS.Code_Files.COL;
using SDS_Remote_Control_WS.Code_Files.DAL;
using SDS_Remote_Control_WS.Code_Files.ENL;

public class ExitPathwaysSBL
{
	public ExitPathwaysSBL()
	{
        ChkCBL Chk = new ChkCBL();
        ExitPathwaysDAL ExitPathwaysDAL_Obj = new ExitPathwaysDAL();

        public ExitPathways ExitPathways_Insert(string username, string password, ExitPathways ExitPathway)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ExitPathwaysDAL_Obj.ExitPathways_Insert( username, password, ExitPathway);
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

        public ExitPathwaysCollection ExitPathways_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ExitPathwaysDAL_Obj.ExitPathways_Select_All( username, password);
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

        public ExitPathwaysCollection ExitPathways_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ExitPathwaysDAL_Obj.ExitPathways_Select_By_BuildingID( username, password, BuildingID);
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
