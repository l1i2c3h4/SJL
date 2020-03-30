using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SJL.Bll.HCapply;
using SJL.Common.HCapply;

namespace NrcmWeb.HCapply
{
    public partial class XXLD : System.Web.UI.Page
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

        protected void pass_Click(object sender, EventArgs e)
        {
            string s = TB_XXLDview.Text;
            int state = 4;
            string SQID = Request.QueryString["id"];
            hCApplyBLL.UpdateHCApplyBYSQID3BLL(SQID, s, state);
            Response.Redirect("XXLDApprove.aspx");
        }

        protected void noPass_Click(object sender, EventArgs e)
        {
            string s = TB_XXLDview.Text;
            int state = 0;
            string SQID = Request.QueryString["id"];
            hCApplyBLL.UpdateHCApplyBYSQID3BLL(SQID, s, state);
            Response.Redirect("XXLDApprove.aspx");
        }
    }
}