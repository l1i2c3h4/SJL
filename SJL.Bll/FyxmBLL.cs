using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NrcmDal.Medicine;
using Nrcm.Entity;
using NrcmCommon;

namespace NrcmBll
{
    public static class FyxmBLL
    {
        public static int add(FYXM fyxm)
        {
            return FyxmDAL.add(fyxm);
        }
        public static int delete(string id)
        {
            return FyxmDAL.delete(id);
        }
        public static int update(FYXM fyxm)
        {
            return FyxmDAL.update(fyxm);

        }
        public static FYXM getById(string id)
        {
            return FyxmDAL.getById(id);
        }
        public static List<FYXM> getAll(ExpenseItemType type, PageDataArgument page)
        {
            return FyxmDAL.getAll( type,page);
        }
        public static List<FYXM> getByJsm(ExpenseItemType type, string jsm, PageDataArgument page)
        {
            return FyxmDAL.getByJsm(jsm,type, page);
        }
        public static List<FYXM> getByName(ExpenseItemType type, string name, PageDataArgument page)
        {
            return FyxmDAL.getByName(name,type, page);
        }
        public static List<FYXM> getByJsmOrName(ExpenseItemType type, string name, PageDataArgument page)
        {
            var list1 = getByJsm(type, name, page);
            if (list1.Count > page.pageSize) return list1;
            int count = page.count;
            page.pageSize = page.pageSize - list1.Count;
            var list2 = getByName(type, name, page);            
            list1.AddRange(list2);            
            if (page.refreshCount)
                page.count += count;                
            return list1;
        }
    }
}
