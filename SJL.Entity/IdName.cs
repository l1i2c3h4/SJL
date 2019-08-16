using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SJL.Entity
{
    public sealed class IdName
    {
        public string id { get; set; }
        public string name { get; set; }
        public static IdName DefaultValue = new IdName() { id = null, name = null };
    }
}
