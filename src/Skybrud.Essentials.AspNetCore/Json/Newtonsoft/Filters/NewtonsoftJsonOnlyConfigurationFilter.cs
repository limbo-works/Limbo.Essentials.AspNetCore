using System.Buffers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Skybrud.Essentials.AspNetCore.Json.Newtonsoft.Attributes;
using Skybrud.Essentials.Json.Newtonsoft.Serialization;

#pragma warning disable CS1591

namespace Skybrud.Essentials.AspNetCore.Json.Newtonsoft.Filters {

    public class NewtonsoftJsonOnlyConfigurationFilter : IResultFilter {

        private readonly ArrayPool<char> _arrayPool;
        private readonly MvcOptions _options;

        public NewtonsoftJsonOnlyConfigurationAttribute Attribute { get; }

        public NewtonsoftJsonOnlyConfigurationFilter(ArrayPool<char> arrayPool, IOptionsSnapshot<MvcOptions> options, NewtonsoftJsonOnlyConfigurationAttribute attribute) {
            _arrayPool = arrayPool;
            _options = options.Value;
            Attribute = attribute;
        }

        public void OnResultExecuted(ResultExecutedContext context) { }

        public virtual void OnResultExecuting(ResultExecutingContext context) {

            if (context.Result is not ObjectResult objectResult) return;

            JsonSerializerSettings serializerSettings = new() {
                ContractResolver = new DefaultContractResolver() {
                    NamingStrategy = new TextCasingNamingStrategy(Attribute.Casing)
                },
                Converters = { new VersionConverter() },
                Formatting = Attribute.Formatting
            };

            objectResult.Formatters.Clear();
            objectResult.Formatters.Add(new NewtonsoftJsonOutputFormatter(serializerSettings, _arrayPool, _options));

        }

    }

}