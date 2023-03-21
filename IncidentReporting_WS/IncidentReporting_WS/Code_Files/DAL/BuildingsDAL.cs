﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;
using System.Data;

namespace IncidentReporting_WS.Code_Files.DAL
{
    public class BuildingsDAL
    {
        DBL.DBL db = new DBL.DBL();
        public bool Buildings_Delete(string username, string password, int BuildingID)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@BuildingID", BuildingID}
                };
                bool flag = db.Execute_Update_Delete_Stored_Procedure("Buildings_Delete", sp_Params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Buildings Buildings_Insert(string username, string password, Buildings   buildings)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@BuildingNumber", buildings.BuildingNumber },
                    {"@FloorsNumber", buildings.FloorsNumber},
                    {"@CompanyID",buildings.CompanyID},
                    {"@MainWaterTankCapacity",buildings.MainWaterTankCapacity},
                    {"@GeometricImage",buildings.GeometricImage}
                    

               };

                buildings.BuildingID = db.Execute_Insert_Stored_Procedure("Buildings_Insert", sp_params);
                if (buildings.BuildingID> 0)
                {
                    return buildings;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public BuildingsCollection Buildings_Select_All(string username, string password)
        {
            try
            {
                BuildingsCollection buildings = new BuildingsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Buildings_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        buildings.Add(new Buildings
                        {
                            BuildingNumber = Convert.ToInt32(dr["BuildingNumber"]),
                            FloorsNumber = Convert.ToInt32(dr["FloorsNumber"]),
                            CompanyID = Convert.ToInt32(dr["CompanyID"]),
                            BuildingID = Convert.ToInt32(dr["BuildingID"]),
                            MainWaterTankCapacity = Convert.ToInt32(dr["MainWaterTankCapacity"]),
                            GeometricImage = (byte[])dr["GeometricImage"]
                        });
                    }
                }
                return buildings;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Buildings Buildings_Select_By_BuildingID(string username, string password,int ID)
        {
            try
            {
                Buildings buildings = new Buildings();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@BuildingID", ID}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Buildings_Select_By_BuildingID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        buildings=new Buildings
                        {
                            BuildingNumber = Convert.ToInt32(dr["BuildingNumber"]),
                            FloorsNumber = Convert.ToInt32(dr["FloorsNumber"]),
                            CompanyID = Convert.ToInt32(dr["CompanyID"]),
                            BuildingID = Convert.ToInt32(dr["BuildingID"]),
                            MainWaterTankCapacity = Convert.ToInt32(dr["MainWaterTankCapacity"]),
                            GeometricImage = (byte[])dr["GeometricImage"]
                        };
                    }
                }
                return buildings;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public BuildingsCollection Buildings_Select_By_BuildingNumber(string username, string password, int BuildingNumber)
        {
            try
            {
                BuildingsCollection buildings = new BuildingsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@BuildingNumber", BuildingNumber}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Buildings_Select_By_BuildingNumber", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        buildings.Add(new Buildings
                        {
                            BuildingNumber = Convert.ToInt32(dr["BuildingNumber"]),
                            FloorsNumber = Convert.ToInt32(dr["FloorsNumber"]),
                            CompanyID = Convert.ToInt32(dr["CompanyID"]),
                            BuildingID = Convert.ToInt32(dr["BuildingID"]),
                            MainWaterTankCapacity = Convert.ToInt32(dr["MainWaterTankCapacity"]),
                            GeometricImage = (byte[])dr["GeometricImage"]
                        });
                    }
                }
                return buildings;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public BuildingsCollection Buildings_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                BuildingsCollection buildings = new BuildingsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@CompanyID", CompanyID}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Buildings_Select_By_CompanyID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        buildings.Add(new Buildings
                        {
                            BuildingNumber = Convert.ToInt32(dr["BuildingNumber"]),
                            FloorsNumber = Convert.ToInt32(dr["FloorsNumber"]),
                            CompanyID = Convert.ToInt32(dr["CompanyID"]),
                            BuildingID = Convert.ToInt32(dr["BuildingID"]),
                            MainWaterTankCapacity = Convert.ToInt32(dr["MainWaterTankCapacity"]),
                            GeometricImage = (byte[])dr["GeometricImage"]
                        });
                    }
                }
                return buildings;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public BuildingsCollection Buildings_Select_By_FloorsNumber(string username, string password, int FloorsNumber)
        {
            try
            {
                BuildingsCollection buildings = new BuildingsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@FloorsNumber", FloorsNumber}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Buildings_Select_By_FloorsNumber", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        buildings.Add(new Buildings
                        {
                            BuildingNumber = Convert.ToInt32(dr["BuildingNumber"]),
                            FloorsNumber = Convert.ToInt32(dr["FloorsNumber"]),
                            CompanyID = Convert.ToInt32(dr["CompanyID"]),
                            BuildingID = Convert.ToInt32(dr["BuildingID"]),
                            MainWaterTankCapacity = Convert.ToInt32(dr["MainWaterTankCapacity"]),
                            GeometricImage = (byte[])dr["GeometricImage"]
                        });
                    }
                }
                return buildings;
            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}