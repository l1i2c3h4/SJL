using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJL.Web.HttpCode;
using SJL.Bll.UserRight;

namespace SJL.Web.UserRight
{
    public partial class ChangePassPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            global::SJL.Entity.User user = global::SJL.Web.HttpCode.WebUtility.currentUser;
            if (user.Password != newPass2.Text)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "errorpassword", "<script>alert('输入的原密码不正确！');</script>");
                return;
            }
            user.Password = newPass1.Text.Trim();
            UserBLL.changePassword(user);            
            this.ClientScript.RegisterStartupScript(this.GetType(), "success", "<script>alert('密码修改成功！');</script>");
        }
    }
}
