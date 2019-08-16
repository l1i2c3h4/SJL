using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SJL.Common
{
    public static class SmallDictionaryTables
    {
        #region contants (table name)      
        #endregion
    }
    public sealed class IdName
    {
        public int id { get; set; }
        public string name { get; set; }
        public static IdName DefaultValue = new IdName() { id = 0, name = null };
    }
}
