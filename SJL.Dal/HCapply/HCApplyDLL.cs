using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using SJL.Common.HCapply;

namespace SJL.Dal.HCapply
{
    public class HCApplyDLL
    {
        public void AddHCApplyDll(HCApply hCApply)
        {
            using (SqlHelper db = new SqlHelper())
            {
                string sql = "insert into HCApply (" +
                    "SQID,petitioner,location,phone,time,state) values(" +
                    "@SQID,@petitioner,@location,@phone,@time,@state)";
                using (DbCommand command = db.GetSqlStringCommond(sql))
                {
                    db.AddInParameter(command, "@SQID",DbType.String, hCApply.SQID);
                    db.AddInParameter(command, "@petitioner", DbType.String, hCApply.petitioner);
                    db.AddInParameter(command, "@location", DbType.String, hCApply.location);
                    db.AddInParameter(command, "@phone", DbType.String, hCApply.phone);
                    db.AddInParameter(command, "@time", DbType.String, hCApply.time);
                    db.AddInParameter(command, "@state", DbType.String, hCApply.state);
                    db.ExecuteNonQuery(command);
                }
            }

        }
    }
}
