using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data;

namespace SJL.Dal
{
    /// <summary>
    /// 对ObjectContext类的扩展
    /// </summary>
    internal static class ObjectContextExt
    {
        /// <summary>
        /// 在ObjectContext附加一个实体对象并设置对象的各个属性状态为改变
        /// </summary>
        /// <param name="context">扩展方法所扩展的类</param>
        /// <param name="objectDetached">要附加的实体对象</param>
        internal static void AttachUpdatedObject(this ObjectContext context, EntityObject objectDetached)
        {
            if (objectDetached.EntityState == EntityState.Detached)
            {
                object currentEntityInDb = null;
                if (context.TryGetObjectByKey(objectDetached.EntityKey, out currentEntityInDb))
                {
                    context.ApplyCurrentValues(objectDetached.EntityKey.EntitySetName, objectDetached);   
                    //context.ApplyPropertyChanges(objectDetached.EntityKey.EntitySetName, objectDetached);                  
                    //context.ApplyReferencePropertyChanges((IEntityWithRelationships)objectDetached,
                    //    (IEntityWithRelationships)currentEntityInDb); //Custom extensor method
                }
                else
                {
                    throw new ObjectNotFoundException();
                }
            }
        }



       
        /// <summary>
        /// 设置一个实体对象的属性状态为发生改变
        /// </summary>
        /// <param name="context">扩展方法所扩展的类</param>
        /// <param name="entity">要设置的实体对象</param>
        /// <param name="excludeProperties">不设置为改变状态的属性列表</param>
        internal static void SetEntityStateToModified(this ObjectContext context, IEntityWithKey entity, params string[] excludeProperties)
        {
            var stateEntry = context.ObjectStateManager.GetObjectStateEntry(entity.EntityKey);
            var propertyNameList = stateEntry.CurrentValues.DataRecordInfo.FieldMetadata.Select(pn => pn.FieldType.Name);
            bool exclude = (excludeProperties!=null) && (excludeProperties.Length>0);         
            List<string> list=null;
            if (exclude)
            {
                list = excludeProperties.ToList();
                list.Sort();
            }
            foreach (var propName in propertyNameList)
            {  
                if(exclude)
                    if (list.BinarySearch(propName)>=0)
                        continue;
                stateEntry.SetModifiedProperty(propName);
            }           
        }
    
        #region 废弃的方法
        //internal static void ApplyReferencePropertyChanges(this ObjectContext context, 
        //    IEntityWithRelationships newEntity,IEntityWithRelationships oldEntity)
        //{
        //    foreach (var relatedEnd in oldEntity.RelationshipManager.GetAllRelatedEnds())
        //    {
        //        var oldRef = relatedEnd as EntityReference;
        //        if (oldRef != null)
        //        {
        //            // this related end is a reference not a collection
        //            var newRef = newEntity.RelationshipManager.GetRelatedEnd(oldRef.RelationshipName, oldRef.TargetRoleName) as EntityReference;
        //            oldRef.EntityKey = newRef.EntityKey;
        //        }
        //    } 
        //}
        #endregion 
    
    }
}
