// ***********************************************************************
// Assembly         : PersonalFinance.Common
// Author           : David Sneider Cardona Cardenas
// Created          : 08-02-2021
//
// Last Modified By : David Sneider Cardona Cardenas
// Last Modified On : 08-02-2021
// ***********************************************************************
// <copyright file="UserToken.cs" company="PersonalFinance.Common">
//     Copyright (c) David Cardona - Software Developer. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Common.Dtos
{
    /// <summary>
    /// Class UserToken.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class UserToken
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        public string Token { get; set; }
        /// <summary>
        /// Gets or sets the expiration.
        /// </summary>
        /// <value>The expiration.</value>
        public DateTime Expiration { get; set; }
    }
}
