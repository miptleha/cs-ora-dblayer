using Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace OracleDbLayer.Models
{
    class Dual : IRow
    {
        public string Dummy { get; set; }

        public void Init(DbDataReader r, Dictionary<string, int> columns)
        {
            Dummy = (string)r["Dummy"];
        }
    }
}
