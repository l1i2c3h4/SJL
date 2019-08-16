using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJL.Entity;
using SJL.Common;

namespace SJL.Dal.UserRight
{
/// <summary>
/// 用户角色数据访问层
/// </summary>
public static class UserRoleDal
{
    /// <summary>
    /// 添加一个角色
    /// </summary>
    /// <param name="role">要添加的角色</param>
    /// <returns>添加的角色数</returns>
    public static int add(UserRole role)
    {
        return EntityUtility.add<UserRightContext, UserRole>(role);
    }
    /// <summary>
    /// 根据id删除一个角色
    /// </summary>
    /// <param name="id">要删除的角色id</param>
    /// <returns>删除的角色数</returns>
    public static int delete(string id)
    {
        return EntityUtility.delete(getQuery(), m => m.ID == id);
    }
    public static int update(UserRole role)
    {
        return EntityUtility.update<UserRightContext, UserRole>(role);
    }
    /// <summary>
    /// 根据id得到角色数据
    /// </summary>
    /// <param name="id">要查询的角色id</param>
    /// <returns>查询到的角色数据</returns>
    public static UserRole getByID(string id)
    {
        return EntityUtility.selectOne(getQuery(), m => m.ID == id);
    }
    /// <summary>
    /// 分页得到角色列表
    /// </summary>
    /// <param name="page">分页参数</param>
    /// <returns></returns>
    public static List<UserRole> getAll(PageDataArgument page)
    {
        ObjectQueryArgument<UserRole, string> arg = new ObjectQueryArgument<UserRole, string>();
        arg.query = getQuery();
        arg.sort = m => m.ID;
        arg.page = page;
        return EntityUtility.selectMany(arg);
    }
    /// <summary>
    /// 得到用于执行角色数据访问的ObjectQuery对象
    /// </summary>
    private static System.Data.Objects.ObjectQuery<UserRole> getQuery()
    {
        return new SJL.Entity.UserRightContext().UserRole;
    }
}
}
