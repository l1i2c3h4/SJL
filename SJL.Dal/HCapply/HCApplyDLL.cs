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
        //新增耗材申请
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

        public void AddHCApplyDetailsDLL(HCApplyDetails hCApplyDetails)
        {
            using (SqlHelper db = new SqlHelper())
            {
                string sql = "insert into HCApplyDetails (" +
                    "SQID,department,room,printerModel,consumablesModel,number) values(" +
                    "@SQID,@department,@room,@printerModel,@consumablesModel,@number)";
                using (DbCommand command = db.GetSqlStringCommond(sql))
                {
                    db.AddInParameter(command, "@SQID", DbType.String, hCApplyDetails.SQID);
                    db.AddInParameter(command, "@department", DbType.Int32, hCApplyDetails.department);
                    db.AddInParameter(command, "@room", DbType.String, hCApplyDetails.room);
                    db.AddInParameter(command, "@printerModel", DbType.String, hCApplyDetails.printerModel);
                    db.AddInParameter(command, "@consumablesModel", DbType.String, hCApplyDetails.consumablesModel);
                    db.AddInParameter(command, "@number", DbType.String, hCApplyDetails.number);
                    db.ExecuteNonQuery(command);
                }
            }
        }


    }
}
