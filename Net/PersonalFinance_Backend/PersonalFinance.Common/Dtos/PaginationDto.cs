// ***********************************************************************
// Assembly         : PersonalFinance.Common
// Author           : David Sneider Cardona Cardenas
// Created          : 08-02-2021
//
// Last Modified By : David Sneider Cardona Cardenas
// Last Modified On : 08-02-2021
// ***********************************************************************
// <copyright file="PaginationDto.cs" company="PersonalFinance.Common">
//     Copyright (c) David Cardona - Software Developer. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Common.Dtos
{
    /// <summary>
    /// Class PaginationDto.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PaginationDto
    {
        /// <summary>
        /// Gets or sets the order by.
        /// </summary>
        /// <value>The order by.</value>
        public string OrderBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PaginationDto" /> is ascendent.
        /// </summary>
        /// <value><c>true</c> if ascendent; otherwise, <c>false</c>.</value>
        public bool Ascendent { get; set; }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>The page number.</value>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the results per page.
        /// </summary>
        /// <value>The results per page.</value>
        public int ResultsPerPage { get; set; }
    }
}
