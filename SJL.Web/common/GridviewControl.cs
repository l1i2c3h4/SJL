﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace NrcmWeb.common
{
    public class GridviewControl
    {
        //当Gridview数据为空时显示的信息
        private static string EmptyText = "没有记录";

        public GridviewControl()
        {

        }

        ///<summary>
        ///防止PostBack后Gridview不能显示
        ///</summary>
        ///<param name="gridview"></param>
        public static void ResetGridView(GridView gridview)
        {
            //如果数据为空则重新构造Gridview
            if (gridview.Rows.Count == 1 && gridview.Rows[0].Cells[0].Text == EmptyText)
            {
                int columnCount = gridview.Columns.Count;
                gridview.Rows[0].Cells.Clear();
                gridview.Rows[0].Cells.Add(new TableCell());
                gridview.Rows[0].Cells[0].ColumnSpan = columnCount;
                gridview.Rows[0].Cells[0].Text = EmptyText;
                gridview.Rows[0].Cells[0].Style.Add("text-align", "center");
            }
        }

        ///<summary>
        ///绑定数据到GridView，当表格数据为空时显示表头
        ///</summary>
        ///<param name="gridview"></param>
        ///<param name="table"></param>
        public static void GridViewDataBind(GridView gridview, DataTable table)
        {
            //记录为空重新构造Gridview
            if (table.Rows.Count == 0)
            {
                table = table.Clone();
                table.Rows.Add(table.NewRow());
                gridview.DataSource = table;
                gridview.DataBind();
                int columnCount = table.Columns.Count;
                gridview.Rows[0].Cells.Clear();
                gridview.Rows[0].Cells.Add(new TableCell());
                gridview.Rows[0].Cells[0].ColumnSpan = columnCount;
                gridview.Rows[0].Cells[0].Text = EmptyText;
                gridview.Rows[0].Cells[0].Style.Add("text-align", "center");
            }
            else
            {
                //数据不为空直接绑定
                gridview.DataSource = table;
                gridview.DataBind();
            }

            //重新绑定取消选择
            gridview.SelectedIndex = -1;
        }
    }
}