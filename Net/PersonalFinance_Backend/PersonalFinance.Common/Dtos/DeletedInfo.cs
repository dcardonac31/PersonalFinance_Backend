// ***********************************************************************
// Assembly         : PersonalFinance.Common
// Author           : David Sneider Cardona Cardenas
// Created          : 08-02-2021
//
// Last Modified By : David Sneider Cardona Cardenas
// Last Modified On : 06-27-2021
// ***********************************************************************
// <copyright file="DeletedInfo.cs" company="PersonalFinance.Common">
//     Copyright (c) David Cardona - Software Developer. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Common.Dtos
{
    /// <summary>
    /// Class DeletedInfo.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ExcludeFromCodeCoverage]
    public class DeletedInfo<T>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public T Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeletedInfo{T}" /> class.
        /// </summary>
        public DeletedInfo()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeletedInfo{T}" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userName">Name of the user.</param>
        public DeletedInfo(T id, string userName)
        {
            Id = id;
            UserName = userName;
        }
    }
}
