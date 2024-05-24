using System;
using System.Linq.Expressions;
using NGConnection.Interfaces;
using NGEntity.Models;
using NGEntity.Interfaces;
using NGConnection.Models;
using System.Data.Common;

namespace NGEntity;

//public abstract class EntityCcaJoin : EntityData
//{
//    internal EntityCcaJoin(IConnection connection, IEntity entity) : base(connection, entity) { }
//    internal EntityCcaJoin(IConnection connection) : base(connection) { }

//    public bool Execute() => new EntityCcaCommit(_connection).Execute();
//}
//public class EntityCcaJoin<TSource1> : EntityCcaJoin, IEntityCcaJoin<TSource1>
//{
//    internal EntityCcaJoin(IConnection connection, IEntity entity) : base(connection, entity) { }
//    internal EntityCcaJoin(IConnection connection) : base(connection) { }

//    public IEntityCcaJoin<TSource1, TEntityRight> InnerJoin<TEntityRight>(
//            Expression<Func<TSource1, TEntityRight, bool>> expression)
//                where TEntityRight : IEntity
//    { 
//        return default; 
//    }

//    public IEntityCcaCommit Where(Expression<Func<TSource1, bool>> expression) => 
//        new EntityCcaWhere<TSource1>(_connection).Where(expression);
//}
//public class EntityCcaJoin<TSource1, TSource2> : 
//    EntityCcaJoin, IEntityCcaJoin<TSource1, TSource2>
//{
//    internal EntityCcaJoin(IConnection connection, IEntity entity) : base(connection, entity) { }
//    internal EntityCcaJoin(IConnection connection) : base(connection) { }

//    public IEntityCcaJoin<TSource1, TSource2, TEntityRight> InnerJoin<TEntityRight>
//        (Expression<Func<TSource1, TEntityRight, bool>> expression)
//            where TEntityRight : IEntity
//    { return default; }
//    public IEntityCcaJoin<TSource1, TSource2, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
//        Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
//            where TEntityRight : IEntity
//    { return default; }

//    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, bool>> expression) =>
//       new EntityCcaWhere<TSource1, TSource2>(_connection).Where(expression);
//}
//public class EntityCcaJoin<TSource1, TSource2, TSource3> :
//    EntityCcaJoin, IEntityCcaJoin<TSource1, TSource2, TSource3>
//{
//    internal EntityCcaJoin(IConnection connection, IEntity entity) : base(connection, entity) { }
//    internal EntityCcaJoin(IConnection connection) : base(connection) { }

//    public IEntityCcaJoin<TSource1, TSource2, TSource3, TEntityRight> InnerJoin<TEntityRight>(
//        Expression<Func<TSource1, TEntityRight, bool>> expression)
//            where TEntityRight : IEntity
//    { return default; }
//    public IEntityCcaJoin<TSource1, TSource2, TSource3, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
//        Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
//            where TEntityRight : IEntity
//    { return default; }
//    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, bool>> expression) =>
//       new EntityCcaWhere<TSource1, TSource2, TSource3>(_connection).Where(expression);
//}
//public class EntityCcaJoin<TSource1, TSource2, TSource3, TSource4> :
//    EntityCcaJoin, IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4>
//{
//    internal EntityCcaJoin(IConnection connection, IEntity entity) : base(connection, entity) { }
//    internal EntityCcaJoin(IConnection connection) : base(connection) { }

//    public IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TEntityRight> InnerJoin<TEntityRight>(
//        Expression<Func<TSource1, TEntityRight, bool>> expression)
//            where TEntityRight : IEntity
//    { return default; }
//    public IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
//       Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
//           where TEntityRight : IEntity
//    { return default; }
//    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, bool>> expression) =>
//       new EntityCcaWhere<TSource1, TSource2, TSource3, TSource4>(_connection).Where(expression);
//}
//public class EntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5> :
//    EntityCcaJoin, IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5>
//{
//    internal EntityCcaJoin(IConnection connection, IEntity entity) : base(connection, entity) { }
//    internal EntityCcaJoin(IConnection connection) : base(connection) { }
//    public IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TEntityRight> InnerJoin<TEntityRight>(
//        Expression<Func<TSource1, TEntityRight, bool>> expression)
//            where TEntityRight : IEntity
//    { return default; }
//    public IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
//       Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
//           where TEntityRight : IEntity
//    { return default; }
//    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, bool>> expression) =>
//       new EntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5>(_connection).Where(expression);
//}
//public class EntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6> :
//    EntityCcaJoin, IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6>
//{
//    internal EntityCcaJoin(IConnection connection, IEntity entity) : base(connection, entity) { }
//    internal EntityCcaJoin(IConnection connection) : base(connection) { }
//    public IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TEntityRight> InnerJoin<TEntityRight>(
//        Expression<Func<TSource1, TEntityRight, bool>> expression)
//            where TEntityRight : IEntity
//    { return default; }
//    public IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
//       Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
//           where TEntityRight : IEntity
//    { return default; }
//    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, bool>> expression) =>
//       new EntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6>(_connection).Where(expression);
//}
//public class EntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7> :
//    EntityCcaJoin, IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7>
//{
//    internal EntityCcaJoin(IConnection connection, IEntity entity) : base(connection, entity) { }
//    internal EntityCcaJoin(IConnection connection) : base(connection) { }
//    public IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TEntityRight> InnerJoin<TEntityRight>(
//        Expression<Func<TSource1, TEntityRight, bool>> expression)
//            where TEntityRight : IEntity
//    { return default; }
//    public IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
//       Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
//           where TEntityRight : IEntity
//    { return default; }
//    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, bool>> expression) =>
//       new EntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7>(_connection).Where(expression);
//}
