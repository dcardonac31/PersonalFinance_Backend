// ***********************************************************************
// Assembly         : PersonalFinance.Infraestructure
// Author           : David Sneider Cardona Cardenas
// Created          : 06-27-2021
//
// Last Modified By : David Sneider Cardona Cardenas
// Last Modified On : 06-27-2021
// ***********************************************************************
// <copyright file="IRepository.cs" company="PersonalFinance.Infraestructure">
//     Copyright (c) David Cardona - Software Developer. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonalFinance.Infraestructure.DataAcces.Repository
{
    /// <summary>
    /// Interface IRepository
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        #region IRepository<T> Members
        /// <summary>
        /// Ases the queryable.
        /// </summary>
        /// <returns>Task&lt;IQueryable&lt;TEntity&gt;&gt;.</returns>
        Task<IQueryable<TEntity>> AsQueryable();

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Task&lt;IEnumerable&lt;TEntity&gt;&gt;.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <returns>Task&lt;IEnumerable&lt;TEntity&gt;&gt;.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true);

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <returns>Task&lt;IEnumerable&lt;TEntity&gt;&gt;.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where, int page, int limit, string orderBy, bool ascending = true);

        /// <summary>
        /// Firsts the or default asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Lasts the or default asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Insert(TEntity entity);

        /// <summary>
        /// Inserts the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Insert(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Update(TEntity entity);

        /// <summary>
        /// Updates the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Delete(TEntity entity);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Delete(object id);

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Delete(IEnumerable<TEntity> entities);
        #endregion
    }
}
