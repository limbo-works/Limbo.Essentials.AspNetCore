using System.Buffers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Skybrud.Essentials.Json.Newtonsoft.Serialization;

#pragma warning disable CS1591

namespace Limbo.Essentials.AspNetCore.Json.Newtonsoft {

    public class NewtonsoftJsonOnlyConfigurationFilter : IResultFilter {

        private readonly ArrayPool<char> _arrayPool;
        private readonly NewtonsoftJsonOnlyConfigurationAttribute _attribute;
        private readonly MvcOptions _options;

        public NewtonsoftJsonOnlyConfigurationFilter(ArrayPool<char> arrayPool, IOptionsSnapshot<MvcOptions> options, NewtonsoftJsonOnlyConfigurationAttribute attribute) {
            _arrayPool = arrayPool;
            _attribute = attribute;
            _options = options.Value;
        }

        public void OnResultExecuted(ResultExecutedContext context) { }

        public virtual void OnResultExecuting(ResultExecutingContext context) {

            if (context.Result is not ObjectResult objectResult) return;

            JsonSerializerSettings serializerSettings = new() {
                ContractResolver = new DefaultContractResolver {
                    NamingStrategy = new TextCasingNamingStrategy(_attribute.Casing)
                },
                Converters = { new VersionConverter() },
                Formatting = _attribute.Formatting
            };

            objectResult.Formatters.Clear();
            objectResult.Formatters.Add(new NewtonsoftJsonOutputFormatter(serializerSettings, _arrayPool, _options));

        }

    }

}