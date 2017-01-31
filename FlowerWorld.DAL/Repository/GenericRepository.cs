using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWorld.DAL.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class,new ()
    {
        private readonly DbContext context;

        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get
        {
            get
            {
                return dbSet;
            }
        }

        public TEntity GetById(int id)
        {
            TEntity entry = dbSet.Find(id);

            if (entry == null)
            {
                return null;
            }

            return entry;
        }

        public void Delete(int id)
        {
            TEntity entry = GetById(id);

            if (entry == null)
            {
                return;
            }

            Delete(entry);
        }


        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            dbSet.Add(entity);
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public FlowerContext GetContext()
        {
            return new FlowerContext();
        }

    }
}
