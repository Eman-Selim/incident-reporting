﻿using System;
using SDS_Remote_Control_WS.Code_Files.CBL;
using SDS_Remote_Control_WS.Code_Files.COL;
using SDS_Remote_Control_WS.Code_Files.DAL;
using SDS_Remote_Control_WS.Code_Files.ENL;

public class CompanySBL
{
	public CompanySBL()
	{
        ChkCBL Chk = new ChkCBL();
        CompanyDAL CompanyDAL_Obj = new CompanyDAL();

        public bool Company_Delete(string username, string password, int CompanyID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Delete( username, password, CompanyID);
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

        public Company Company_Insert(string username, string password, Company company)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Insert( username, password, company);
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

        public CompanyCollection Company_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_All( username, password);
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

        public CompanyCollection Company_Select_By_Address(string username, string password, string address)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_Address( username, password, address);
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

        public CompanyCollection Company_Select_By_BackCompanyBusiness(string username, string password, string BackCompanyBusiness)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_BackCompanyBusiness( username, password, BackCompanyBusiness);
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

        public CompanyCollection Company_Select_By_BackCompanyName(string username, string password, string BackCompanyName)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_BackCompanyName( username, password, BackCompanyName);
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

        public CompanyCollection Company_Select_By_BackFireMediator(string username, string password, string BackFireMediator)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_BackFireMediator( username, password, BackFireMediator);
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

        public CompanyCollection Company_Select_By_BuildingsNumber(string username, string password, string BuildingsNumber)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_BuildingsNumber( username, password, BuildingsNumber);
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

        public CompanyCollection Company_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_CompanyID( username, password, CompanyID);
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

        public CompanyCollection Company_Select_By_ElectricalPanelLocation(string username, string password, string ElectricalPanelLocation)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_ElectricalPanelLocation( username, password, ElectricalPanelLocation);
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

        public CompanyCollection Company_Select_By_FrontCompanyBusiness(string username, string password, string FrontCompanyBusiness)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_FrontCompanyBusiness( username, password, FrontCompanyBusiness);
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

        public CompanyCollection Company_Select_By_FrontCompanyName(string username, string password, string FrontCompanyName)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_FrontCompanyName( username, password, FrontCompanyName);
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

        public CompanyCollection Company_Select_By_FrontFireMediator(string username, string password, string FrontFireMediator)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_FrontFireMediator( username, password, FrontFireMediator);
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

        public CompanyCollection Company_Select_By_GasTrapLocation(string username, string password, string GasTrapLocation)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_GasTrapLocation( username, password, GasTrapLocation);
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

        public CompanyCollection Company_Select_By_LandlinePhoneNumber(string username, string password, string LandlinePhoneNumber)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_LandlinePhoneNumber( username, password, LandlinePhoneNumber);
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

        public CompanyCollection Company_Select_By_LeftCompanyBusiness(string username, string password, string LeftCompanyBusiness)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_LeftCompanyBusiness( username, password, LeftCompanyBusiness);
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

        public CompanyCollection Company_Select_By_LeftCompanyName(string username, string password, string LeftCompanyName)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_LeftCompanyName( username, password, LeftCompanyName);
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

        public CompanyCollection Company_Select_By_LeftFireMediator(string username, string password, string LeftFireMediator)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_LeftFireMediator( username, password, LeftFireMediator);
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

        public CompanyCollection Company_Select_By_Name(string username, string password, string Name)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_Name( username, password, Name);
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

        public CompanyCollection Company_Select_By_OxygenTrapLocation(string username, string password, string OxygenTrapLocation)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_OxygenTrapLocation( username, password, OxygenTrapLocation);
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

        public CompanyCollection Company_Select_By_RightCompanyBusiness(string username, string password, string RightCompanyBusiness)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_RightCompanyBusiness( username, password, RightCompanyBusiness);
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

        public CompanyCollection Company_Select_By_RightCompanyName(string username, string password, string RightCompanyName)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_RightCompanyName( username, password, RightCompanyName);
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

        public CompanyCollection Company_Select_By_RightFireMediator(string username, string password, string RightFireMediator)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_RightFireMediator( username, password, RightFireMediator);
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

        public CompanyCollection Company_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return CompanyDAL_Obj.Company_Select_By_UserID( username, password, UserID);
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
