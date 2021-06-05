using CMS_Core.Entity;
using CMS_Core.Interface;
using Dapper;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Implementtion
{
    public class ImpINFORMATION_SCHEMA_PARAMETERS : IINFORMATION_SCHEMA_PARAMETERS
    {
       
        public List<INFORMATION_SCHEMA_PARAMETERS> GetINFORMATION_SCHEMA_PARAMETERSByProcedure(string ProcedureName)
        {
            try
            {
                if(string.IsNullOrEmpty(ProcedureName))
                {
                    ProcedureName = string.Empty;
                }
                string sql = "SELECT *  FROM INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME = '" + ProcedureName +"' ORDER BY ORDINAL_POSITION";
                var connection = new SqlConnection(Common.Common.getConnectionString());
                using (var con = connection)
                {                    
                    using (var mul = con.QueryMultiple(sql))
                    {
                        var data = mul.Read<INFORMATION_SCHEMA_PARAMETERS>().ToList();
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public List<INFORMATION_SCHEMA_PARAMETERS> GetINFORMATION_SCHEMA_PARAMETERSByProcedure(string ProcedureName, string connectionSQL)
        {
            try
            {
                if (string.IsNullOrEmpty(ProcedureName))
                {
                    ProcedureName = string.Empty;
                }
                string sql = "SELECT *  FROM INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME = '" + ProcedureName + "' ORDER BY ORDINAL_POSITION";
                var connection = new SqlConnection(connectionSQL);
                using (var con = connection)
                {
                    using (var mul = con.QueryMultiple(sql))
                    {
                        var data = mul.Read<INFORMATION_SCHEMA_PARAMETERS>().ToList();
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
