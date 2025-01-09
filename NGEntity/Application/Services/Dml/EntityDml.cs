namespace NGEntity
{
    internal class EntityDml<TSource> : CommandData, IEntityDml<TSource>
    {
        internal EntityDml() { }

        public ICommandCommit Insert(TSource firstEntity, params TSource[] otherEntities)
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
                Context.AddCommand(source.GetType(), Insert);
            }

            return new CommandCommit(identifier);
        }
        public ICommandCommit Update(TSource entity) 
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Update update = new Update();
            update.SetValues((IEntity)entity);

            Context.AddCommand(entity.GetType(), update);

            return new CommandCommit(update.Identifier);
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
        public ICommandCommit Delete(TSource entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Delete delete = new();
            delete.SetValues((IEntity)entity);

            Context.AddCommand(entity.GetType(), delete);

            return new CommandCommit(delete.Identifier);
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