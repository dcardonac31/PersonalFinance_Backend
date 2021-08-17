// ***********************************************************************
// Assembly         : PersonalFinance.Common
// Author           : David Sneider Cardona Cardenas
// Created          : 08-03-2021
//
// Last Modified By : David Sneider Cardona Cardenas
// Last Modified On : 08-03-2021
// ***********************************************************************
// <copyright file="GenericEnumerator.cs" company="PersonalFinance.Common">
//     Copyright (c) David Cardona - Software Developer. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using PersonalFinance.Common.Enums.Exts;

namespace PersonalFinance.Common.Enums
{
    /// <summary>
    /// Class GenericEnumerator.
    /// </summary>
    public class GenericEnumerator
    {
        /// <summary>
        /// Enum DateFormat
        /// </summary>
        public enum DateFormat
        {
            /// <summary>
            /// The dmy
            /// </summary>
            Dmy,
            /// <summary>
            /// The dmyh
            /// </summary>
            Dmyh,
            /// <summary>
            /// The mdy
            /// </summary>
            Mdy,
            /// <summary>
            /// The mdyh
            /// </summary>
            Mdyh,
            /// <summary>
            /// The ymd
            /// </summary>
            Ymd,
            /// <summary>
            /// The ymdh
            /// </summary>
            Ymdh,
            /// <summary>
            /// The HHMMSS
            /// </summary>
            Hhmmss
        }

        /// <summary>
        /// Enum Headers
        /// </summary>
        public enum Headers
        {
            /// <summary>
            /// The x API key
            /// </summary>
            [EnumeratorExtension("X-API-CODE")]
            XApiKey
        }

        /// <summary>
        /// Enum LogType
        /// </summary>
        public enum LogType
        {
            /// <summary>
            /// The information
            /// </summary>
            [EnumeratorExtension("INFO")]
            Info,

            /// <summary>
            /// The error
            /// </summary>
            [EnumeratorExtension("ERROR")]
            Error
        }

        /// <summary>
        /// Enum TypeRequest
        /// </summary>
        public enum TypeRequest
        {
            /// <summary>
            /// The request
            /// </summary>
            Request,
            /// <summary>
            /// The response
            /// </summary>
            Response,
            /// <summary>
            /// The exception
            /// </summary>
            Exception
        }

        /// <summary>
        /// Enum Separator
        /// </summary>
        public enum Separator
        {
            /// <summary>
            /// The slash
            /// </summary>
            [EnumeratorExtension("/")]
            Slash,

            /// <summary>
            /// The hyphen
            /// </summary>
            [EnumeratorExtension("-")]
            Hyphen,

            /// <summary>
            /// The point
            /// </summary>
            [EnumeratorExtension(".")]
            Point,

            /// <summary>
            /// The empty
            /// </summary>
            [EnumeratorExtension("")]
            Empty
        }

        /// <summary>
        /// Enum Status
        /// </summary>
        public enum Status
        {
            /// <summary>
            /// The ok
            /// </summary>
            [EnumeratorExtension("OK")]
            Ok = 1,

            /// <summary>
            /// The error
            /// </summary>
            [EnumeratorExtension("ERROR")]
            Error = 0
        }

        /// <summary>
        /// Enum Log
        /// </summary>
        public enum Log
        {
            /// <summary>
            /// The error
            /// </summary>
            Error,

            /// <summary>
            /// The information
            /// </summary>
            Info,

            /// <summary>
            /// The warn
            /// </summary>
            Warn,

            /// <summary>
            /// The debug
            /// </summary>
            Debug
        }

        /// <summary>
        /// Enum OrderByMethod
        /// </summary>
        public enum OrderByMethod
        {
            /// <summary>
            /// The order by
            /// </summary>
            OrderBy,

            /// <summary>
            /// The order by descending
            /// </summary>
            OrderByDescending
        }

        /// <summary>
        /// Enum Language
        /// </summary>
        public enum Language
        {
            /// <summary>
            /// The es
            /// </summary>
            [EnumeratorExtension("es")]
            Es,

            /// <summary>
            /// The en
            /// </summary>
            [EnumeratorExtension("en")]
            En
        }

        /// <summary>
        /// Enum General
        /// </summary>
        public enum General
        {
            /// <summary>
            /// The default identifier
            /// </summary>
            DefaultId = 0
        }

        /// <summary>
        /// Enum Method
        /// </summary>
        public enum Method
        {
            /// <summary>
            /// The post
            /// </summary>
            [EnumeratorExtension("CREATED")]
            Post,

            /// <summary>
            /// The put
            /// </summary>
            [EnumeratorExtension("UPDATED")]
            Put,

            /// <summary>
            /// The delete
            /// </summary>
            [EnumeratorExtension("DELETED")]
            Delete
        }
    }
}
