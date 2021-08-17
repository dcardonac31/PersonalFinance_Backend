// ***********************************************************************
// Assembly         : PersonalFinance.Infraestructure
// Author           : David Sneider Cardona Cardenas
// Created          : 08-03-2021
//
// Last Modified By : David Sneider Cardona Cardenas
// Last Modified On : 08-03-2021
// ***********************************************************************
// <copyright file="Repository.cs" company="PersonalFinance.Infraestructure">
//     Copyright (c) David Cardona - Software Developer. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Infraestructure.DataAcces.Pagination;
using PersonalFinance.Infraestructure.DataAcces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonalFinance.Infraestructure.DataAcces.Repository
{
    /// <summary>
    /// Class Repository.
    /// Implements the <see cref="PersonalFinance.Infraestructure.DataAcces.Repository.IRepository{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="PersonalFinance.Infraestructure.DataAcces.Repository.IRepository{TEntity}" />
    [ExcludeFromCodeCoverage]
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The dbcontext
        /// </summary>
        private readonly DbContext _dbcontext;
        /// <summary>
        /// The entities
        /// </summary>
        private readonly DbSet<TEntity> _entities;
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}" /> class.
        /// </summary>
        /// <param name="dbcontext">The dbcontext.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public Repository(DbContext dbcontext, IUnitOfWork unitOfWork)
        {
            _dbcontext = dbcontext;

            //Desactivar la carga lenta de Entitie Framework
            _dbcontext.ChangeTracker.LazyLoadingEnabled = false;

            //Desactivar consulta con seguimiento
            _dbcontext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _entities = dbcontext.Set<TEntity>();
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Performs the inclusions.
        /// </summary>
        /// <param name="includeProperties">The include properties.</param>
        /// <param name="query">The query.</param>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        private IQueryable<TEntity> PerformInclusions(IEnumerable<Expression<Func<TEntity, object>>> includeProperties, IQueryable<TEntity> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        #region IRepository<TEntity> Members
        /// <summary>
        /// Ases the queryable.
        /// </summary>
        /// <returns>Task&lt;IQueryable&lt;TEntity&gt;&gt;.</returns>
        public async Task<IQueryable<TEntity>> AsQueryable()
        {
            return _entities.AsQueryable();
        }

        /// <summary>
        /// [ERROR: invalid expression MethodName.Words.ExceptLastPascalCase] as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>A Task&lt;Task`1&gt; representing the asynchronous operation.</returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        /// <summary>
        /// [ERROR: invalid expression MethodName.Words.ExceptLastPascalCase] as an asynchronous operation.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <returns>A Task&lt;Task`1&gt; representing the asynchronous operation.</returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true)
        {
            var result = await PagedResult<TEntity>.ToPagedListAsync(_entities.AsQueryable(), page, limit, orderBy, ascending);

            return result;
        }

        /// <summary>
        /// [ERROR: invalid expression MethodName.Words.ExceptLastPascalCase] as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <returns>A Task&lt;Task`1&gt; representing the asynchronous operation.</returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where, int page, int limit, string orderBy, bool ascending = true)
        {
            return await PagedResult<TEntity>.ToPagedListAsync(_entities.AsQueryable().Where(where), page, limit, orderBy, ascending);
        }

        /// <summary>
        /// [ERROR: invalid expression MethodName.Words.ExceptLastPascalCase] as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.FirstOrDefault(where);
        }


        /// <summary>
        /// [ERROR: invalid expression MethodName.Words.ExceptLastPascalCase] as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>A Task&lt;Task`1&gt; representing the asynchronous operation.</returns>
        public async Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.LastOrDefault(where);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Insert(TEntity entity)
        {
            _entities.Add(entity);
            return _unitOfWork.Save() > 0;
        }

        /// <summary>
        /// Inserts the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Insert(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dbcontext.Entry(e).State = EntityState.Added;
            }
            return _unitOfWork.Save() > 0;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Update(TEntity entity)
        {
            _entities.Attach(entity);
            _dbcontext.Entry(entity).State = EntityState.Modified;
            return _unitOfWork.Save() > 0;
        }

        /// <summary>
        /// Updates the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Update(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dbcontext.Entry(e).State = EntityState.Modified;
            }
            return _unitOfWork.Save() > 0;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Delete(TEntity entity)
        {
            if (_dbcontext.Entry(entity).State == EntityState.Detached)
            {
                _entities.Attach(entity);
            }
            _entities.Remove(entity);
            return _unitOfWork.Save() > 0;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Delete(object id)
        {
            TEntity entityToDelete = _entities.Find(id);
            _entities.Remove(entityToDelete);
            return _unitOfWork.Save() > 0;
        }

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Delete(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dbcontext.Entry(e).State = EntityState.Deleted;
            }
            return _unitOfWork.Save() > 0;
        }
        #endregion
    }
}
