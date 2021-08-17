// ***********************************************************************
// Assembly         : PersonalFinance.Common
// Author           : David Sneider Cardona Cardenas
// Created          : 08-02-2021
//
// Last Modified By : David Sneider Cardona Cardenas
// Last Modified On : 08-02-2021
// ***********************************************************************
// <copyright file="QueryMultipleResponse.cs" company="PersonalFinance.Common">
//     Copyright (c) David Cardona - Software Developer. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Common.Dtos
{
    /// <summary>
    /// Class QueryMultipleResponse.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ExcludeFromCodeCoverage]
    public class QueryMultipleResponse<T>
    {
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>The results.</value>
        public IEnumerable<T> Results { get; set; }
        /// <summary>
        /// Gets or sets the total records.
        /// </summary>
        /// <value>The total records.</value>
        public long TotalRecords { get; set; }
    }
}