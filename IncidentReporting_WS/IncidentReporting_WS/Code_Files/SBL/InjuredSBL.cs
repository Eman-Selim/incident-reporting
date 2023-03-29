using System;
using SDS_Remote_Control_WS.Code_Files.CBL;
using SDS_Remote_Control_WS.Code_Files.COL;
using SDS_Remote_Control_WS.Code_Files.DAL;
using SDS_Remote_Control_WS.Code_Files.ENL;

public class InjuredSBL
{
	public InjuredSBL()
	{
        ChkCBL Chk = new ChkCBL();
        InjuredDAL InjuredDAL_Obj = new InjuredDAL();

        public bool Injured_Delete(string username, string password, int InjuredID)
        { 
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return InjuredDAL_Obj.Injured_Delete( username, password, InjuredID);
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

        public Injured Injured_Insert(string username, string password, Injured Injured)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return InjuredDAL_Obj.Injured_Insert( username, password, Injured);
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

        public InjuredCollection Injured_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return InjuredDAL_Obj.Injured_Select_All( username, password);
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

        public InjuredCollection Injured_Select_By_AccidentID(string username, string password, int AccidentID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return InjuredDAL_Obj.Injured_Select_By_AccidentID( username, password, AccidentID);
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

        public InjuredCollection Injured_Select_By_Age(string username, string password, int Age)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return InjuredDAL_Obj.Injured_Select_By_Age( username, password, Age);
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

        public InjuredCollection Injured_Select_By_Civil_Military(string username, string password, string Civil_Military)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return InjuredDAL_Obj.Injured_Select_By_Civil_Military( username, password, Civil_Military);
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

        public InjuredCollection Injured_Select_By_Date(string username, string password, DateTime Date)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return InjuredDAL_Obj.Injured_Select_By_Date( username, password, Date);
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

        public InjuredCollection Injured_Select_By_InjuredID(string username, string password, int InjuredID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return InjuredDAL_Obj.Injured_Select_By_InjuredID( username, password, InjuredID);
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

        public InjuredCollection Injured_Select_By_Name(string username, string password, string Name)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return InjuredDAL_Obj.Injured_Select_By_Name( username, password, Name);
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

        public InjuredCollection Injured_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return InjuredDAL_Obj.Injured_Select_By_Rank( username, password, Rank);
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
