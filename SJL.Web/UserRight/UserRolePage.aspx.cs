using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserRoleBLL= SJL.Bll.UserRight.UesrRoleBLL;
using SJL.Entity;
using SJL.Common;
namespace SJL.Web.UserRight
{
    public partial class UserRolePage : System.Web.UI.Page
    {
        private const string newID = "*NEWID*";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindRoles();
                displyMode();
            }
        }
        /// <summary>
        /// 绑定一页角色数据到GridView
        /// </summary>
        private void bindRoles()
        {
            PageDataArgument arg = new PageDataArgument(pager1.CurrentPageIndex - 1, pager1.PageSize, true);
            var list = UserRoleBLL.getAll(arg);
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
            roleID.Text = "";
            description.Text = "";
            roleName.Text = "";            
        }
        //进入只读模式，隐藏编辑区域
        private void displyMode()
        {
            editPanel.Visible = false;
            listPanel.Visible = true;
        }
        /// <summary>
        /// 进入编辑模式，显示编辑区域
        /// </summary>
        /// <param name="id">要编辑的角色id，如果为newID则为添加新角色</param>
        private void editMode(string id)
        {
            editPanel.Visible = true;
            listPanel.Visible = false;
            hiddenID.Value = id;
            if (id == newID)
            {
                roleID.ReadOnly = false;          //如果为新增记录，则ID可修改  
                clearEdit();
            }
            else
            {
                roleID.ReadOnly = true;
                var module = UserRoleBLL.getByID(id);
                roleID.Text = module.ID;
                roleName.Text = module.Name;
                description.Text = module.Description;                
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "delete0")
            {
                UserRoleBLL.delete(id);
                bindRoles();
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
            UserRole role = new UserRole();
            role.Description = description.Text;
            role.ID = roleID.Text;
            role.Name = roleName.Text;           
            if (hiddenID.Value == newID)
                UserRoleBLL.add(role);
            else
                UserRoleBLL.update(role);
            bindRoles();
            displyMode();
        } 

        protected void pager1_PageChanged(object sender, EventArgs e)
        {
            bindRoles();
        }
    }
}
