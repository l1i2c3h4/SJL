using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJL.Entity;
using Dal0 = SJL.Dal.UserRight.RoleRightDal;
using SJL.Common;
namespace SJL.Bll.UserRight
{
    public static class RoleRightBLL
    {
        public static int add(RoleRight right)
        {
            return Dal0.add(right);
        }      
        public static int update(RoleRight right)
        {
            return Dal0.update(right);
        }
        public static RoleRight getByID(string role,string module)
        {
            return Dal0.getByID(role, module);
        }
        public static List<RoleRight> getByRole(string role, PageDataArgument page)
        {
            return Dal0.getByRole(role, page);
        }
        public static void refreshRoleRight() { Dal0.refreshRoleRight(); }
        public static bool canAccessPage(string role, string page) { return Dal0.canAccessPage(role, page); }
    }
}
