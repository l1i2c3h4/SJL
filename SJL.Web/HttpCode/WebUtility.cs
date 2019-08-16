using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SJL.Web.HttpCode
{
    public static class WebUtility
    {

        private const string SessionUser = "thisuser";   //登录用户      
        
        public static SJL.Entity.User currentUser
        {
            get
            {
                if (HttpContext.Current == null) return null;
                return HttpContext.Current.Session[SessionUser] as global::SJL.Entity.User;
            }
            set
            {
                HttpContext.Current.Session[SessionUser] = value;
            }
        }

        /// <summary>
        /// bind the DropDownList with data from a dictionary table.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="table"></param>
        public static void bindListWithDictionary(DropDownList list,string table)
        {
            throw new NotImplementedException();
            /*            
            list.DataValueField = "id";
            list.DataTextField = "name";
            list.DataSource = global::SJL.Bll.SmallDictionaryBLL.getAll(table);
            list.DataBind();
             */ 
        }
        /// <summary>
        /// clear the content of controls in the specified page
        /// </summary>
        /// <param name="form"></param>
        public static void clearFormInput(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = "";
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control is DropDownList)
                    ((DropDownList)control).SelectedIndex = 0;
                else if (control.Controls.Count > 0)
                    clearFormInput(control);
            }
        }
        /// <summary>
        /// close a web model dialog and return a value
        /// </summary>
        /// <param name="page">the dialog page (.aspx)</param>
        /// <param name="returnValue">json return value</param>
        public static void closeModelDialog(Page page,string returnValue)
        {
            string s = "window.returnValue = "+returnValue+";  window.close();";
            s = "<script type='text/javascript'>" + s + "</script>";
            page.ClientScript.RegisterStartupScript(page.GetType(), "closeDialog", s);
        }
    }
}
