using Db;
using Log;
using OracleDbLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDbLayer
{
    class Program
    {
        static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            try
            {
                DbExecuter.Init();
                
                //change connection string in App.config
                DbExecuter.ConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

                //sample execution of queries
                //all queries stored in sql folder in xml files

                //anonimous block
                var p = new DbParam { Name = "b", Output = true };
                DbExecuter.Execute("block", new DbParam { Name = "a", Value = "1" }, p);
                if (p.Value.ToString() != "2")
                    throw new Exception(string.Format("expect '2', but receive '{0}'", p.Value));

                //select dummy as scalar
                var x = DbExecuter.SelectScalar("dual");
                if (x.ToString() != "X")
                    throw new Exception("uh oh");

                //select dummy as object
                var o = DbExecuter.Select<Dual>("dual");
                if (o.Count != 1 && o[0].Dummy != "X")
                    throw new Exception("hm");

                log.Debug("all ok");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
    }
}
