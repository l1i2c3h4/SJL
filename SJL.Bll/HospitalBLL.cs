using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dal = NrcmDal.Medicine.HospitalDAL;
using Nrcm.Entity;
using NrcmCommon;
namespace NrcmBll
{
    public static class HospitalBLL
    {
        public static int add(Hospital hospital)
        {
            return dal.add(hospital);
        }
        public static int update(Hospital hospital)
        {
            return dal.update(hospital);
        }
        public static int delete(string id)
        {
            return dal.delete(id);
        }
        public static Hospital getById(string id)
        {
            return dal.getById(id);
        }
        public static List<Hospital> getAll(PageDataArgument page)
        {
            return dal.getAll(page);
        }
        public static List<Hospital> getByName(string name, PageDataArgument page)
        {
            if (string.IsNullOrEmpty(name))
                return dal.getAll(page);
            return dal.getByName(name, page);
        }
    }
}
