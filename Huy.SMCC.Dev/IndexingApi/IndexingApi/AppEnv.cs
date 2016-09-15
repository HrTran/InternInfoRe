using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexingApi
{
    public class AppEnv
    {
        public static string ConnectionString = "";

        public static string ElasticInstant
        {
            //get { return ConfigurationManager.AppSettings["ElasticInstant"].ToString(); }
            
        }

        public static string ElasticLong
        {
            //get { return ConfigurationManager.AppSettings["ElasticLong"].ToString(); }
            
        }

        public static string SmccApi
        {
            //get { return ConfigurationManager.AppSettings["SmccApi"].ToString(); }
            
        }

    }
}
