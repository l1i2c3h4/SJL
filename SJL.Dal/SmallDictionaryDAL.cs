using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using SJL.Common;

namespace SJL.Dal
{   
    public static class SmallDictionaryDAL
    {
        /*
        public static IdName getByID(string table, int id)
        {
            Database db = DatabaseFactory.CreateDatabase("SJL");            
            DbCommand command = db.GetSqlStringCommand("select name from " + table + " where id=@id");
            db.AddInParameter(command, "@id", DbType.String, id);
            string name=Convert.ToString(db.ExecuteScalar(command));
            return new IdName() { id = id, name = name };
        }
        public static List<IdName> getAll(string table)
        {
            Database db = DatabaseFactory.CreateDatabase("NRCM");
            DbCommand command = db.GetSqlStringCommand("select id,name from " + table);
            IDataReader reader= db.ExecuteReader(command);
            List<IdName> list = new List<IdName>();
            while (reader.Read())
            {
                list.Add(new IdName()
                {
                    id=Convert.ToInt32(reader[0]),
                    name=Convert.ToString(reader[1])
                }
                );
            }            
            reader.Close();
            return list;
        }
        */
    }    
}
