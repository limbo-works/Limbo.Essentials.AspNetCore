using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Skybrud.Essentials.AspNetCore;

namespace TestProject1 {

    [TestClass]
    public class QueryStringTests {

        #region Guids

        [TestMethod]
        public void GetGuid() {

            Guid fallback = new("c77e1e78-4d79-4a3a-8776-54f6a6fd9587");

            Guid expected = new("7ce565ca-3dfe-4bc8-9166-4c4a5d1a9cbb");

            var query = ParseQuery("a=&b=nope&c=7ce565ca-3dfe-4bc8-9166-4c4a5d1a9cbb");

            var a1 = query.GetGuid("a");
            var a2 = query.GetGuid("a", fallback);

            var b1 = query.GetGuid("b");
            var b2 = query.GetGuid("b", fallback);

            var c1 = query.GetGuid("c");
            var c2 = query.GetGuid("c", fallback);

            Assert.AreEqual(Guid.Empty, a1, "#A1");
            Assert.AreEqual(fallback, a2, "#A2");

            Assert.AreEqual(Guid.Empty, b1, "#B1");
            Assert.AreEqual(fallback, b2, "#B2");

            Assert.AreEqual(expected, c1, "#C1");
            Assert.AreEqual(expected, c2, "#C2");

        }

        [TestMethod]
        public void GetGuidOrNull() {

            Guid expected = new("7ce565ca-3dfe-4bc8-9166-4c4a5d1a9cbb");

            var query = ParseQuery("a=&b=nope&c=7ce565ca-3dfe-4bc8-9166-4c4a5d1a9cbb");

            var a1 = query.GetGuidOrNull("a");
            var b1 = query.GetGuidOrNull("b");
            var c1 = query.GetGuidOrNull("c");

            Assert.IsNull(a1, "#A");
            Assert.IsNull(b1, "#B");
            Assert.AreEqual(expected, c1, "#C");

        }

        [TestMethod]
        public void GetGuidArray() {

            IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
                {"guids", new StringValues(new[] { "7ce565ca-3dfe-4bc8-9166-4c4a5d1a9cbb", "a11c5663-d025-49be-93d7-876226dfd9b1", "nope", null })}
            });

            var guids = query.GetGuidArray("guids");

            Assert.AreEqual(2, guids.Length);

            Assert.AreEqual("7ce565ca-3dfe-4bc8-9166-4c4a5d1a9cbb", guids[0].ToString());
            Assert.AreEqual("a11c5663-d025-49be-93d7-876226dfd9b1", guids[1].ToString());

        }

        [TestMethod]
        public void GetGuidList() {

            IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
                {"guids", new StringValues(new[] { "7ce565ca-3dfe-4bc8-9166-4c4a5d1a9cbb", "a11c5663-d025-49be-93d7-876226dfd9b1", "nope", null })}
            });

            var guids = query.GetGuidList("guids");

            Assert.AreEqual(2, guids.Count);

            Assert.AreEqual("7ce565ca-3dfe-4bc8-9166-4c4a5d1a9cbb", guids[0].ToString());
            Assert.AreEqual("a11c5663-d025-49be-93d7-876226dfd9b1", guids[1].ToString());

        }

        #endregion

        private static QueryCollection ParseQuery(string query) {
            return new QueryCollection(QueryHelpers.ParseQuery(query));
        }

    }

}