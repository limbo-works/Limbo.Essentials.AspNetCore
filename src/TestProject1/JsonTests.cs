using System.Net;
using Limbo.Essentials.AspNetCore.Json;

namespace TestProject1 {

    [TestClass]
    public class JsonTests {

        [TestMethod]
        public void JsonBodyOk() {

            LimboJsonBody body = LimboJsonBody
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

        }

        [TestMethod]
        public void JsonBodyInternalServerError() {

            LimboJsonBody body = LimboJsonBody
                .InternalServerError("Oh noes!!!!");

            Assert.AreEqual("Oh noes!!!!", body.Meta.Error);
            Assert.AreEqual(HttpStatusCode.InternalServerError, body.Meta.Code);

            Assert.IsNull(body.Pagination);

            Assert.IsNull(body.Data);

        }

    }

}