// <copyright file="CriminalRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Repository.Repositories
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using PoliceApp.Data;

    /// <summary>
    /// CriminalRepository class.
    /// </summary>
    public class CriminalRepository : Repo<Criminal>, ICriminalRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CriminalRepository"/> class.
        /// </summary>
        /// <param name="context">DbContext to deal with data.</param>
        public CriminalRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Implements the GetOne method.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <returns>TEntity object.</returns>
        public override Criminal GetOne(int id)
        {
            return this.GetAll().FirstOrDefault(x => x.CriminalId == id);
        }

        /// <summary>
        /// Implements the update method.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <param name="newName">Name of the Updated name.</param>
        public void UpdateName(int id, string newName)
        {
            var criminal = this.GetOne(id);
            criminal.CriminalName = newName;
            this.Context.SaveChanges();
        }
    }
}
