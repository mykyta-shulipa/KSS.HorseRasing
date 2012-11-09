namespace KSS.HorseRacing.Infrastucture.DataAccess.Repositories
{
    using System.Data;

    using KSS.HorseRacing.Infrastucture.DataModels;

    public abstract class BaseRepository
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private EfContext _context;

        /// <summary>
        /// The set context.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public void SetContext(EfContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates the context.
        /// </summary>
        /// <returns>
        /// The current database context.
        /// </returns>
        protected EfContext getContext()
        {            
            return _context;
        }

        /// <summary>
        /// The save entity (create or modify).
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="T">
        /// The general type T.
        /// </typeparam>
        protected void save<T>(T entity) where T : BaseEntity
        {
            save(entity, getContext());
        }

        /// <summary>
        /// The save entity (create or modify).
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <typeparam name="T">
        /// The general type T.
        /// </typeparam>
        protected void save<T>(T entity, EfContext context) where T : BaseEntity
        {
            if (entity.Id == 0)
            {
                create(entity, context);
            }
            else
            {
                modify(entity, context);
            }
        }

        /// <summary>
        /// The delete current entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="T">
        /// The general type T.
        /// </typeparam>
        protected void delete<T>(T entity) where T : BaseEntity
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        /// <summary>
        /// The modify.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <typeparam name="T">
        /// The general type T.
        /// </typeparam>
        private void modify<T>(T entity, EfContext context) where T : BaseEntity
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        /// <summary>
        /// The create method.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <typeparam name="T">
        /// The general type T.
        /// </typeparam>
        private void create<T>(T entity, EfContext context) where T : BaseEntity
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }
    }
}
