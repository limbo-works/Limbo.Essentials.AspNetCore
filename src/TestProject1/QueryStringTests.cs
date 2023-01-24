using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Skybrud.Essentials.AspNetCore;

namespace TestProject1 {

    [TestClass]
    public class QueryStringTests {

        #region Int32

        [TestMethod]
        public void GetInt32Array() {

            IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
                {"ints", new StringValues(new[] { "1,2", "3", "nope", null })}
            });

            var array = query.GetInt32Array("ints");

            Assert.AreEqual(3, array.Length);

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual(3, array[2]);

        }

        [TestMethod]
        public void GetInt32List() {

            IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
                {"ints", new StringValues(new[] { "1,2", "3", "nope", null })}
            });

            var array = query.GetInt32List("ints");

            Assert.AreEqual(3, array.Count);

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual(3, array[2]);

        }

        #endregion

        #region Int64

        [TestMethod]
        public void GetInt64Array() {

            IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
                {"longs", new StringValues(new[] { "1,2", "3", "nope", null })}
            });

            var array = query.GetInt64Array("longs");

            Assert.AreEqual(3, array.Length);

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual(3, array[2]);

        }

        [TestMethod]
        public void GetInt64List() {

            IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
                {"longs", new StringValues(new[] { "1,2", "3", "nope", null })}
            });

            var array = query.GetInt64List("longs");

            Assert.AreEqual(3, array.Count);

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual(3, array[2]);

        }

        #endregion

        #region Float / Single

        [TestMethod]
        public void GetFloatArray() {

            IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
                {"floats", new StringValues(new[] { "1,2", "3.4", "nope", null })}
            });

            var array = query.GetFloatArray("floats");

            Assert.AreEqual(3, array.Length);

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual("3.4", array[2].ToString("N1", CultureInfo.InvariantCulture));

        }

        [TestMethod]
        public void GetFLoatList() {

            IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
                {"floats", new StringValues(new[] { "1,2", "3.4", "nope", null })}
            });

            var array = query.GetFloatList("floats");

            Assert.AreEqual(3, array.Count);

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual("3.4", array[2].ToString("N1", CultureInfo.InvariantCulture));

        }

        #endregion

        #region Double

        [TestMethod]
        public void GetDoubleArray() {

            IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
                {"doubles", new StringValues(new[] { "1,2", "3.4", "nope", null })}
            });

            var array = query.GetDoubleArray("doubles");

            Assert.AreEqual(3, array.Length);

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual("3.4", array[2].ToString("N1", CultureInfo.InvariantCulture));

        }

        [TestMethod]
        public void GetDoubleList() {

            IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
                {"doubles", new StringValues(new[] { "1,2", "3.4", "nope", null })}
            });

            var array = query.GetDoubleList("doubles");

            Assert.AreEqual(3, array.Count);

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual("3.4", array[2].ToString("N1", CultureInfo.InvariantCulture));

        }

        #endregion

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
                {"guids", new StringValues(new[] { "7ce565ca-3dfe-4bc8-9166-4c4a5d1a9cbb,8a2a3f66-898c-4b1e-8db7-efb8c08d4669", "a11c5663-d025-49be-93d7-876226dfd9b1", "nope", null })}
            });

            var guids = query.GetGuidArray("guids");

            Assert.AreEqual(3, guids.Length);

            Assert.AreEqual("7ce565ca-3dfe-4bc8-9166-4c4a5d1a9cbb", guids[0].ToString());
            Assert.AreEqual("8a2a3f66-898c-4b1e-8db7-efb8c08d4669", guids[1].ToString());
            Assert.AreEqual("a11c5663-d025-49be-93d7-876226dfd9b1", guids[2].ToString());

        }

        [TestMethod]
        public void GetGuidList() {

            IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
                {"guids", new StringValues(new[] { "7ce565ca-3dfe-4bc8-9166-4c4a5d1a9cbb,8a2a3f66-898c-4b1e-8db7-efb8c08d4669", "a11c5663-d025-49be-93d7-876226dfd9b1", "nope", null })}
            });

            var guids = query.GetGuidList("guids");

            Assert.AreEqual(3, guids.Count);

            Assert.AreEqual("7ce565ca-3dfe-4bc8-9166-4c4a5d1a9cbb", guids[0].ToString());
            Assert.AreEqual("8a2a3f66-898c-4b1e-8db7-efb8c08d4669", guids[1].ToString());
            Assert.AreEqual("a11c5663-d025-49be-93d7-876226dfd9b1", guids[2].ToString());

        }

        #endregion

        private static QueryCollection ParseQuery(string query) {
            return new QueryCollection(QueryHelpers.ParseQuery(query));
        }

    }

}