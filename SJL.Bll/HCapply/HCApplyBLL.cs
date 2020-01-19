using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJL.Common.HCapply;
using SJL.Dal.HCapply;

namespace SJL.Bll.HCapply
{
    public class HCApplyBLL
    {
        public void AddHCApplyBLL(HCApply hCApply)
        {
            HCApplyDLL hCApplyDLL = new HCApplyDLL();
            hCApplyDLL.AddHCApplyDll(hCApply);
        }
    }
}
