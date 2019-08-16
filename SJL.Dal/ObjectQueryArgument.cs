using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Linq.Expressions;
using SJL.Common;
using System.Data.Objects.DataClasses;

namespace SJL.Dal
{
    /// <summary>
    /// used in EntityUtility.selectMany method, as an argument
    /// </summary>
    /// <typeparam name="T">elementy type</typeparam>
    /// <typeparam name="TSortKey">sort key type</typeparam>
    internal class ObjectQueryArgument<T,TSortKey>
        where T:IEntityWithKey
    {
        internal ObjectQueryArgument()
        { 
            disposeAfterQuery = true;
            descending = false;
        }
        internal ObjectQuery<T> query { get; set; }
        internal Expression<Func<T, TSortKey>> sort{get;set;}
        internal bool descending { get; set; }
        internal PageDataArgument page { get; set; }        
        internal ObjectQueryArgument(ObjectQuery<T> theQuery, Expression<Func<T,TSortKey>> sortExp,PageDataArgument pageArg)
        {
            descending=false;
            query=theQuery;
            sort=sortExp;
            page=pageArg;
        }
        //执行完查询后是否释放ObjectContext           
        internal bool disposeAfterQuery { get; set; }         
    }
}
