using System;
using SDS_Remote_Control_WS.Code_Files.CBL;
using SDS_Remote_Control_WS.Code_Files.COL;
using SDS_Remote_Control_WS.Code_Files.DAL;
using SDS_Remote_Control_WS.Code_Files.ENL;

public class DeathSBL
{
	public DeathSBL()
	{
        ChkCBL Chk = new ChkCBL();
        DeathDAL DeathDAL_Obj = new DeathDAL();

        public bool Death_Delete(string username, string password, int DeathID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Delete( username, password, DeathID);
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

        public Death Death_Insert(string username, string password, Death death)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Insert( username, password, death);
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

        public DeathCollection Death_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Select_All( username, password);
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

        public DeathCollection Death_Select_By_AccidentID(string username, string password, int AccidentID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Select_By_AccidentID( username, password, AccidentID);
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

        public DeathCollection Death_Select_By_Age(string username, string password, int Age)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Select_By_Age( username, password, Age);
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

        public DeathCollection Death_Select_By_Civil_Military(string username, string password, string Civil_Military)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Select_By_Civil_Military( username, password, Civil_Military);
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

        public DeathCollection Death_Select_By_Date(string username, string password, DateTime Date)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Select_By_Date( username, password, Date);
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

        public DeathCollection Death_Select_By_DeathID(string username, string password, int DeathID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Select_By_DeathID( username, password, DeathID);
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

        public DeathCollection Death_Select_By_Name(string username, string password, string Name)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Select_By_Name( username, password, Name);
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

        public DeathCollection Death_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Select_By_Rank( username, password, Rank);
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
