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
        private HCApplyDLL hCApplyDLL = new HCApplyDLL();
        public void AddHCApplyBLL(HCApply hCApply)
        {
           
            hCApplyDLL.AddHCApplyDll(hCApply);
        }

        public void AddHCApplyDetailsBLL(HCApplyDetails hCApplyDetails)
        {
            hCApplyDLL.AddHCApplyDetailsDLL(hCApplyDetails);
        }

        public List<HCApply> SearchHCApplyBLL(string department,int state)
        {
            return hCApplyDLL.SearchHCApplyDLL(department, state);

        }

        public List<HCApply> SearchHCApplyBLL(int state)
        {
            return hCApplyDLL.SearchHCApplyDLL(state);

        }

        public HCApply SearchHCApplyBYSQIDBLL(string SQID)
        {
            return hCApplyDLL.SearchHCApplyBYSQIDDLL(SQID);

        }

        public List<HCApplyDetails> SearchHCApplyDetailsBYSQIDBLL(string SQID)
        {
            return hCApplyDLL.SearchHCApplyDetailsBYSQIDDLL(SQID);
        }

        public void UpdateHCApplyBYSQID1BLL(string SQID,string s,int state)
        {
            hCApplyDLL.UpdataHCApplyBUSQID1DLL(SQID,s,state);
        }

        public void UpdateHCApplyBYSQID2BLL(string SQID, string s, int state)
        {
            hCApplyDLL.UpdataHCApplyBUSQID2DLL(SQID, s, state);
        }

        public void UpdateHCApplyBYSQID3BLL(string SQID, string s, int state)
        {
            hCApplyDLL.UpdataHCApplyBUSQID3DLL(SQID, s, state);
        }

        public List<HCApply> HCSearchHCApplyBLL(string sortField, string sort)
        {
            return hCApplyDLL.HCSearchHCApplyDLL(sortField,sort);
        }
    }
}
