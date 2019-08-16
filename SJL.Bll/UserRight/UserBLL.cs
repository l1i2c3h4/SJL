using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJL.Dal.UserRight;
using SJL.Entity;
namespace SJL.Bll.UserRight
{
    public static class UserBLL
    {
        private const string ConstDefaultPassword = "123456";
        public static int add(User user)
        {
            user.Password = ConstDefaultPassword;       //添加用户时设置默认密码
            return UserDal.add(user);
        }
        public static int delete(string id)
        {
            if (id.ToLower() == "admin")
                throw new ApplicationException("系统管理员用户admin不能被删除");
            return UserDal.delete(id);
        }
        public static int update(User user)
        {
            return UserDal.update(user);
        }
        public static User getByID(string id)
        {
            return UserDal.getByID(id);
        }
        public static int changePassword(User user)
        {
            return UserDal.changePassword(user);
        }
        public static bool isAdmin(User user) { return UserDal.isAdmin(user); }
        public static List<User> getAll(SJL.Common.PageDataArgument page)
        {
            return UserDal.getAll(page);
        }
    }
}
