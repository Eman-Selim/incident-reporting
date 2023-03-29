using System;
using SDS_Remote_Control_WS.Code_Files.CBL;
using SDS_Remote_Control_WS.Code_Files.COL;
using SDS_Remote_Control_WS.Code_Files.DAL;
using SDS_Remote_Control_WS.Code_Files.ENL;

public class FloorsSBL
{
	public FloorsSBL()
	{
        ChkCBL Chk = new ChkCBL();
        FloorsDAL FloorsDAL_Obj = new FloorsDAL();

        public Floors Floors_Insert(string username, string password, Floors Floors)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FloorsDAL_Obj.Floors_Insert( username, password, Floors);
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

        public FloorsCollection Floors_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FloorsDAL_Obj.Floors_Select_All( username, password);
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

        public FloorsCollection Floors_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FloorsDAL_Obj.Floors_Select_By_BuildingID( username, password, BuildingID);
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

        public FloorsCollection Floors_Select_By_CarbonDioxideExtinguishersNumbers(string username, string password, String CarbonDioxideExtinguishersNumbers)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FloorsDAL_Obj.Floors_Select_By_CarbonDioxideExtinguishersNumbers( username, password, CarbonDioxideExtinguishersNumbers);
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

        public FloorsCollection Floors_Select_By_PowderExtinguishersNumber(string username, string password, String PowderExtinguishersNumber)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FloorsDAL_Obj.Floors_Select_By_PowderExtinguishersNumber( username, password, PowderExtinguishersNumber);
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

        public FloorsCollection Floors_Select_By_FoamExtinguishersNumbers(string username, string password, String FoamExtinguishersNumbers)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FloorsDAL_Obj.Floors_Select_By_FoamExtinguishersNumbers( username, password, FoamExtinguishersNumbers);
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

        public FloorsCollection Floors_Select_By_PowderExtinguishersWeight(string username, string password, int PowderExtinguishersWeight)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FloorsDAL_Obj.Floors_Select_By_PowderExtinguishersWeight( username, password, PowderExtinguishersWeight);
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

        public FloorsCollection Floors_Select_By_CarbonDioxideExtinguishersWeight(string username, string password, int CarbonDioxideExtinguishersWeight)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FloorsDAL_Obj.Floors_Select_By_CarbonDioxideExtinguishersWeight( username, password, CarbonDioxideExtinguishersWeight);
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

        public FloorsCollection Floors_Select_By_FoamExtinguishersWeight(string username, string password, int FoamExtinguishersWeight)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FloorsDAL_Obj.Floors_Select_By_FoamExtinguishersWeight( username, password, FoamExtinguishersWeight);
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
