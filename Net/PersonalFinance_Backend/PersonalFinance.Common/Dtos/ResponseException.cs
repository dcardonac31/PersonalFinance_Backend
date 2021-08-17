// ***********************************************************************
// Assembly         : PersonalFinance.Common
// Author           : David Sneider Cardona Cardenas
// Created          : 08-02-2021
//
// Last Modified By : David Sneider Cardona Cardenas
// Last Modified On : 08-02-2021
// ***********************************************************************
// <copyright file="ResponseException.cs" company="PersonalFinance.Common">
//     Copyright (c) David Cardona - Software Developer. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Common.Dtos
{
    /// <summary>
    /// Class ResponseException.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ResponseException
    {
        /// <summary>
        /// Gets or sets the error level.
        /// </summary>
        /// <value>The error level.</value>
        public string ErrorLevel { get; set; }
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Gets or sets the error source.
        /// </summary>
        /// <value>The error source.</value>
        public string ErrorSource { get; set; }
        /// <summary>
        /// Gets or sets the error stack trace.
        /// </summary>
        /// <value>The error stack trace.</value>
        public string ErrorStackTrace { get; set; }
        /// <summary>
        /// Gets or sets the error target site.
        /// </summary>
        /// <value>The error target site.</value>
        public string ErrorTargetSite { get; set; }
        /// <summary>
        /// Gets or sets the error data.
        /// </summary>
        /// <value>The error data.</value>
        public IDictionary ErrorData { get; set; }
    }
}
