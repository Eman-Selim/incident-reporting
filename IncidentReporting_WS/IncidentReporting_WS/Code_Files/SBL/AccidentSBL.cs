using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDS_Remote_Control_WS.Code_Files.CBL;
using SDS_Remote_Control_WS.Code_Files.COL;
using SDS_Remote_Control_WS.Code_Files.DAL;
using SDS_Remote_Control_WS.Code_Files.ENL;

public class AccidentSBL
{
	public AccidentSBL()
	{
        ChkCBL Chk = new ChkCBL();
        AccidentDAL AccidentDAL_Obj = new AccidentDAL();

        public bool Accident_Delete(string username, string password, int accidentid)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AccidentDAL_Obj.Accident_Delete(username, password, accidentid);
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

        public Accident Accident_Insert(string username, string password, Accident accident)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AccidentDAL_Obj.Accident_Insert( username, password, accident);
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

        public AccidentCollection Accident_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AccidentDAL_Obj.Accident_Select_All( username, password);
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

        public Accident Accident_Select_By_AccidentNumber(string username, string password, int AccidentNumber)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AccidentDAL_Obj.Accident_Select_By_AccidentNumber( username, password, AccidentNumber);
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

        public AccidentCollection Accident_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AccidentDAL_Obj.Accident_Select_By_CompanyID( username, password, CompanyID);
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

        public AccidentCollection Accident_Select_By_Date(string username, string password, DateTime date)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AccidentDAL_Obj.Accident_Select_By_Date( username, password, date);
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

        public AccidentCollection Accident_Select_By_Equipments(string username, string password, string equipments)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AccidentDAL_Obj.Accident_Select_By_Equipments( username, password, equipments);
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

        public Accident Accident_Select_By_ID(string username, string password, int ID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AccidentDAL_Obj.Accident_Select_By_ID( username, password, ID);
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

        public AccidentCollection Accident_Select_By_LossesType(string username, string password, string LossesType)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AccidentDAL_Obj.Accident_Select_By_LossesType( username, password, LossesType);
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

        public AccidentCollection Accident_Select_By_TimeToArrive(string username, string password, DateTime TimeToArrive)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AccidentDAL_Obj.Accident_Select_By_TimeToArrive( username, password, TimeToArrive);
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

        public AccidentCollection Accident_Select_By_TimeToSend(string username, string password, DateTime TimeToSend)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AccidentDAL_Obj.Accident_Select_By_TimeToSend( username, password, TimeToSend);
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

        public AccidentCollection Accident_Select_By_Type(string username, string password, string AccidentType)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AccidentDAL_Obj.Accident_Select_By_Type( username, password, AccidentType);
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

        public AccidentCollection Accident_Select_By_VehiclesToAccident(string username, string password, string VehiclesToAccident)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AccidentDAL_Obj.Accident_Select_By_VehiclesToAccident( username, password, VehiclesToAccident);
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
