﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;
using System.Data;

namespace IncidentReporting_WS.Code_Files.DAL
{
    public class CompanyDAL
    {
        DBL.DBL db = new DBL.DBL();
        byte[] smallArray = new byte[] { 0x20, 0x20 };

        public bool Company_Delete(string username, string password, int CompanyID)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@CompanyID", CompanyID}
                };
                bool flag = db.Execute_Update_Delete_Stored_Procedure("Company_Delete", sp_Params);
                return flag;
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
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@Name", company.Name},
                    {"@Address", company.Address},
                    {"@LandlinePhoneNumber",company.LandlinePhoneNumber},
                    {"@ElectricalPanelLocation",company.ElectricalPanelLocation },
                    {"@OxygenTrapLocation",company.OxygenTrapLocation},
                    {"@GasTrapLocation",company.GasTrapLocation},
                    {"@RightCompanyName",company.RightCompanyName},
                    {"@RightCompanyBusiness",company.RightCompanyBusiness},
                    {"@LeftCompanyName",company.LeftCompanyName},
                    {"@LeftCompanyBusiness",company.LeftCompanyBusiness},
                    {"@FrontCompanyName",company.FrontCompanyName},
                    {"@FrontCompanyBusiness", company.FrontCompanyBusiness},
                    {"@BackCompanyName", company.BackCompanyName},
                    {"@BackCompanyBusiness" ,company.BackCompanyBusiness},
                    {"@FrontFireMediator",company.FrontFireMediator },
                    {"@LeftFireMediator",company.LeftFireMediator },
                    {"@BackFireMediator",company.BackFireMediator },
                    {"@BuildingsNumber", company.BuildingsNumber},
                    {"@FrontCompanyImage",company.FrontCompanyName },
                    {"@BackCompanyImage",company.BackCompanyImage },
                    {"@RightCompanyImage",company.RightCompanyImage },
                    {"@LeftCompanyImage",company.LeftCompanyImage },
                    {"@UserID",company.UserID },
                    {"@FrontCompanyImageURL", company.FrontCompanyImageURL },
                    {"@BackCompanyImageURL",company.BackCompanyImageURL},
                    {"@RightCompanyImageURL", company.RightCompanyImageURL},
                    {"@LeftCompanyImageURL",company.LeftCompanyImageURL},
                    {"@Latitude",company.Latitude },
                    {"@Longitude",company.Longitude }
               };

                company.CompanyID = db.Execute_Insert_Stored_Procedure("Accident_Insert", sp_params);
                if (company.CompanyID > 0)
                {
                    return company;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_All(string username, string password)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name= dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address= dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber= dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation= dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName= dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName= dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness= dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName= dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness= dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator= dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator= dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator= dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage= dr["FrontCompanyImage"] is DBNull ?smallArray: (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage= dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID= dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_Address(string username, string password,string address)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Address", address}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_Address", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_BackCompanyBusiness(string username, string password, string BackCompanyBusiness)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@BackCompanyBusiness", BackCompanyBusiness}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_BackCompanyBusiness", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_BackCompanyName(string username, string password, string BackCompanyName)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@BackCompanyName", BackCompanyName}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_BackCompanyName", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_BackFireMediator(string username, string password, string BackFireMediator)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@BackFireMediator", BackFireMediator}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_BackFireMediator", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_BuildingsNumber(string username, string password, int BuildingsNumber)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@BuildingsNumber", BuildingsNumber}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_BuildingsNumber", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@CompanyID", CompanyID}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_CompanyID", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])

                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_ElectricalPanelLocation(string username, string password, string ElectricalPanelLocation)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@ElectricalPanelLocation", ElectricalPanelLocation}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_ElectricalPanelLocation", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_FrontCompanyBusiness(string username, string password, string FrontCompanyBusiness)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@FrontCompanyBusiness", FrontCompanyBusiness}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_FrontCompanyBusiness", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_FrontCompanyName(string username, string password, string FrontCompanyName)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@FrontCompanyName", FrontCompanyName}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_FrontCompanyName", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_FrontFireMediator(string username, string password, string FrontFireMediator)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@FrontFireMediator", FrontFireMediator}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_FrontFireMediator", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_GasTrapLocation(string username, string password, string GasTrapLocation)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@GasTrapLocation", GasTrapLocation}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_GasTrapLocation", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public CompanyCollection Company_Select_By_LandlinePhoneNumber(string username, string password, string LandlinePhoneNumber)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@LandlinePhoneNumber", LandlinePhoneNumber}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_LandlinePhoneNumber", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_LeftCompanyBusiness(string username, string password, string LeftCompanyBusiness)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@LeftCompanyBusiness", LeftCompanyBusiness}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_LeftCompanyBusiness", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_LeftCompanyName(string username, string password, string LeftCompanyName)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@LeftCompanyName", LeftCompanyName}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_LeftCompanyName", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_LeftFireMediator(string username, string password, string LeftFireMediator)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@LeftFireMediator", LeftFireMediator}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_LeftFireMediator", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_Name(string username, string password, string Name)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Name", Name}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_Name", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_OxygenTrapLocation(string username, string password, string OxygenTrapLocation)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@OxygenTrapLocation", OxygenTrapLocation}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_OxygenTrapLocation", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add( new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_RightCompanyBusiness(string username, string password, string RightCompanyBusiness)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@RightCompanyBusiness", RightCompanyBusiness}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_RightCompanyBusiness", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add( new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_RightCompanyName(string username, string password, string RightCompanyName)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@RightCompanyName", RightCompanyName}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_RightCompanyName", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_RightFireMediator(string username, string password, string RightFireMediator)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@RightFireMediator", RightFireMediator}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_RightFireMediator", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add(new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompanyCollection Company_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                CompanyCollection company = new CompanyCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@UserID", UserID}
                };
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Company_Select_By_UserID", sp_params);
                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        company.Add( new Company
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            Address = dr["Address"] is DBNull ? "" : Convert.ToString(dr["Address"]),
                            LandlinePhoneNumber = dr["LandlinePhoneNumber"] is DBNull ? "" : Convert.ToString(dr["LandlinePhoneNumber"]),
                            ElectricalPanelLocation = dr["ElectricalPanelLocation"] is DBNull ? "" : Convert.ToString(dr["ElectricalPanelLocation"]),
                            OxygenTrapLocation = dr["OxygenTrapLocation"] is DBNull ? "" : Convert.ToString(dr["OxygenTrapLocation"]),
                            GasTrapLocation = dr["GasTrapLocation"] is DBNull ? "" : Convert.ToString(dr["GasTrapLocation"]),
                            RightCompanyName = dr["RightCompanyName"] is DBNull ? "" : Convert.ToString(dr["RightCompanyName"]),
                            RightCompanyBusiness = dr["RightCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["RightCompanyBusiness"]),
                            LeftCompanyName = dr["LeftCompanyName"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyName"]),
                            LeftCompanyBusiness = dr["LeftCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["LeftCompanyBusiness"]),
                            FrontCompanyName = dr["FrontCompanyName"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyName"]),
                            FrontCompanyBusiness = dr["FrontCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["FrontCompanyBusiness"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            BackCompanyName = dr["BackCompanyName"] is DBNull ? "" : Convert.ToString(dr["BackCompanyName"]),
                            BackCompanyBusiness = dr["BackCompanyBusiness"] is DBNull ? "" : Convert.ToString(dr["BackCompanyBusiness"]),
                            FrontFireMediator = dr["FrontFireMediator"] is DBNull ? "" : Convert.ToString(dr["FrontFireMediator"]),
                            LeftFireMediator = dr["LeftFireMediator"] is DBNull ? "" : Convert.ToString(dr["LeftFireMediator"]),
                            BackFireMediator = dr["BackFireMediator"] is DBNull ? "" : Convert.ToString(dr["BackFireMediator"]),
                            RightFireMediator = dr["RightFireMediator"] is DBNull ? "" : Convert.ToString(dr["RightFireMediator"]),
                            BuildingsNumber = dr["BuildingsNumber"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingsNumber"]),
                            FrontCompanyImage = dr["FrontCompanyImage"] is DBNull ? smallArray : (byte[])dr["FrontCompanyImage"],
                            BackCompanyImage = dr["BackCompanyImage"] is DBNull ? smallArray : (byte[])dr["BackCompanyImage"],
                            RightCompanyImage = dr["RightCompanyImage"] is DBNull ? smallArray : (byte[])dr["RightCompanyImage"],
                            LeftCompanyImage = dr["LeftCompanyImage"] is DBNull ? smallArray : (byte[])dr["LeftCompanyImage"],
                            UserID = dr["UserID"] is DBNull ? 0 : Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}