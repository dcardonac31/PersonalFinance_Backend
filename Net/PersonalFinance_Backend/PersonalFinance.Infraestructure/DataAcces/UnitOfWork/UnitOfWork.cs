// ***********************************************************************
// Assembly         : PersonalFinance.Infraestructure
// Author           : David Sneider Cardona Cardenas
// Created          : 08-03-2021
//
// Last Modified By : David Sneider Cardona Cardenas
// Last Modified On : 08-03-2021
// ***********************************************************************
// <copyright file="UnitOfWork.cs" company="PersonalFinance.Infraestructure">
//     Copyright (c) David Cardona - Software Developer. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace PersonalFinance.Infraestructure.DataAcces.UnitOfWork
{
    /// <summary>
    /// Class UnitOfWork.
    /// Implements the <see cref="PersonalFinance.Infraestructure.DataAcces.UnitOfWork.IUnitOfWork" />
    /// </summary>
    /// <seealso cref="PersonalFinance.Infraestructure.DataAcces.UnitOfWork.IUnitOfWork" />
    [ExcludeFromCodeCoverage]
    public class UnitOfWork : IUnitOfWork
    {
        #region Attributes

        /// <summary>
        /// The context
        /// </summary>
        private readonly DbContext _context;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed = false;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        public UnitOfWork()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Save() => _context.SaveChanges();

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        public void Rollback() => _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());

        #endregion

    }
}
