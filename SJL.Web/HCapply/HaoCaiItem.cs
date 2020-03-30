using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NrcmWeb.HCapply
{
    public class HaoCaiItem
    {
        public HaoCaiItem() { }
        public int SQXID { get; set; }
        public string SQKS { get; set; }
        public string DYJXH { get; set; }
        public string HCLX { get; set; }
        public string SL { get; set; }

        private List<HaoCaiItem> Items = new List<HaoCaiItem>();

        public List<HaoCaiItem> HaoCaiInItem
        {
            get
            {
                return Items;
            }
        }

        public void addHaoCai(int SQXID, string SQKS,string DYJXH,string HCLX,string SL)
        {

            HaoCaiItem HaoCai = new HaoCaiItem
            {

                SQXID = SQXID,
                SQKS = SQKS,
                DYJXH = DYJXH,
                HCLX = HCLX,
                SL = SL
            };

            if (HaoCai != null)
            {
                Items.Add(HaoCai);
            }
        }
    }
}