using System.Collections.Generic;
using System.Data.Common;

namespace KPSService.Db
{
    interface IRow
    {
        void Init(DbDataReader r, Dictionary<string, int> columns);
    }
}
