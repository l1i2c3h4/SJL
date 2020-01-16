using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NrcmWeb.HCapply
{
    public partial class HCapplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }



        }

        public void bindData()
        {  
            if (Session["haocai"] != null)
            {
                HaoCaiItem haoCaiItem = Session["haocai"] as HaoCaiItem;
                GridView1.DataSource = (Session["haocai"] as HaoCaiItem).HaoCaiInItem;
                GridView1.DataBind();
            }
             


            else 
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("SQXID");
                dt.Columns.Add("SQBM");
                dt.Columns.Add("SQKS");
                dt.Columns.Add("DYJXH");
                dt.Columns.Add("HCLX");
                dt.Columns.Add("SL");

                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add(dt.NewRow());
                }

                GridView1.DataSource = dt;
                GridView1.DataBind();
                int columnCount = dt.Columns.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columnCount;
                GridView1.Rows[0].Cells[0].Text = "没有记录";
                GridView1.Rows[0].Cells[0].Style.Add("text-align", "center");

            }




            //List<Class1> test1 = new List<Class1>();
            //Class1 cl = new Class1();
            //cl.SQXID = "1";
            //cl.SQBM = "信息工程部";
            //cl.DYJXH = "联想7450";
            //cl.HCLX = "硒鼓";
            //cl.SL = "1";
            //cl.SQKS = "南宁运维室";
            //test1.Add(cl);

            //DataTable table = new DataTable("测试表");
            //table.Columns.Add("SQXID", typeof(string));
            //table.Columns.Add("SQBM", typeof(string));
            //table.Columns.Add("SQKS", typeof(string));
            //table.Columns.Add("DYJXH", typeof(string));
            //table.Columns.Add("HCLX", typeof(string));
            //table.Columns.Add("SL", typeof(string));
            //table.Rows.Add(new object[] { "1", "信息工程部", "南宁运维室", "联想7450", "硒鼓", "5" });

            //GridView1.DataSource = test1;
            //GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HaoCaiItem haoCaiItem = Session["haocai"] as HaoCaiItem;
            List<HaoCaiItem> lists = (Session["haocai"] as HaoCaiItem).HaoCaiInItem;
            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].SQXID == Convert.ToInt32(e.Keys[0].ToString()))
                {
                    lists.Remove(lists[i]);
                }

            }

            bindData();

        }

        protected void addHC_Click(object sender, EventArgs e)
        {
            int sqxid;
            if (Session["ID"] == null)
            {
                sqxid = 1;
            }

            else
            {
                sqxid = Convert.ToInt32(Session["ID"]) + 1;
            }
            Session["ID"] = sqxid;

            string sqbm = SQBM.Text;
            string sqks = SQKS.Text;
            string dyjxh = DYJXH.Text;
            string hclx = HCLX.Text;
            string sl = SL.Text;

            if (Session["haocai"] == null)
                Session["haocai"] = new HaoCaiItem();
            HaoCaiItem haoCaiItem = Session["haocai"] as HaoCaiItem;
            haoCaiItem.addHaoCai(sqxid, sqbm, sqks, dyjxh, hclx, sl);
            bindData();

        }
    }
}