using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJL.Web.HttpCode;
using SJL.Bll.UserRight;

namespace NrcmWeb
{
    public partial class 登陆 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string u = userName.Text;
            string p = password.Text;
            var user = UserBLL.getByID(u);
            if (user != null &&user.Password == p)
            {
                WebUtility.currentUser = user;
                Response.Redirect("~/Default/Default.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "loginerror", "<script>alert('用户名或密码有误，登录失败！');</script>");
            }
        }
    }
}