// <copyright file="PoliceRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Repository.Repositories
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using PoliceApp.Data;

    /// <summary>
    /// PoliceRepository class.
    /// </summary>
    public class PoliceRepository : Repo<Police>, IPoliceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PoliceRepository"/> class.
        /// </summary>
        /// <param name="context">DbContext to deal with data.</param>
        public PoliceRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Implements the update method.
        /// </summary>
        /// <param name="id">Id of the record we want to update.</param>
        /// <param name="newCity">Name of the Updated city.</param>
        public void UpdateCity(int id, string newCity)
        {
            var police = this.GetOne(id);
            police.PoliceCity = newCity;
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Implements the GetOne method.
        /// </summary>
        /// <param name="id">Id of the desired element.</param>
        /// <returns>TEntity object.</returns>
        public override Police GetOne(int id)
        {
            return this.GetAll().FirstOrDefault(x => x.PoliceId == id);
        }
    }
}
