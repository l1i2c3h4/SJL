using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJL.Entity;
using SJL.Common;

namespace SJL.Dal.UserRight
{
    public static class RoleRightDal
    {
        public static int add(RoleRight right)
        {
            return EntityUtility.add<UserRightContext, RoleRight>(right);
        }
        public static int update(RoleRight right)
        {
            return EntityUtility.update<UserRightContext, RoleRight>(right);
        }
        public static RoleRight getByID(string role, string module)
        {
            var query = getQuery();
            var i= EntityUtility.selectOne(query, m => m.RoleID == role && m.ModuleID == module,false);
            i.UserRoleReference.Load();
            i.ApplicationModuleReference.Load();
            EntityUtility.detachEntity(query.Context, i);
            query.Context.Dispose();
            return i;
        }
        public static List<RoleRight> getByRole(string role, PageDataArgument page)
        {
            var query = getQuery();
            ObjectQueryArgument<RoleRight, string> arg = new ObjectQueryArgument<RoleRight, string>();
            arg.disposeAfterQuery = false;
            arg.query = query;
            arg.page = page;
            arg.sort= r => r.ModuleID;
            var list = EntityUtility.selectMany(arg, r => r.RoleID == role);            
            list.ForEach(i => {
                i.UserRoleReference.Load();
                i.ApplicationModuleReference.Load();
            });
            EntityUtility.detachEntity(query.Context, list);
            query.Context.Dispose();
            return list;
        }
        /// <summary>
        /// 刷新角色权限数据
        /// </summary>
        public static void refreshRoleRight()
        {            
            var context = new UserRightContext();
            context.refreshRoleRight();
            context.Dispose();            
        }
        /// <summary>
        /// 用户是否有访问指定页面的权限
        /// </summary>
        /// <param name="role">角色ID</param>
        /// <param name="page">请求访问的页面</param>
        /// <returns>是否有权限</returns>
        public static bool canAccessPage(string role, string page)
        {
            string module=ApplicationModuleDal.getByUrl(page).ID;
            var right = EntityUtility.selectOne(getQuery(), r => r.RoleID == role && r.ModuleID == module);
            return right.TheRight == "1";
        }

        private static System.Data.Objects.ObjectQuery<RoleRight> getQuery()
        {
            return new UserRightContext().RoleRight;
        }
    }
}
