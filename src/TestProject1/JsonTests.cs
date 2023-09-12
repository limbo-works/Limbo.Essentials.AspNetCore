using System.Net;
using System.Text.Json;
using Limbo.Essentials.AspNetCore.Json;
using Newtonsoft.Json;

namespace TestProject1 {

    [TestClass]
    public class JsonTests {

        [TestMethod]
        public void JsonBodyOk() {

            const string expected = """
                {
                  "meta": {
                    "code": 200
                  },
                  "pagination": {
                    "total": 1,
                    "limit": 2,
                    "offset": 3
                  },
                  "data": "Hello there!"
                }
                """;

            LimboJsonMetaResult body = LimboJsonMetaResult
                .Ok("Hello there!")
                .SetPagination(1, 2, 3);

            Assert.IsNull(body.Meta.Error);
            Assert.AreEqual(HttpStatusCode.OK, body.Meta.Code);

            Assert.IsInstanceOfType(body.Pagination, typeof(LimboJsonPagination));

            if (body.Pagination is LimboJsonPagination pagination) {
                Assert.AreEqual(1, pagination.Total);
                Assert.AreEqual(2, pagination.Limit);
                Assert.AreEqual(3, pagination.Offset);
            }

            Assert.AreEqual("Hello there!", body.Data);

            Assert.AreEqual(expected, JsonConvert.SerializeObject(body, Formatting.Indented), "Newtonsoft.Json");

            Assert.AreEqual(expected, System.Text.Json.JsonSerializer.Serialize(body, new JsonSerializerOptions {
                WriteIndented = true

            }), "System.Text.Json");

        }

        [TestMethod]
        public void JsonBodyBadRequest() {

            const string expected = """
                {
                  "meta": {
                    "code": 400,
                    "error": "Computer says NO!!!"
                  }
                }
                """;

            LimboJsonMetaResult body = LimboJsonMetaResult
                .BadRequest("Computer says NO!!!");

            Assert.AreEqual("Computer says NO!!!", body.Meta.Error);
            Assert.AreEqual(HttpStatusCode.BadRequest, body.Meta.Code);

            Assert.IsNull(body.Pagination);

            Assert.IsNull(body.Data);

            Assert.AreEqual(expected, JsonConvert.SerializeObject(body, Formatting.Indented));

            Assert.AreEqual(expected, System.Text.Json.JsonSerializer.Serialize(body, new JsonSerializerOptions {
                WriteIndented = true
            }), "System.Text.Json");

        }

        [TestMethod]
        public void JsonBodyNotFound() {

            const string expected = """
                {
                  "meta": {
                    "code": 404,
                    "error": "Nothing to see here!!!!"
                  }
                }
                """;

            LimboJsonMetaResult body = LimboJsonMetaResult
                .NotFound("Nothing to see here!!!!");

            Assert.AreEqual("Nothing to see here!!!!", body.Meta.Error);
            Assert.AreEqual(HttpStatusCode.NotFound, body.Meta.Code);

            Assert.IsNull(body.Pagination);

            Assert.IsNull(body.Data);

            Assert.AreEqual(expected, JsonConvert.SerializeObject(body, Formatting.Indented));

            Assert.AreEqual(expected, System.Text.Json.JsonSerializer.Serialize(body, new JsonSerializerOptions {
                WriteIndented = true
            }), "System.Text.Json");

        }

        [TestMethod]
        public void JsonBodyInternalServerError() {

            const string expected = """
                {
                  "meta": {
                    "code": 500,
                    "error": "Oh noes!!!!"
                  }
                }
                """;

            LimboJsonMetaResult body = LimboJsonMetaResult
                .InternalServerError("Oh noes!!!!");

            Assert.AreEqual("Oh noes!!!!", body.Meta.Error);
            Assert.AreEqual(HttpStatusCode.InternalServerError, body.Meta.Code);

            Assert.IsNull(body.Pagination);

            Assert.IsNull(body.Data);

            Assert.AreEqual(expected, JsonConvert.SerializeObject(body, Formatting.Indented));

            Assert.AreEqual(expected, System.Text.Json.JsonSerializer.Serialize(body, new JsonSerializerOptions {
                WriteIndented = true
            }), "System.Text.Json");

        }

    }

}