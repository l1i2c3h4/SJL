using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SJL.Entity;
using System.IO;
using SJL.Bll.UserRight;
namespace SJL.Web.HttpCode
{
    public static class AdminTool
    {
        /// <summary>
        /// 根据网站中的页面自动生成模块信息
        /// </summary>
        public static void genereateModules()
        {
            string path = HttpContext.Current.Server.MapPath("~");
            generate( new DirectoryInfo(path));
        }
        static int n = 1;
        /// <summary>
        /// 递归方法，根据目录下的aspx文件生成模块信息
        /// </summary>
        /// <param name="directory"></param>
        private static void generate(DirectoryInfo directory)
        {            
            FileInfo[] files = directory.GetFiles("*.aspx");            //得到目录下的所有aspx文件
            foreach (var item in files)
            {
                if (ApplicationModuleBLL.getByUrl(item.Name) == null)   //如果数据库不存在此页面则添加
                {
                    ApplicationModule m = new ApplicationModule();
                    m.ID = string.Format("{0:00}", n++);
                    m.Name = "自动生成的模块";
                    m.Description = "自动生成的页面，没有描述。";
                    m.URL = item.Name;
                    ApplicationModuleBLL.add(m);
                }
            }
            DirectoryInfo[] dirs = directory.GetDirectories();
            foreach (var item in dirs)
            {
                generate(item);                                         //递归进入下一级目录
            }
        }
    }
}
