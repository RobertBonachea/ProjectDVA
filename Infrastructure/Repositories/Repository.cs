using Infrastructure.Interfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DemographicsDbContext _context;
        private IDbSet<T> _dbSet;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public Repository(DemographicsDbContext context)
        {
            _context = context;
            this._dbSet = _context.Set<T>();
        }

     
        protected virtual IDbSet<T> DbSet
        {
            get { return _dbSet ?? (_dbSet = _context.Set<T>()); }
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.DbSet.Add(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var fail = GenerateException(dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        /// <summary>
        /// Delete entity by Id
        /// </summary>        
        /// <param name="id">Identifier</param>
        public virtual void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

               // if (_context.Entry(entity).State == EntityState.Detached)
               //     DbSet.Attach(entity);

                this.DbSet.Remove(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var fail = GenerateException(dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }



        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                
                DbSet.Attach(entity);

                var dbEntityEntry = _context.Entry(entity);
                
                foreach (var property in dbEntityEntry.OriginalValues.PropertyNames)
                {
                    var original = dbEntityEntry.OriginalValues.GetValue<object>(property);
                    var current = dbEntityEntry.CurrentValues.GetValue<object>(property);
                    if (original != null && !original.Equals(current))
                        dbEntityEntry.Property(property).IsModified = true;
                }

                _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
                
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var fail = GenerateException(dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }





        /// <summary>
        /// Gets All Entities
        /// </summary>
        public virtual IQueryable<T> GetAll
        {
            get { return DbSet; }
        }

        /// <summary>
        /// Gets All Entities with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<T> GetAllNoTracking
        {
            get { return DbSet.AsNoTracking(); }
        }

        /// <summary>
        /// Gets All Entities Including Eager Loaded Relations
        /// </summary>
        /// <param name="includedProperties">Included Relations</param>
        /// <returns>Entities with eager loaded selected relations</returns>
        public virtual IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includedProperties)
        {
            var entities = DbSet.AsQueryable();
            foreach (var includedPropery in includedProperties)
            {
                entities = entities.Include(includedPropery);
            }

            return entities;
        }

        /// <summary>
        /// Get all Entities Including Eager loaded Relations also nested relations.
        /// </summary>
        /// <param name="includedProperties">Comma seperated table (relation) names to include in result set.</param>
        /// <returns>Entities with Eager loaded selected relations</returns>
        public virtual IQueryable<T> GetAllIncluding(string includedProperties)
        {
            var entities = DbSet.AsQueryable();
            var relations = includedProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var property in relations)
            {
                entities = entities.Include(property);
            }

            return entities;
        }

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        /// <summary>
        /// Get full error
        /// </summary>
        /// <param name="dbEx">Exception</param>
        /// <returns>Error</returns>
        private static Exception GenerateException(DbEntityValidationException dbEx)
        {
            var msg = string.Empty;

            foreach (var validationErrors in dbEx.EntityValidationErrors)
                foreach (var validationError in validationErrors.ValidationErrors)
                    msg += Environment.NewLine +
                           string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

            var fail = new Exception(msg, dbEx);
            return fail;
        }



        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
