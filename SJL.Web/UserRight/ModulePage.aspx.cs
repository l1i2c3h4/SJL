using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJL.Common;
using SJL.Bll.UserRight;
using SJL.Entity;
using SJL.Web.HttpCode;
namespace SJL.Web.UserRight
{
    public partial class ModulePage : System.Web.UI.Page
    {
        private const string newID = "*NEWID*";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //自动生成模块按钮仅管理员admin可见
                try
                {
                    generateButton.Visible = HttpCode.WebUtility.currentUser.ID == "admin";
                }
                catch
                {
                    generateButton.Visible = false;
                }
                pager1.CurrentPageIndex = 1;
                bindModules();
                displyMode();              
            }
        }
        private void bindModules()
        {
            PageDataArgument page = new PageDataArgument();
            page.refreshCount = true;
            page.pageSize = pager1.PageSize;
            page.pageIndex = pager1.CurrentPageIndex - 1;
            var list = ApplicationModuleBLL.getAll(page);
            pager1.RecordCount = page.count;
            GridView1.DataSource = list;
            GridView1.DataBind();
            
        }        
        protected void addButton_Click(object sender, EventArgs e)
        {
            editMode(newID);
        }
        private void clearEdit()
        {
            moduleID.Text = "";
            description.Text = "";
            moduleName.Text = "";
            url.Text = "";
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
                moduleID.ReadOnly = false;
                clearEdit();
            }
            else
            {
                moduleID.ReadOnly = true;
                var module = ApplicationModuleBLL.getByID(id);
                moduleID.Text = module.ID;
                moduleName.Text = module.Name;
                description.Text = module.Description;
                isPublic.Checked = module.IsPublic;
                url.Text = module.URL;
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "delete0")
            {
                ApplicationModuleBLL.delete(id);
                bindModules();
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
            ApplicationModule module = new ApplicationModule();
            module.Description = description.Text;
            module.ID = moduleID.Text;
            module.Name = moduleName.Text;
            module.URL = url.Text;
            module.IsPublic = isPublic.Checked;
            if (hiddenID.Value == newID)
                ApplicationModuleBLL.add(module);
            else
                ApplicationModuleBLL.update(module);
            bindModules();
            displyMode();
        }
        protected void cancelButton_Click1(object sender, EventArgs e)
        {
            displyMode();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bindModules();
        }

        protected void pager1_PageChanged(object sender, EventArgs e)
        {
            bindModules();
        }

        protected void generateButton_Click(object sender, EventArgs e)
        {
            AdminTool.genereateModules();
            bindModules();
        }        
    }
}
