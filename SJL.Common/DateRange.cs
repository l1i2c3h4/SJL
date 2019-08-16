using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SJL.Common
{
    /// <summary>
    /// 日期范围类，用于指定查询时的起止日期
    /// </summary>
    public class DateRange
    {
        //以下两个字段定义了起始日期（含）和结束日期（含）
        public DateTime from;
        public DateTime to;       
        /// <summary>
        /// 根据两个日期（忽略时间）生成日期范围
        /// </summary>
        /// <param name="day1">起始日期</param>
        /// <param name="day2">终止日期</param>
        /// <returns></returns>
        /// <remarks>用户在查询时习惯于输入两个日期（不含时间），而查询时需要查询包括起止日期在内的时间范围，
        /// 如输入2010-1-1和2010-1-31，
        /// 则得到的日期范围是 2010-1-1 00:00:00至2010-1-31 23:59:59
        /// 这个方法能够方便提根据日期生成用户需要的时间范围
        /// </remarks>
        public static DateRange between2Date(DateTime day1, DateTime day2)
        {
            DateRange a = new DateRange();
            a.from = day1.Date;
            a.to = day2.Date.AddDays(1).AddSeconds(-1);
            return a;
        }
        //功能同上，根据两日期生成时间范围，但是两个日期参数是string类型
        public static DateRange between2Date(string day1, string day2)
        {
            return between2Date(DateTime.Parse(day1), DateTime.Parse(day2));
        }
    }
}
