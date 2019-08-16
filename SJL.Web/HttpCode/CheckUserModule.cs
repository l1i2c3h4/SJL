using System;
using System.Web;
using SJL.Entity;
using SJL.Web.HttpCode;

namespace SJL.Web.HttpCode
{
    public class CheckUserModule : IHttpModule
    {

        private static string loginPage = "登陆.aspx";
        #region IHttpModule Members
        public void Dispose()
        {
            //此处放置清除代码。
        }

        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += new EventHandler(checkUserRight);
        }

        /// <summary>
        /// 检测用户权限
        /// </summary>
        void checkUserRight(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;          // 获取应用程序            
            string url = HttpContext.Current.Request.Url.ToString();       // 获取Url
            int start = url.LastIndexOf('/') + 1;                             //查找URL中最后一个/的位置
            int end = url.IndexOf('?', start);                                 //查找URL中？位置
            string requestPage = null;
            if (end < 0) end = url.Length - 1;
            requestPage = url.Substring(start, end - start + 1);               //得到所请求的页面
            requestPage = requestPage.ToLower();
            if (requestPage == loginPage) return;
            if (!isProtectedResource(requestPage)) return;
            User user = SJL.Web.HttpCode.WebUtility.currentUser;              //获得当前用户          
            if (user == null)
            {
                application.Response.Redirect("~/登陆.aspx");
                return;
            }
            if (SJL.Bll.UserRight.UserBLL.isAdmin(user)) return;
            //检测用户权限
            if (!SJL.Bll.UserRight.RoleRightBLL.canAccessPage(user.RoleID, requestPage))
                application.Response.Redirect("~/UserRight/AccessDeny.aspx");
        }

        /// <summary>
        /// 判断页面是否为受权限管理保护的资源（如Aspx等）
        /// </summary>
        /// <param name="page">所请求的页面</param>
        /// <returns>是否受保护</returns>
        bool isProtectedResource(string page)
        {
            page = page.ToLower();
            System.Collections.Generic.List<String> protectedFiles =
            new System.Collections.Generic.List<string>();            //受保护资源的扩展名          
            protectedFiles.AddRange(new string[] { ".aspx", ".asmx", ".ashx" });
            string found = protectedFiles.Find(s => page.EndsWith(s));
            if (found == null)
                return false;
            ApplicationModule module = SJL.Bll.UserRight.ApplicationModuleBLL.getByUrl(page);
            if (module == null) return false;
            return !module.IsPublic;                                        //如果页面为公共模块则不受保护            
        }
        #endregion

        public void OnLogRequest(Object source, EventArgs e)
        {
            //可以在此放置自定义日志记录逻辑
        }


    }
}
