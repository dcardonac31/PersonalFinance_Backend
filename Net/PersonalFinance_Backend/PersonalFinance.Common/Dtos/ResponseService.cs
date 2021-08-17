// ***********************************************************************
// Assembly         : PersonalFinance.Common
// Author           : David Sneider Cardona Cardenas
// Created          : 08-02-2021
//
// Last Modified By : David Sneider Cardona Cardenas
// Last Modified On : 08-02-2021
// ***********************************************************************
// <copyright file="ResponseService.cs" company="PersonalFinance.Common">
//     Copyright (c) David Cardona - Software Developer. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace PersonalFinance.Common.Dtos
{
    /// <summary>
    /// Class ResponseService.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ExcludeFromCodeCoverage]
    public class ResponseService<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ResponseService{T}" /> is status.
        /// </summary>
        /// <value><c>true</c> if status; otherwise, <c>false</c>.</value>
        public bool Status { get; set; }
        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        /// <value>The HTTP status code.</value>
        public HttpStatusCode HttpStatusCode { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public T Data { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseService{T}" /> class.
        /// </summary>
        public ResponseService()
        {
            Status = false;
            Message = string.Empty;
        }
    }
}
