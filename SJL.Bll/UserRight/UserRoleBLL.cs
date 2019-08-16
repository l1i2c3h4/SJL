using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJL.Entity;
using Dal0 = SJL.Dal.UserRight.UserRoleDal;
namespace SJL.Bll.UserRight
{
    public static class UesrRoleBLL
    {
        public static int add(UserRole role)
        {
            return Dal0.add(role);
        }
        public static int delete(string id)
        {
            return Dal0.delete(id);
        }
        public static int update(UserRole role)
        {
            return Dal0.update(role);
        }
        public static UserRole getByID(string id)
        {
            return Dal0.getByID(id);
        }
        public static List<UserRole> getAll(SJL.Common.PageDataArgument page)
        {
            return Dal0.getAll(page);
        }
    }
}
