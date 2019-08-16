using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SJL.Entity;
using SJL.Common;
namespace SJL.Dal.UserRight
{
    public static class ApplicationModuleDal
    {
        public static int add(ApplicationModule module)
        {
            module.URL = module.URL.ToLower();
            return EntityUtility.add<UserRightContext, ApplicationModule>(module);
        }
        public static int delete(string id)
        {
            return EntityUtility.delete(getQuery(), m => m.ID == id);
        }
        public static int update(ApplicationModule module)
        {
            module.URL = module.URL.ToLower();
            return EntityUtility.update<UserRightContext, ApplicationModule>(module);
        }
        public static ApplicationModule getByID(string id)
        {
            return EntityUtility.selectOne(getQuery(), m => m.ID == id);
        }
        public static ApplicationModule getByUrl(string url)
        {
            return EntityUtility.selectOne(getQuery(), m => m.URL == url);
        }
        public static List<ApplicationModule> getNonpublic(PageDataArgument page)
        {
            ObjectQueryArgument<ApplicationModule, string> arg = new ObjectQueryArgument<ApplicationModule, string>()
                 { query=getQuery(), sort=m=>m.ID, page=page };            
            return EntityUtility.selectMany(arg, m=>!m.IsPublic);

        }
        public static List<ApplicationModule> getAll(PageDataArgument page)
        {
            ObjectQueryArgument<ApplicationModule, string> arg = new ObjectQueryArgument<ApplicationModule, string>() 
            { query = getQuery(), sort=m=>m.ID, page=page };
            return EntityUtility.selectMany(arg);
        }
        private static System.Data.Objects.ObjectQuery<ApplicationModule> getQuery()
        {            
            return new UserRightContext().ApplicationModule;
        }
    }
}
