using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserRoleBLL=SJL.Bll.UserRight.UesrRoleBLL;
using SJL.Common;
using SJL.Bll.UserRight;
using SJL.Entity;
namespace SJL.Web.UserRight
{
    public partial class RoleRightPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RoleRightBLL.refreshRoleRight();
                initRoles();
            }
        }
        private void initRoles()
        {
            var list = UserRoleBLL.getAll(PageDataArgument.allData);
            list.Remove(list.Find(r => r.ID == "01"));          //不显示admin角色
            roleList.DataSource = list;
            roleList.DataBind();
            if (roleList.Items.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "addrolefirst", "<script>数据库中没有角色。请先添加角色再为其分配权限。</script>");
                return;
            }
            roleList.SelectedIndex = 0;
            bindRights();
        }
        private void bindRights()
        {
            if (roleList.SelectedIndex < 0) return;           
            string role = roleList.SelectedValue;
            hiddenRole.Value = role;
            PageDataArgument page = new PageDataArgument();
            page.refreshCount = true;
            page.pageSize = pager1.PageSize;
            page.pageIndex = pager1.CurrentPageIndex - 1;
            var list = RoleRightBLL.getByRole(role,page);
            pager1.RecordCount = page.count;
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
        protected void okButton_Click(object sender, EventArgs e)
        {
            pager1.CurrentPageIndex = 1;
            bindRights();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {           
            string newRigth="0";
            if (e.CommandName == "grant")
                newRigth = "1";
            else if (e.CommandName == "deny")
                newRigth = "0";
            else
                return;
            string id = e.CommandArgument.ToString();
            RoleRight right = new RoleRight();           
            right.ModuleID = id;
            right.TheRight = newRigth;
            right.RoleID = hiddenRole.Value;
            RoleRightBLL.update(right);
            bindRights();
        }

        protected void pager1_PageChanged(object sender, EventArgs e)
        {
            bindRights();
        }
    }
}
