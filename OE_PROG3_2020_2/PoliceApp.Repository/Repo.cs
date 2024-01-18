// <copyright file="Repo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Repository
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Abstract Repositroy class to implement the functions of the IRepository interface.
    /// </summary>
    /// <typeparam name="TEntity">TEntity parameter so it can be generic and not bount to one type.</typeparam>
    public abstract class Repo<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// DbContext to deal with data.
        /// </summary>
        private readonly DbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repo{TEntity}"/> class.
        /// Constructor for the Repo class.
        /// </summary>
        /// <param name="context">DbContext to deal with data.</param>
        public Repo(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets changes the DbContect to protected so all the desendant classes can use it.
        /// </summary>
        protected DbContext Context => this.context;

        /// <summary>
        /// Implements the Add funtion.
        /// </summary>
        /// <param name="entity">TEntity parameter.</param>
        public void Add(TEntity entity)
        {
            this.Context.Set<TEntity>().Add(entity);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Implements AddRange funtion.
        /// </summary>
        /// <param name="entities">IQueryable list of TEntity objects.</param>
        public void AddRange(IQueryable<TEntity> entities)
        {
            this.Context.Set<TEntity>().AddRange(entities);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Implements the get method.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <returns>TEntity object.</returns>
        public abstract TEntity GetOne(int id);

        /// <summary>
        /// Implements the GetAll function.
        /// </summary>
        /// <returns>IQueryable list of objects of type TEntity.</returns>
        public IQueryable<TEntity> GetAll()
        {
            return this.Context.Set<TEntity>();
        }

        /// <summary>
        /// Implements the remove function.
        /// </summary>
        /// <param name="entity">Object to be removed.</param>
        public void Remove(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Implements the remove function(Id).
        /// </summary>
        /// <param name="id">Id of desired element.</param>
        public void Remove(int id)
        {
            TEntity toRemove = this.Context.Set<TEntity>().Find(id);
            this.Context.Set<TEntity>().Remove(toRemove);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Implements the remove function(Id).
        /// </summary>
        /// <param name="id">Id of desired element.</param>
        /// <returns>Bool value signaling if the remove was correct or not.</returns>
        public bool RemoveOne(int id)
        {
            TEntity toRemove = this.Context.Set<TEntity>().Find(id);
            if (toRemove != null)
            {
                this.Context.Set<TEntity>().Remove(toRemove);
                this.Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Implements te RemoveRange function.
        /// </summary>
        /// <param name="entities">IQueryable list of objects of type TEntity.</param>
        public void RemoveRange(IQueryable<TEntity> entities)
        {
            this.Context.Set<TEntity>().RemoveRange(entities);
            this.Context.SaveChanges();
        }
    }
}
