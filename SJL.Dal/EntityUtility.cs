using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data;
using System.Data.Objects.DataClasses;
using System.Linq.Expressions;
using SJL.Common;

namespace SJL.Dal
{
    /// <summary>
    /// 实体框架工具
    /// </summary>
    /// <remarks>.NET Framework 4.0版</remarks>
    internal static class EntityUtility
    { 
        #region internal methods

        #region most often used methods
        internal static int add<TContext,TEntity>(TEntity entity)
            where TContext:ObjectContext,new() 
            where TEntity:EntityObject
        {
            TContext context = new TContext();
            int n= add(context, entity);
            context.Dispose();
            return n;
        }

        internal static int update<TContext, TEntity>(TEntity entity, params string[] excludeProperties)
            where TContext : ObjectContext, new()
            where TEntity : EntityObject
        {
            TContext context = new TContext();
            int n = update(context, entity,excludeProperties);
            context.Dispose();
            return n;
        }

        internal static int delete<T>(ObjectQuery<T> query, Expression<Func<T, bool>> predicate)
            where T : EntityObject
        { return delete(query, predicate, true); }

        internal static T selectOne<T>(ObjectQuery<T> query, Expression<Func<T, bool>> predicate)
            where T : EntityObject
        { return selectOne(query, predicate,true); }

        //internal static List<T> selectMany<T, TSortKey>(ObjectQuery<T> query, Expression<Func<T, TSortKey>> sort, 
        //PageDataArgument page, params Expression<Func<T, bool>>[] predicate)
        //where T : EntityObject
        //{
        //    return selectMany(query, sort, false, page, predicate);
        //}
        //ObjectQuery<T> query, Expression<Func<T,TSortKey>> sort,bool sortDesc,
        //    PageDataArgument page,bool dispose=true,params Expression<Func<T,bool>>[] predicate
        internal static List<T> selectMany<T, TSortKey>(ObjectQueryArgument<T, TSortKey> arg, params Expression<Func<T, bool>>[] predicate)
            where T:EntityObject
        {
            return selectMany<T, TSortKey>(arg.query, arg.sort, arg.descending, arg.page, arg.disposeAfterQuery, predicate);
        }        
        #endregion

        #region do not use these methods unless you have strong reasons to do so
       
        internal static int add<T>(ObjectContext context, T entity) where T:EntityObject
        {
            return add(context, entity.GetType().Name, entity);
        }

        internal static int update<T>(ObjectContext context, T entity, params string[] excludeProperties) where T : EntityObject
        {
            entity.EntityKey = context.CreateEntityKey(entity.GetType().Name, entity);
            context.Attach(entity);
            context.SetEntityStateToModified(entity,excludeProperties);            
            int n = context.SaveChanges();
            detachEntity(context, entity);
            return n;
        }

        internal static int delete<T>(ObjectQuery<T> query,Expression<Func<T, bool>> predicate,bool dispose)
            where T:EntityObject
        {
            EntityObject entity = query.Where(predicate).FirstOrDefault();
            if (entity == null)
                return 0;
            query.Context.DeleteObject(entity);            
            int n=query.Context.SaveChanges();
            if (dispose)
                query.Context.Dispose();
            return n;
        }

        internal static T selectOne <T> (ObjectQuery<T> query, Expression<Func<T, bool>> predicate,bool dispose) 
            where T : EntityObject
        {
            T entity = query.Where(predicate).FirstOrDefault();
            query.MergeOption = MergeOption.NoTracking;
            if (entity == null)
            {
                if (dispose)
                    query.Context.Dispose();
                return default(T);
            }
            detachAndRemoveEntityKey(query.Context,entity);
            if (dispose)
                query.Context.Dispose();
            return entity;
        }
        internal static List<T> selectMany<T,TSortKey>(ObjectQuery<T> query, Expression<Func<T,TSortKey>> sort,bool sortDesc,
            PageDataArgument page,bool dispose,params Expression<Func<T,bool>>[] predicate) 
            where T:EntityObject
        {
            query.MergeOption = MergeOption.NoTracking;
            IQueryable<T> q = query;
            for (int i = 0; i < predicate.Length; i++)
            {
                q = q.Where(predicate[i]);
            }            
            q=sortDesc?q.OrderByDescending(sort):q.OrderBy(sort);            
            if (page.refreshCount)
                page.count = q.Count();
            var list = q.Skip(page.pageIndex * page.pageSize).Take(page.pageSize).ToList();
            //detachEntity(query.Context, list);
            if (dispose)
                query.Context.Dispose();
            return list;
        } 
        //internal static List<T> selectMany<T, TSortKey>(ObjectQuery<T> query, Expression<Func<T, TSortKey>> sort,bool sortDesc,
        //PageDataArgument page, params Expression<Func<T, bool>>[] predicate)
        //where T : EntityObject
        //{ return selectMany<T, TSortKey>(query, sort,sortDesc, page, true, predicate); }
        #endregion
             
        #endregion
         
        #region AS private methods 
        //these methods should not be used outsied this class although they are interanl, which is a backward compatibility
        internal static void detachEntity(ObjectContext context, EntityObject entity)
        {
            detachAndRemoveEntityKey(context, entity);
        }
        internal static void detachEntity<T>(ObjectContext context, List<T> list) where T : EntityObject
        {
            list.ForEach(item =>detachAndRemoveEntityKey(context, item));
        }
        #endregion
       
        #region private methods
        private static int add<T>(ObjectContext context, string entitySetName, T entity) where T : EntityObject
        {
            context.AddObject(entitySetName, entity);
            int n = context.SaveChanges();
            detachEntity(context, entity);
            return n;
        }
        private static void detachAndRemoveEntityKey(ObjectContext context, EntityObject entity)
        {            
            if(entity.EntityState!=EntityState.Detached)
                context.Detach(entity);
            entity.EntityKey = null;
        }
        #endregion

        #region deleted code
        /*
         * Reversion History
         * ----------------------------------------
         * It is inconvinient to write where and order-by in this function. Rather, it would be better to write these with the LINQ.
         * Use the LINQ to get a list, then use detachEntity method to detach the list from the context.
         * 
         */
        // [Obsolete("Obsolete Method. Use LINQ on the context instead. (Sun Ji Lei)",true)]
        //internal static List<T> getDetachedList<T>(ObjectQuery<T> query, System.Linq.Expressions.Expression<Func<T, bool>> ex) where T : EntityObject
        //{
        //    var list = query.Where(ex).ToList();
        //    list.ForEach(o => { query.Context.Detach(o); o.EntityKey = null; });
        //    return list;
        //}
        // [Obsolete("Obsolete Method. Use LINQ on the context instead. (Sun Ji Lei)", true)]
        //internal static List<T> getDetachedList<T,TKey>
        //    (ObjectQuery<T> query, System.Linq.Expressions.Expression<Func<T, bool>> ex, System.Linq.Expressions.Expression<Func<T, TKey>> sort)
        //    where T : EntityObject
        //{
        //    var list = query.Where(ex).OrderBy(sort).ToList();
        //    list.ForEach(o => { query.Context.Detach(o); o.EntityKey = null; });
        //    return list;
        //} 
        #endregion

    }
}
