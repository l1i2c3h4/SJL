using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace NrcmWeb.耗材申领
{
    public partial class 耗材申请 : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bind();
            }



        }

        public void Bind()
        {
            List<Class1> test1 = new List<Class1>();
            Class1 cl = new Class1();
            cl.SQBM = "信息工程部";
            cl.DYJXH = "联想7450";
            cl.HCLX = "硒鼓";
            cl.SL = "1";
            cl.SQKS = "南宁运维室";
            test1.Add(cl);

            DataTable table = new DataTable("测试表");
            table.Columns.Add("SQBM", typeof(string));
            table.Columns.Add("SQKS", typeof(string));
            table.Columns.Add("DYJXH", typeof(string));
            table.Columns.Add("HCLX", typeof(string));
            table.Columns.Add("SL", typeof(string));
            table.Rows.Add(new object[] { "信息工程部", "南宁运维室","联想7450","硒鼓","5" });

            GridView1.DataSource = test1;
            GridView1.DataBind();

        }

        
    }
}