using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using SJL.Bll.HCapply;
using SJL.Common.HCapply;

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
            if (Session["haocai"] != null && (Session["haocai"] as HaoCaiItem).HaoCaiInItem.Count != 0)
            {
                HaoCaiItem haoCaiItem = Session["haocai"] as HaoCaiItem;
                GridView1.DataSource = haoCaiItem.HaoCaiInItem;
                GridView1.DataBind();
            }



            else
            {
                DataTable dt = new DataTable();
                //添加表头信息
                dt.Columns.Add("SQXID");
                dt.Columns.Add("SQBM");
                dt.Columns.Add("SQKS");
                dt.Columns.Add("DYJXH");
                dt.Columns.Add("HCLX");
                dt.Columns.Add("SL");
                dt.Columns.Add("");
                //添加一个空行
                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add(dt.NewRow());
                }

                //设备空行显示内容
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

        protected void Button_TJ_Click(object sender, EventArgs e)
        {
            HCApply hcapply = new HCApply
            {
                SQID = Guid.NewGuid().ToString(),
                petitioner = SQR.Text,
                location = GSD.Text,
                phone = LXDH.Text,
                time = SJ.Text,
                state = 1
            };

            if (Session["haocai"] == null)
            {
                Response.Write("<script>alert('请输入耗材不能为空！');location='javascript:history.go(-1)';</script>");
                return;
            }

            List<HaoCaiItem> lists = (Session["haocai"] as HaoCaiItem).HaoCaiInItem;
            HCApplyDetails hCApplyDetails = new HCApplyDetails();
            HCApplyBLL hCApplyBLL = new HCApplyBLL();
            for (int i = 0; i < lists.Count; i++)
            {
                hCApplyDetails.SQID = hcapply.SQID;
                hCApplyDetails.XDID = lists[i].SQXID;
                hCApplyDetails.department = lists[i].SQBM;
                hCApplyDetails.room = lists[i].SQKS;
                hCApplyDetails.printerModel = lists[i].DYJXH;
                hCApplyDetails.consumablesModel = lists[i].HCLX;
                hCApplyDetails.number = lists[i].SL;
                hCApplyBLL.AddHCApplyDetailsBLL(hCApplyDetails);
            }

           
            hCApplyBLL.AddHCApplyBLL(hcapply);
            Response.Write("<script>alert('提交成功！');location='javascript:history.go(-1)';</script>");
        }
    }
}