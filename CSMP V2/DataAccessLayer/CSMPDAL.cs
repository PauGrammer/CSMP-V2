using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PDAnozaUtilities.Database;
using CSMP_V2.Models.Domain;
using System.Data;
using System.Data.SqlClient;
namespace CSMP_V2.DataAccessLayer
{
    public class CSMPDAL:MSSQLHandler
    {
        public CSMPDAL():base(ConfigManager.Database.DatabaseConnection){}

        public List<SNC> GetSNCList()
        {
            var sncList = new List<SNC>();
            SetProperties();
            Command = "DomainDB.csmp.pr_GetSNC";
            CommandType = CommandType.StoredProcedure;

            var dataTable = GetDataTable();
            
            if(ErrorHandler.IsSuccessful)
            {
                if(dataTable.Rows.Count > 0)
                {
                    foreach(DataRow row in dataTable.Rows)
                    {
                        var snc = new SNC()
                        {
                            SNCID = Convert.ToInt32(row["SNCID"]),
                            SNCName = row["SNCName"].ToString()
                        };
                        sncList.Add(snc);
                    }
                }
            }
            return sncList;
        }


        public List<Area> GetAreaList()
        {
            var areaList = new List<Area>();
            SetProperties();
            Command = "DomainDB.dbo.pr_GetAreaList";
            CommandType = CommandType.StoredProcedure;
            Parameters.Add(new SqlParameter("@ColumnName", "ForCSMP"));

            var dataTable = GetDataTable();

            if (ErrorHandler.IsSuccessful)
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        var area = new Area()
                        {
                            AreaID = Convert.ToInt32(row["Area_ID"]),
                            AreaName = row["AreaName"].ToString()
                        };
                        areaList.Add(area);
                    }
                }
            }
            return areaList;
        }
    }
}