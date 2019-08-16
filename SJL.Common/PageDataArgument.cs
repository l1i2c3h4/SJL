using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SJL.Common
{
    /// <summary>
    /// 进行分页数据查询时的分页参数
    /// </summary>
    public class PageDataArgument
    {
        #region 字段
        public int pageIndex=0;                                         //页码
        public int pageSize = 10;                                       //页面大小
        public bool refreshCount = false;                               //是否更新记录总数
        public int count = -1;                                          //记录总数
        private static PageDataArgument defaultArg = new PageDataArgument();//默认分页参数
        private static PageDataArgument allDataArg 
            = new PageDataArgument() {  pageSize = 99999 };                 //得到所有数据的分页参数
        #endregion

        #region 构造函数
        public PageDataArgument() { }
        public PageDataArgument(int index, int size, bool getCount)
        {
            pageIndex = index;
            pageSize = size;
            refreshCount = getCount;
        }
        #endregion

        #region 属性
        public static PageDataArgument allData 
        { get { return allDataArg; } }
        public static PageDataArgument defaultValue
        {  get { return defaultArg; }}
        #endregion

    }
}
