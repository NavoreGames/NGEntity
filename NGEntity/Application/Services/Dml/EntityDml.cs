namespace NGEntity
{
    internal class EntityDml<TSource> : CommandData, IEntityDml<TSource>
        where TSource : IEntity
    {
        internal EntityDml() { }

        public ICommandExecute Insert(TSource firstEntity, params TSource[] otherEntities)
        {
            if (firstEntity == null || (otherEntities != null && otherEntities.Any(a => a == null)))
                throw new ArgumentNullException(firstEntity.GetType().ToString());
            ////// UNE AS ENTIDADES EM UMA LISTA ///////
            List<TSource> sources = new(otherEntities);
            sources.Insert(0, firstEntity);
            ////// CRIAR E ADICIONAR O COMANDO CONFORME CONTEXTO ///////////
            Guid identifier = Guid.NewGuid();
            foreach (TSource source in sources.OrderBy(o => o.GetType()))
            {
                Insert insert = new(identifier, source);
                CommandHandle.RaiseOnCreateCommand(insert);
            }

            return new CommandExecuteQuery(identifier);
        }
        public ICommandExecute Update(TSource entity) 
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Update update = new Update();
            update.SetValues((IEntity)entity);

            Context.AddCommand(entity.GetType(), update);

            return new CommandExecuteQuery(update.Identifier);
        }
        public IEntityWhere<TSource> Updates(TSource entity)  
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Update update = new Update();
            update.SetValues((IEntity)entity);

            Context.AddCommand(entity.GetType(), update);

            return new EntityWhere<TSource>(update.Identifier);
        }
        public ICommandExecute Delete(TSource entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Delete delete = new();
            delete.SetValues((IEntity)entity);

            Context.AddCommand(entity.GetType(), delete);

            return new CommandExecuteQuery(delete.Identifier);
        }
        public IEntityWhere<TSource> Deletes()
        {
            Delete delete = new();
            delete.SetValues((IEntity)default(TSource));

            Context.AddCommand(default(TSource).GetType(), delete);

            return new EntityWhere<TSource>(delete.Identifier);
        }
        public IEntityJoin<TSource> Selects() { return default; }
        public IEntityWhere<TSource> Selects<TProperty>(Expression<Func<TSource, TProperty>> fields) { return default; }
    }
}