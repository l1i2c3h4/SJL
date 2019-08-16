using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJL.Entity;
using SJL.Common;



namespace SJL.Dal.UserRight
{
    public class UserDal
    {
        public static int add(User user)
        {
            return EntityUtility.add<UserRightContext, User>(user);
        }
        public static int delete(string id)
        {
            return EntityUtility.delete(getQuery(), m => m.ID == id);
        }
        /// <summary>
        /// 更新用户信息，但不更新密码
        /// </summary>
        /// <param name="user">要更新的用户信息</param>
        /// <returns>被更新的用户数</returns>
        public static int update(User user)
        {
            return EntityUtility.update<UserRightContext, User>(user,"Password");
        }
        public static User getByID(string id)
        {
            return EntityUtility.selectOne(getQuery(), m => m.ID == id);
        }
        /// <summary>
        /// 分页获取用户列表
        /// </summary>
        /// <param name="page">分页参数</param>
        /// <returns>指定页面用户列表</returns>
        public static List<User> getAll(PageDataArgument page)
        {
            var query = getQuery();
            ObjectQueryArgument<User, string> arg = new ObjectQueryArgument<User, string>();
            arg.disposeAfterQuery = false;
            arg.query = query;
            arg.sort = m => m.ID;
            arg.page = page;
            var list= EntityUtility.selectMany(arg);                            //加载用户列表
            list.ForEach(u => u.UserRoleReference.Load());                      //加载用户角色
            EntityUtility.detachEntity(query.Context, list);
            query.Context.Dispose();
            return list;
        }
        public static bool isAdmin(User user)
        {
            return user.RoleID == "01";
        }
        public static int changePassword(User user)
        {
            return EntityUtility.update<UserRightContext, User>(user);
        }
        private static System.Data.Objects.ObjectQuery<User> getQuery()
        {
            return new UserRightContext().User;
        }   
    }
}
