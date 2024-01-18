// <copyright file="CrimeRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Repository.Repositories
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using PoliceApp.Data;

    /// <summary>
    /// CrimeRepositroy class.
    /// </summary>
    public class CrimeRepository : Repo<Crime>, ICrimeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrimeRepository"/> class.
        /// </summary>
        /// <param name="context">DbContext to deal with data.</param>
        public CrimeRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Implements the GetOne method.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <returns>TEntity object.</returns>
        public override Crime GetOne(int id)
        {
            return this.GetAll().FirstOrDefault(x => x.CrimeId == id);
        }

        /// <summary>
        /// Implements the update method.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <param name="newType">Name of the Updated type.</param>
        public void UpdateType(int id, string newType)
        {
            var crime = this.GetOne(id);
            crime.CrimeType = newType;
            this.Context.SaveChanges();
        }
    }
}
