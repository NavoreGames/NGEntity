using NGEntity.Interfaces;

namespace NGEntity
{
    internal class EntityDml<TSource> : EntityData, IEntityDml<TSource>
    {
        internal EntityDml() { }

        public IEntityCommit Insert(TSource firstEntity, params TSource[] otherEntities)
        {
            if (firstEntity == null || (otherEntities != null && otherEntities.Any(a => a == null)))
                throw new ArgumentNullException(firstEntity.GetType().ToString());
            ////// UNE AS ENTIDADES EM UMA LISTA ///////
            List<TSource> sources = new(otherEntities);
            ////// CRIAR E ADICIONAR O COMANDO CONFORME CONTEXTO ///////////
            Guid identifier = Guid.NewGuid();
            foreach (TSource source in sources.OrderBy(o => o.GetType()))
            {
                Insert Insert = new Insert(identifier);
                Insert.SetValues((IEntity)source);
                Context.AddCommand(Insert);

                //List<ContextData> contexts = Context.GetContext(source.GetType());
                //if (contexts.Count == 0)
                //    Context.AddCommand("None", commandData);
                //else
                //{
                //    contexts.ForEach(
                //        context =>
                //        {
                //            Context.AddCommand(context.Alias, commandData.SetCommand(context.Connection.GetType()));
                //        }
                //    );
                //}
            }

            return new EntityCommit(identifier);
        }
        public IEntityCommit Update(TSource entity) 
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Update update = new Update();
            update.SetValues((IEntity)entity);

            Context.AddCommand(update);

            ////// ADICIONAR O COMANDO NO CONTEXTO ///////////
            //List<ContextData> contexts = Context.GetContext(entity.GetType());
            //if (contexts.Count == 0)
            //    Context.AddCommand("None", commandData);
            //else
            //{
            //    contexts.ForEach(
            //        context =>
            //        {
            //            Context.AddCommand(context.Alias, commandData.SetCommand(context.Connection.GetType()));
            //        }
            //    );
            //}

            return new EntityCommit(update.Identifier);
        }
        public IEntityWhere<TSource> Updates(TSource entity)  
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Update update = new Update();
            update.SetValues((IEntity)entity);

            Context.AddCommand(update);

            ////// ADICIONAR O COMANDO NO CONTEXTO ///////////
            //List<ContextData> contexts = Context.GetContext(entity.GetType());
            //if (contexts.Count == 0)
            //    Context.AddCommand("None", commandData);
            //else
            //{
            //    contexts.ForEach(
            //        context =>
            //        {
            //            Context.AddCommand(context.Alias, commandData.SetCommand(context.Connection.GetType()));
            //        }
            //    );
            //}

            return new EntityWhere<TSource>(update.Identifier);
        }
        public IEntityCommit Delete(TSource entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Delete delete = new();
            delete.SetValues((IEntity)entity);

            Context.AddCommand(delete);

            ////// ADICIONAR O COMANDO NO CONTEXTO ///////////
            //List<ContextData> contexts = Context.GetContext(entity.GetType());
            //if (contexts.Count == 0)
            //    Context.AddCommand("None", commandData);
            //else
            //{
            //    contexts.ForEach(
            //        context =>
            //        {
            //            Context.AddCommand(context.Alias, commandData.SetCommand(context.Connection.GetType()));
            //        }
            //    );
            //}

            return new EntityCommit(delete.Identifier);
        }
        public IEntityWhere<TSource> Deletes()
        {
            Delete delete = new();
            delete.SetValues((IEntity)default(TSource));

            Context.AddCommand(delete);

            ////// ADICIONAR O COMANDO NO CONTEXTO ///////////
            //List<ContextData> contexts = Context.GetContext(default(TSource).GetType());
            //if (contexts.Count == 0)
            //    Context.AddCommand("None", commandData);
            //else
            //{
            //    contexts.ForEach(
            //        context =>
            //        {
            //            Context.AddCommand(context.Alias, commandData.SetCommand(context.Connection.GetType()));
            //        }
            //    );
            //}

            return new EntityWhere<TSource>(delete.Identifier);

            return default;
        }
        public IEntityJoin<TSource> Selects() { return default; }
        public IEntityWhere<TSource> Selects<TProperty>(Expression<Func<TSource, TProperty>> fields) { return default; }
    }
}