// ***********************************************************************
// Assembly         : PersonalFinance.Common
// Author           : David Sneider Cardona Cardenas
// Created          : 06-27-2021
//
// Last Modified By : David Sneider Cardona Cardenas
// Last Modified On : 06-27-2021
// ***********************************************************************
// <copyright file="EnumeratorExtension.cs" company="PersonalFinance.Common">
//     Copyright (c) David Cardona - Software Developer. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Common.Enums.Exts
{
    /// <summary>
    /// Class EnumeratorExtensionAttribute.
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [ExcludeFromCodeCoverage]
    public class EnumeratorExtensionAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumeratorExtensionAttribute" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public EnumeratorExtensionAttribute(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; }
    }

    /// <summary>
    /// Class EnumeratorExtension.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class EnumeratorExtension
    {
        /// <summary>
        /// Converts to stringattribute.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string ToStringAttribute(this Enum value) 
        {
            var stringValues = new Hashtable();

            string output = null;
            var type = value.GetType();

            //Comprueba si ya existe la búsqueda en caché
            if(stringValues.ContainsKey(value))
            {
                var stringValueAttribute = (EnumeratorExtensionAttribute)stringValues[value];
                if (stringValueAttribute != null)
                    output = stringValueAttribute.Value;
            }
            else
            {
                //Buscar el ToStringAttribute en los atributos personalizados
                System.Reflection.FieldInfo fi = type.GetField(value.ToString());
                var attrs = (EnumeratorExtensionAttribute[])fi.GetCustomAttributes(typeof(EnumeratorExtensionAttribute), false);

                stringValues.Add(value, attrs[0]);
                output = attrs[0].Value;
            }
            return output;
        }
    }
}
