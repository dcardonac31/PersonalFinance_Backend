// ***********************************************************************
// Assembly         : PersonalFinance.Common
// Author           : David Sneider Cardona Cardenas
// Created          : 06-27-2021
//
// Last Modified By : David Sneider Cardona Cardenas
// Last Modified On : 06-27-2021
// ***********************************************************************
// <copyright file="ListTo.cs" company="PersonalFinance.Common">
//     Copyright (c) David Cardona - Software Developer. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace PersonalFinance.Common.Dtos
{
    /// <summary>
    /// Class ListTo.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ListTo
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [JsonProperty("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
