using System.Buffers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

#pragma warning disable CS1591

namespace Skybrud.Essentials.AspNetCore.Json.Newtonsoft.Filters {

    public class NewtonsoftJsonOnlyConfigurationFilter : IResultFilter {

        private readonly ArrayPool<char> _arrayPool;
        private readonly MvcOptions _options;

        public NewtonsoftJsonOnlyConfigurationFilter(ArrayPool<char> arrayPool, IOptionsSnapshot<MvcOptions> options) {
            _arrayPool = arrayPool;
            _options = options.Value;
        }

        public void OnResultExecuted(ResultExecutedContext context) { }

        public virtual void OnResultExecuting(ResultExecutingContext context) {

            if (context.Result is not ObjectResult objectResult) return;

            JsonSerializerSettings serializerSettings = new() {
                ContractResolver = new DefaultContractResolver(),
                Converters = { new VersionConverter() },
            };

            objectResult.Formatters.Clear();
            objectResult.Formatters.Add(new NewtonsoftJsonOutputFormatter(serializerSettings, _arrayPool, _options));

        }

    }

}