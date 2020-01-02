using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NrcmWeb.HCapply
{
    public partial class SQBMApprove : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bind();
            }
        }

        public void bind() 
        {
            List<Class2> test1 = new List<Class2>();
            Class2 c2 = new Class2();
            c2.SQID = "1";
            c2.SQR = "李四";
            c2.GSD = "桂林";
            c2.LXDH = "3808949";
            c2.SJ = "2020年1月2日";
            test1.Add(c2);

            GridView1.DataSource = test1;
            GridView1.DataBind();
        }
    }
}