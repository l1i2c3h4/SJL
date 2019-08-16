using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal0 = SJL.Dal.UserRight.ApplicationModuleDal;
using SJL.Entity;
using SJL.Common;
namespace SJL.Bll.UserRight
{
    public static class ApplicationModuleBLL
    {
        public static int add(ApplicationModule module)
        {
            return Dal0.add(module);
        }
        public static int delete(string id)
        {
            return Dal0.delete(id);
        }
        public static int update(ApplicationModule module)
        {
            return Dal0.update(module);
        }
        public static ApplicationModule getByID(string id)
        {
            return Dal0.getByID(id);
        }
        public static ApplicationModule getByUrl(string url)
        {
            return Dal0.getByUrl(url);
        }
        public static List<ApplicationModule> getAll(PageDataArgument page)
        {
            return Dal0.getAll(page);
        }
        public static List<ApplicationModule> getNonpublic(PageDataArgument page)
        { return Dal0.getNonpublic(page); }
    }
}
