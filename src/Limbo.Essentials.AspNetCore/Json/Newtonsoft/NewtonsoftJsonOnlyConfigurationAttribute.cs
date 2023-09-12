using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Skybrud.Essentials.Strings;

#pragma warning disable CS1591

namespace Limbo.Essentials.AspNetCore.Json.Newtonsoft {

    /// <summary>
    /// When added to an API controller, the output will be serialized to JSON using <strong>Newtonsoft.Json</strong>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class NewtonsoftJsonOnlyConfigurationAttribute : TypeFilterAttribute {

        public TextCasing Casing { get; }

        public Formatting Formatting { get; }

        public NewtonsoftJsonOnlyConfigurationAttribute() : this(TextCasing.CamelCase, Formatting.None) { }

        public NewtonsoftJsonOnlyConfigurationAttribute(TextCasing casing) : this(casing, Formatting.None) { }

        public NewtonsoftJsonOnlyConfigurationAttribute(TextCasing casing, Formatting formatting) : base(typeof(NewtonsoftJsonOnlyConfigurationFilter)) {
            Casing = casing;
            Formatting = formatting;
            Order = 1;
            Arguments = new object[] { this };
        }

    }

}