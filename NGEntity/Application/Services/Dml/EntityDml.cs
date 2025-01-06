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
                Insert Insert = new Insert();
                Insert.SetValues((IEntity)source);
                CommandData commandData = 
                    new CommandData
                    (
                        identifier, 
                        DmlCommandType.Insert, 
                        Insert
                    );
                Context.AddCommand(commandData);

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
            CommandData commandData = new(DmlCommandType.Update, update);

            Context.AddCommand(commandData);

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

            return new EntityCommit(commandData.Identifier);
        }
        public IEntityWhere<TSource> Updates(TSource entity) 
        {
            //if (entity == null)
            //    throw new ArgumentNullException(nameof(entity));

            //CommandUpdate commandUpdate = new();
            //commandUpdate.SetValues((IEntity)entity);
            //CommandData commandData = new(DmlCommandType.Update, commandUpdate);
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

            //return new EntityWhere<TSource>(commandData.Identifier);

            return default;
        }
        public IEntityCommit Delete(TSource entity)
        {
            //if (entity == null)
            //    throw new ArgumentNullException(nameof(entity));

            //CommandDelete commandDelete = new();
            //commandDelete.SetValues((IEntity)entity);
            //CommandData commandData = new(DmlCommandType.Delete, commandDelete);
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

            //return new EntityCommit(commandData.Identifier);

            return default;
        }
        public IEntityWhere<TSource> Deletes()
        {
            //CommandDelete commandDelete = new();
            //commandDelete.SetValues((IEntity)default(TSource));
            //CommandData commandData = new(DmlCommandType.Delete, commandDelete);
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

            //return new EntityWhere<TSource>(commandData.Identifier);

            return default;
        }
        public IEntityJoin<TSource> Selects() { return default; }
        public IEntityWhere<TSource> Selects<TProperty>(Expression<Func<TSource, TProperty>> fields) { return default; }
    }
}