using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;

namespace IncidentReporting_WS.Code_Files.DAL
{
    public class DangerousPlacesDAL
    {
        DBL.DBL db = new DBL.DBL();

        public ENL.DangerousPlaces DangerousPlaces_Insert(string username, string password, ENL.DangerousPlaces DangerousPlaces)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@HazardousSubstance", DangerousPlaces.HazardousSubstance },
                    {"@Location", DangerousPlaces.Location},
                    {"@FireMediator",DangerousPlaces.FireMediator},
                    {"@CompanyID",DangerousPlaces.CompanyID }
               };

                DangerousPlaces.CompanyID = db.Execute_Insert_Stored_Procedure("DangerousPlaces_Insert", sp_params);
                if (DangerousPlaces.AccidentID > 0)
                {
                    return DangerousPlaces;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}