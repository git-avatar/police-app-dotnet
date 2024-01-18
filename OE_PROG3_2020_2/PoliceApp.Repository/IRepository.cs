// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Repository
{
    using System.Linq;

    /// <summary>
    /// Create interface IRepositroy which takes a TEntity parameter.
    /// </summary>
    /// <typeparam name="TEntity">Generic paramenter wich can be used with different types in the future.</typeparam>
    public interface IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// GetOne function used to get a TEntity object of the same id as the parameter.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <returns>TEntity object.</returns>
        TEntity GetOne(int id);

        /// <summary>
        /// GetAll function used to get a TEntity objects of a certain dataset.
        /// </summary>
        /// <returns>IQueryable objects of TEntity.</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Add function used to add a TEntity object.
        /// </summary>
        /// <param name="entity">Object to be added.</param>
        void Add(TEntity entity);

        /// <summary>
        /// AddRange function used to add a list of TEntity objects.
        /// </summary>
        /// <param name="entities">IQueryable objects of type TEntity.</param>
        void AddRange(IQueryable<TEntity> entities);

        /// <summary>
        /// Remove function used to remove an TEntity object.
        /// </summary>
        /// <param name="entity">Object to be removed.</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Remove function used to remove an object of the same id as the parameter.
        /// </summary>
        /// <param name="id">Id of desired element.</param>
        void Remove(int id);

        /// <summary>
        /// RemoveOne function used to remove an object of the same id as the parameter.
        /// </summary>
        /// <param name="id">Id of desired element.</param>
        /// <returns>Bool value which signals if the remove was done correctly.</returns>
        bool RemoveOne(int id);

        /// <summary>
        /// RemoveRange function used to remove a list of TEntity objects.
        /// </summary>
        /// <param name="entities">IQueryable objects of type TEntity.</param>
        void RemoveRange(IQueryable<TEntity> entities);
    }
}
