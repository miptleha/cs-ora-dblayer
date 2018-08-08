using Db;
using Log;
using Oracle.ManagedDataAccess.Client;
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
                log4net.Config.XmlConfigurator.Configure();
                DbExecuter.Init();
                
                //change connection string in App.config
                DbExecuter.ConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

                Test(null);

                using (var con = DbExecuter.OpenConnection())
                {
                    var trans = con.BeginTransaction();
                    Test(trans);
                    trans.Commit();
                }

                log.Debug("all ok");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private static void Test(OracleTransaction trans)
        {
            log.Debug("Test");

            //sample execution of queries
            //all queries stored in sql folder in xml files

            //anonimous block
            var p = new DbParam { Name = "b", Output = true };
            DbExecuter.Execute(trans, "block", new DbParam { Name = "a", Value = "1" }, p);
            if (p.Value.ToString() != "2")
                throw new Exception(string.Format("expect '2', but receive '{0}'", p.Value));

            //select dummy as scalar
            var x = DbExecuter.SelectScalar(trans, "dual");
            if (x.ToString() != "X")
                throw new Exception("error in SelectScalar");

            //select dummy as object
            var i = DbExecuter.SelectRow<Dual>(trans, "dual");
            if (i.Dummy != "X")
                throw new Exception("error in SelectRow");

            //select dummy as List of objects
            var o = DbExecuter.Select<Dual>(trans, "dual");
            if (o.Count != 1 && o[0].Dummy != "X")
                throw new Exception("error in Select");

            //dynamic query (not from sql folder)
            o = DbExecuter.Select<Dual>(trans, "<dynamic>select * from dual");
            if (o.Count != 1 && o[0].Dummy != "X")
                throw new Exception("error in dynamic query");
        }
    }
}
