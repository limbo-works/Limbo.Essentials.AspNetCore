using System;
using Microsoft.AspNetCore.Mvc;
using Skybrud.Essentials.AspNetCore.Filters.NewtonsoftJson;

#pragma warning disable CS1591

namespace Skybrud.Essentials.AspNetCore.Attributes.NewtonsoftJson {

    /// <summary>
    /// When added to an API controller, the output will be serialized to JSON using <strong>Newtonsoft.Json</strong>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [Obsolete("Use the class in the 'Skybrud.Essentials.AspNetCore.Json.Newtonsoft.Attributes' namespace instead.")]
    public class NewtonsoftJsonOnlyConfigurationAttribute : TypeFilterAttribute {

        public NewtonsoftJsonOnlyConfigurationAttribute() : base(typeof(NewtonsoftJsonOnlyConfigurationFilter)) {
            Order = 1;
        }

    }

}