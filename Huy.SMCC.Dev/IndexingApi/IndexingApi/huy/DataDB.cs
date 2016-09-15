using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overoll.Library
{
    class DataDB
    {
        public static DataTable getDataPages()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("PagesRank_GetAll", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            catch (Exception e)
            {
                var mes = e.Message;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static DataTable getDataGroups()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("GroupsRank_GetAll", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            catch (Exception e)
            {
                var mes = e.Message;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
    }
}
