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
        /// <summary>
        /// 新增耗材单申请
        /// </summary>
        /// <param name="hCApply"></param>
        public void AddHCApplyDll(HCApply hCApply)
        {
            using (SqlHelper db = new SqlHelper())
            {
                string sql = "insert into HCApply (" +
                    "SQID,department,petitioner,location,phone,time,state) values(" +
                    "@SQID,@department,@petitioner,@location,@phone,@time,@state)";
                using (DbCommand command = db.GetSqlStringCommond(sql))
                {
                    db.AddInParameter(command, "@SQID", DbType.String, hCApply.SQID);
                    db.AddInParameter(command, "@petitioner", DbType.String, hCApply.petitioner);
                    db.AddInParameter(command, "@department", DbType.String, hCApply.department);
                    db.AddInParameter(command, "@location", DbType.String, hCApply.location);
                    db.AddInParameter(command, "@phone", DbType.String, hCApply.phone);
                    db.AddInParameter(command, "@time", DbType.String, hCApply.time);
                    db.AddInParameter(command, "@state", DbType.Int32, hCApply.state);
                    db.ExecuteNonQuery(command);
                }
            }

        }

        /// <summary>
        /// 新增耗材细项申请
        /// </summary>
        /// <param name="hCApplyDetails"></param>
        public void AddHCApplyDetailsDLL(HCApplyDetails hCApplyDetails)
        {
            using (SqlHelper db = new SqlHelper())
            {
                string sql = "insert into HCApplyDetails (" +
                    "SQID,XDID,room,printerModel,consumablesModel,number) values(" +
                    "@SQID,@XDID,@room,@printerModel,@consumablesModel,@number)";
                using (DbCommand command = db.GetSqlStringCommond(sql))
                {
                    db.AddInParameter(command, "@SQID", DbType.String, hCApplyDetails.SQID);
                    db.AddInParameter(command, "@XDID", DbType.Int32, hCApplyDetails.XDID);
                    db.AddInParameter(command, "@room", DbType.String, hCApplyDetails.room);
                    db.AddInParameter(command, "@printerModel", DbType.String, hCApplyDetails.printerModel);
                    db.AddInParameter(command, "@consumablesModel", DbType.String, hCApplyDetails.consumablesModel);
                    db.AddInParameter(command, "@number", DbType.String, hCApplyDetails.number);
                    db.ExecuteNonQuery(command);
                }
            }
        }

        /// <summary>
        /// 根据部门以及状态查找需要申请的项目
        /// </summary>
        /// <param name="department"></param>
        public List<HCApply> SearchHCApplyDLL(string department, int state)
        {
            List<HCApply> lists = new List<HCApply>();
            using (SqlHelper db = new SqlHelper())
            {
                string sql = "select * from HCApply where department = @department and state = @state";
                using (DbCommand command = db.GetSqlStringCommond(sql))
                {
                    db.AddInParameter(command, "@department", DbType.String, department);
                    db.AddInParameter(command, "@state", DbType.String, state);
                    using (DbDataReader reader = db.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            HCApply hCApply = new HCApply();
                            hCApply.SQID = reader["SQID"].ToString();
                            hCApply.petitioner = reader["petitioner"].ToString();
                            hCApply.location = reader["location"].ToString();
                            hCApply.department = reader["department"].ToString();
                            hCApply.phone = reader["phone"].ToString();
                            hCApply.time = reader["time"].ToString();
                            hCApply.note = reader["note"].ToString();
                            hCApply.state = int.Parse(reader["state"].ToString());
                            hCApply.SQBMview = reader["SQBMview"].ToString();
                            hCApply.SQBMtime = reader["SQBMtime"].ToString();
                            hCApply.XXGLYview = reader["XXGLYview"].ToString();
                            hCApply.XXGLYtime = reader["XXGLYtime"].ToString();
                            hCApply.XXLDview = reader["XXLDview"].ToString();
                            hCApply.XXLDtime = reader["XXLDtime"].ToString();
                            lists.Add(hCApply);
                        }
                    }
                }

            }

            return lists;
        }

        public List<HCApply> SearchHCApplyDLL(int state)
        {
            List<HCApply> lists = new List<HCApply>();
            using (SqlHelper db = new SqlHelper())
            {
                string sql = "select * from HCApply where state = @state";
                using (DbCommand command = db.GetSqlStringCommond(sql))
                {
                    db.AddInParameter(command, "@state", DbType.String, state);
                    using (DbDataReader reader = db.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            HCApply hCApply = new HCApply();
                            hCApply.SQID = reader["SQID"].ToString();
                            hCApply.petitioner = reader["petitioner"].ToString();
                            hCApply.location = reader["location"].ToString();
                            hCApply.department = reader["department"].ToString();
                            hCApply.phone = reader["phone"].ToString();
                            hCApply.time = reader["time"].ToString();
                            hCApply.note = reader["note"].ToString();
                            hCApply.state = int.Parse(reader["state"].ToString());
                            hCApply.SQBMview = reader["SQBMview"].ToString();
                            hCApply.SQBMtime = reader["SQBMtime"].ToString();
                            hCApply.XXGLYview = reader["XXGLYview"].ToString();
                            hCApply.XXGLYtime = reader["XXGLYtime"].ToString();
                            hCApply.XXLDview = reader["XXLDview"].ToString();
                            hCApply.XXLDtime = reader["XXLDtime"].ToString();
                            lists.Add(hCApply);
                        }
                    }
                }

            }

            return lists;
        }

        /// <summary>
        /// 根据申请ID查找详单信息
        /// </summary>
        /// <param name="SQID"></param>
        /// <returns></returns>
        public List<HCApplyDetails> SearchHCApplyDetailsBYSQIDDLL(string SQID)
        {
            List<HCApplyDetails> lists = new List<HCApplyDetails>();

            using (SqlHelper db = new SqlHelper())
            {
                string sql = "select * from HCApplyDetails where  SQID = @SQID";
                using (DbCommand command = db.GetSqlStringCommond(sql))
                {
                    db.AddInParameter(command, "@SQID", DbType.String, SQID);
                    using (DbDataReader reader = db.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            HCApplyDetails hCApplyDetails = new HCApplyDetails();
                            hCApplyDetails.SQID = reader["SQID"].ToString();
                            hCApplyDetails.XDID = int.Parse(reader["XDID"].ToString());
                            hCApplyDetails.room = reader["room"].ToString();
                            hCApplyDetails.printerModel = reader["printerModel"].ToString();
                            hCApplyDetails.consumablesModel = reader["consumablesModel"].ToString();
                            hCApplyDetails.number = reader["number"].ToString();
                            lists.Add(hCApplyDetails);
                        }
                    }
                }
            }

            return lists;

        }

        /// <summary>
        /// 根据申请ID查找申请单信息
        /// </summary>
        /// <param name="SQID"></param>
        /// <returns></returns>
        public HCApply SearchHCApplyBYSQIDDLL(string SQID)
        {
            HCApply hCApply = new HCApply();
            using (SqlHelper db = new SqlHelper())
            {
                string sql = "select * from HCApply where  SQID = @SQID";
                using (DbCommand command = db.GetSqlStringCommond(sql))
                {
                    db.AddInParameter(command, "@SQID", DbType.String, SQID);
                    using (DbDataReader reader = db.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            hCApply.SQID = reader["SQID"].ToString();
                            hCApply.petitioner = reader["petitioner"].ToString();
                            hCApply.location = reader["location"].ToString();
                            hCApply.department = reader["department"].ToString();
                            hCApply.phone = reader["phone"].ToString();
                            hCApply.time = reader["time"].ToString();
                            hCApply.note = reader["note"].ToString();
                            hCApply.state = int.Parse(reader["state"].ToString());
                            hCApply.SQBMview = reader["SQBMview"].ToString();
                            hCApply.SQBMtime = reader["SQBMtime"].ToString();
                            hCApply.XXGLYview = reader["XXGLYview"].ToString();
                            hCApply.XXGLYtime = reader["XXGLYtime"].ToString();
                            hCApply.XXLDview = reader["XXLDview"].ToString();
                            hCApply.XXLDtime = reader["XXLDtime"].ToString();
                            
                        }
                    }
                }

            }
            return hCApply;
        }
        /// <summary>
        /// 修改申请部门领导人的意见
        /// </summary>
        /// <param name="SQID"></param>
        /// <param name="s"></param>
        /// <param name="state"></param>
        public void UpdataHCApplyBUSQID1DLL(string SQID, string s, int state)
        {
            using (SqlHelper db = new SqlHelper())
            {
                string sql = "update HCApply set SQBMview = @s, SQBMtime = @time, state = @state where SQID = @SQID";
                using (DbCommand command = db.GetSqlStringCommond(sql))
                {
                    db.AddInParameter(command, "@s", DbType.String, s);
                    db.AddInParameter(command, "@time", DbType.String, DateTime.Now.ToString("yyyy-MM-dd"));
                    db.AddInParameter(command, "@SQID", DbType.String, SQID);
                    db.AddInParameter(command, "@state", DbType.String, state);
                    db.ExecuteNonQuery(command);
                }
            }
        }
        /// <summary>
        /// 修改信息工程部耗材管理意见
        /// </summary>
        /// <param name="SQID"></param>
        /// <param name="s"></param>
        /// <param name="state"></param>
        public void UpdataHCApplyBUSQID2DLL(string SQID, string s, int state)
        {
            using (SqlHelper db = new SqlHelper())
            {
                string sql = "update HCApply set XXGLYview = @s, XXGLYtime= @time, state = @state where SQID = @SQID";
                using (DbCommand command = db.GetSqlStringCommond(sql))
                {
                    db.AddInParameter(command, "@s", DbType.String, s);
                    db.AddInParameter(command, "@time", DbType.String, DateTime.Now.ToString("yyyy-MM-dd"));
                    db.AddInParameter(command, "@SQID", DbType.String, SQID);
                    db.AddInParameter(command, "@state", DbType.String, state);
                    db.ExecuteNonQuery(command);
                }
            }
        }
        /// <summary>
        /// 修改信息工程部领导审核意见
        /// </summary>
        /// <param name="SQID"></param>
        /// <param name="s"></param>
        /// <param name="state"></param>
        public void UpdataHCApplyBUSQID3DLL(string SQID, string s, int state)
        {
            using (SqlHelper db = new SqlHelper())
            {
                string sql = "update HCApply set XXLDview = @s, XXLDtime= @time, state = @state where SQID = @SQID";
                using (DbCommand command = db.GetSqlStringCommond(sql))
                {
                    db.AddInParameter(command, "@s", DbType.String, s);
                    db.AddInParameter(command, "@time", DbType.String, DateTime.Now.ToString("yyyy-MM-dd"));
                    db.AddInParameter(command, "@SQID", DbType.String, SQID);
                    db.AddInParameter(command, "@state", DbType.String, state);
                    db.ExecuteNonQuery(command);
                }
            }
        }

        /// <summary>
        /// 查询全部申请的情况
        /// </summary>
        /// <returns></returns>
        public List<HCApply> HCSearchHCApplyDLL()
        {
            List<HCApply> lists = new List<HCApply>();
            using (SqlHelper db = new SqlHelper())
            {
                string sql = "select * from HCApply ";
                using (DbCommand command = db.GetSqlStringCommond(sql))
                {;
                    using (DbDataReader reader = db.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            HCApply hCApply = new HCApply();
                            hCApply.SQID = reader["SQID"].ToString();
                            hCApply.petitioner = reader["petitioner"].ToString();
                            hCApply.location = reader["location"].ToString();
                            hCApply.department = reader["department"].ToString();
                            hCApply.phone = reader["phone"].ToString();
                            hCApply.time = reader["time"].ToString();
                            hCApply.note = reader["note"].ToString();
                            hCApply.state = int.Parse(reader["state"].ToString());
                            hCApply.SQBMview = reader["SQBMview"].ToString();
                            hCApply.SQBMtime = reader["SQBMtime"].ToString();
                            hCApply.XXGLYview = reader["XXGLYview"].ToString();
                            hCApply.XXGLYtime = reader["XXGLYtime"].ToString();
                            hCApply.XXLDview = reader["XXLDview"].ToString();
                            hCApply.XXLDtime = reader["XXLDtime"].ToString();
                            lists.Add(hCApply);
                        }
                    }
                }

            }

            return lists;
        }


    }
}
