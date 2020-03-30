using System;
using System.Collections.Generic;
using SJL.Bll.HCapply;
using SJL.Common.HCapply;

namespace NrcmWeb.HCapply
{
    public partial class HCSearchDetails : System.Web.UI.Page
    {
        private HCApplyBLL hCApplyBLL = new HCApplyBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string SQID = Request.QueryString["id"];
                databind(SQID);
            }

        }

        protected void databind(string SQID)
        {
            HCApply hCApply = hCApplyBLL.SearchHCApplyBYSQIDBLL(SQID);
            List<HCApplyDetails> lists = hCApplyBLL.SearchHCApplyDetailsBYSQIDBLL(SQID);
            SQR.Text = hCApply.petitioner;
            GSD.Text = hCApply.location;
            LXDH.Text = hCApply.phone;
            SQBM1.Text = hCApply.department;
            SQR2.Text = hCApply.petitioner;
            SQSJ.Text = hCApply.time;
            SQBMview.Text = hCApply.SQBMview;
            SQBMtime.Text = hCApply.SQBMtime;
            XXGLYview.Text = hCApply.XXGLYview;
            XXGLYtime.Text = hCApply.XXGLYtime;
            XXLDview.Text = hCApply.XXLDview;
            XXLDtime.Text = hCApply.XXLDtime;
            GridView1.DataSource = lists;
            GridView1.DataBind();

        }
    }
}