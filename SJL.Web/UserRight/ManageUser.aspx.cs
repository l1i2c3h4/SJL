using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJL.Bll.UserRight;
using User = SJL.Entity.User;
using UserRoleBLL = SJL.Bll.UserRight.UesrRoleBLL;
using SJL.Common;
namespace SJL.Web.Default
{
    public partial class ManageUser : System.Web.UI.Page
    {
        private const string newID = "*NEWID*";        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initData();
                displyMode();
            }
        }
        private void initData()
        {
            bindUsers();     
            var roles = UserRoleBLL.getAll(SJL.Common.PageDataArgument.allData);    //获取角色列表
            roleList.DataSource = roles;
            roleList.DataBind();                                                    //绑定角色列表
            roleList.Items.Insert(0,new ListItem("--请选择--", "-1"));
        }
        //绑定用户列表
        private void bindUsers()
        {
            PageDataArgument arg = new PageDataArgument(pager1.CurrentPageIndex - 1, pager1.PageSize, true);
            var list = UserBLL.getAll(arg);
            pager1.RecordCount = arg.count;
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
        protected void addButton_Click(object sender, EventArgs e)
        {
            editMode(newID);
        }
        private void clearEdit()
        {
            userid.Text = "";
            roleList.SelectedIndex = 0;
            userName.Text = "";
        }
        private void displyMode()
        {
            editPanel.Visible = false;
            listPanel.Visible = true;
        }
        private void editMode(string id)
        {
            editPanel.Visible = true;
            listPanel.Visible = false;
            hiddenID.Value = id;
            if (id == newID)
            {
                userid.ReadOnly = false;
                clearEdit();
            }
            else
            {
                userid.ReadOnly = true;
                var user = UserBLL.getByID(id);
                userid.Text = user.ID;
                userName.Text = user.UserName;
                roleList.SelectedValue = user.RoleID;
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {            
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "delete0")
            {
                UserBLL.delete(id);
                bindUsers();
            }
            else if (e.CommandName == "edit0")
            {
                editMode(id);
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            displyMode();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.RoleID = roleList.SelectedValue;
            if (user.RoleID == "-1")
                return;
            user.ID = userid.Text;
            user.UserName = userName.Text;
            user.Department = department.Text;
            if (hiddenID.Value == newID)
                UserBLL.add(user);
            else
                UserBLL.update(user);
            bindUsers();
            displyMode();
        }

        protected void cancelButton_Click1(object sender, EventArgs e)
        {
            displyMode();
        }

        protected void pager1_PageChanged(object sender, EventArgs e)
        {
            bindUsers();
        }        
    }
}
