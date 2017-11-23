using EcoBioFarm.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace EcoBioFarm.Data.Repository
{
    public class RDBERepository<T> : IRDBERepository<T> where T : class
    {
        public RDBERepository(ApplicationDbContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<T>();
        }

        protected DbContext Context { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            this.DbSet.AddRange(entities);
        }

        public IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public IQueryable<T> AllReadOnly()
        {
            return this.DbSet
                .AsNoTracking()
                .AsQueryable();
        }

        public void Delete(object id)
        {
            T entity = GetById(id);

            Delete(entity);
        }

        public void Delete(T entity)
        {
            EntityEntry entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Deleted)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Deleted;
        }

        public void Detach(T entity)
        {
            EntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public void Update(T entity)
        {
            this.DbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entity)
        {
            this.DbSet.UpdateRange(entity);
        }
    }
}
