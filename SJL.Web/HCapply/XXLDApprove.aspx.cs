using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJL.Bll.HCapply;
using SJL.Common.HCapply;

namespace NrcmWeb.HCapply
{
    public partial class XXLDApprove : System.Web.UI.Page
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
            HCApplyBLL hCApplyBLL = new HCApplyBLL();
            List<HCApply> lists = new List<HCApply>();
            lists = hCApplyBLL.SearchHCApplyBLL(3);
            if (lists.Count != 0)
            {
                GridView1.DataSource = lists;
                GridView1.DataBind();
            }



            else
            {
                DataTable dt = new DataTable();
                //添加表头信息
                dt.Columns.Add("SQID");
                dt.Columns.Add("petitioner");
                dt.Columns.Add("department");
                dt.Columns.Add("location");
                dt.Columns.Add("phone");
                dt.Columns.Add("time");
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
                GridView1.Rows[0].Cells[0].Text = "没有需要审批的项目";
                GridView1.Rows[0].Cells[0].Style.Add("text-align", "center");

            }

        }
    }
}