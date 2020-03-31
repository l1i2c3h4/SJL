using SJL.Bll.HCapply;
using SJL.Common.HCapply;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NrcmWeb.HCapply
{
    public partial class HCSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData(null,null);
            }
        }

        public void bindData(string sortField, string sort)
        {
            HCApplyBLL hCApplyBLL = new HCApplyBLL();
            List<HCApply> lists = new List<HCApply>();
            lists = hCApplyBLL.HCSearchHCApplyBLL(sortField, sort);
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
                GridView1.Rows[0].Cells[0].Text = "没有历史记录";
                GridView1.Rows[0].Cells[0].Style.Add("text-align", "center");

            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int state = (int)DataBinder.Eval(e.Row.DataItem, "state");
               

                if (state == 1)
                {
                    e.Row.Cells[6].Text = "等待申请部门领导审核";
                }
                if (state == 2)
                {
                    e.Row.Cells[6].Text = "等待耗材管理员审核";
                }
                if (state == 3)
                {
                    e.Row.Cells[6].Text = "等待信息工程部领导审核";
                }

                if (state == 4)
                {
                    e.Row.Cells[6].Text = "审核通过";
                }

                if (state == 0)
                {
                    e.Row.Cells[6].Text = "审核不通过";
                }
            }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            GridView1.EditIndex = -1;
            if (ViewState["sortColumn"] == null)
            {

                ViewState["sortColumn"] = e.SortExpression.ToString();
                ViewState["sortDirection"] = "ASC";

            }
            else
            {
                if (ViewState["sortDirection"].ToString() == "ASC")
                {
                    ViewState["sortDirection"] = "DESC";
                }
                else
                {
                    ViewState["sortDirection"] = "ASC";
                }

            }
            string sort = ViewState["sortDirection"].ToString();
            bindData(e.SortExpression, sort);
        }
    }
}