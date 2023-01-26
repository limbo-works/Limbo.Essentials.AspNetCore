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
        public void GetInt32() {

            IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
                {"id", new StringValues("1")},
                {"ids", new StringValues(new []{"1", "2", "3"})},
                {"moreIds", new StringValues(new []{"5,6", "7", "8"})}
            });

            int id = query.GetInt32("id");
            Assert.AreEqual(1, id, "#1");

            int id2 = query.GetInt32("id2");
            Assert.AreEqual(0, id2, "#2");

            int id3 = query.GetInt32("id2", 2);
            Assert.AreEqual(2, id3, "#3");

            int? id4 = query.GetInt32OrNull("id3");
            Assert.IsNull(id4, "#4");

            int id5 = query.GetInt32("ids");
            Assert.AreEqual(1, id5, "#5");

            int id6 = query.GetInt32("moreIds");
            Assert.AreEqual(0, id6, "#6");

        }

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
        public void GetInt64() {

            IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
                {"id", new StringValues("1")},
                {"ids", new StringValues(new []{"1", "2", "3"})},
                {"moreIds", new StringValues(new []{"5,6", "7", "8"})}
            });

            long id = query.GetInt64("id");
            Assert.AreEqual(1, id, "#1");

            long id2 = query.GetInt64("id2");
            Assert.AreEqual(0, id2, "#2");

            long id3 = query.GetInt64("id2", 2);
            Assert.AreEqual(2, id3, "#3");

            long? id4 = query.GetInt64OrNull("id3");
            Assert.IsNull(id4, "#4");

            long id5 = query.GetInt64("ids");
            Assert.AreEqual(1, id5, "#5");

            long id6 = query.GetInt64("moreIds");
            Assert.AreEqual(0, id6, "#6");

        }

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
        public void GetFloat() {

            IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
                {"pi", new StringValues("3.14")},
                {"values", new StringValues(new []{"3.14", "6.28", "9.42"})},
                {"otherValues", new StringValues(new []{"3.14,6.28", "9.42"})}
            });

            // Returns "3.14"
            float pi = query.GetFloat("pi");
            Assert.AreEqual("3.14", pi.ToString("F2", CultureInfo.InvariantCulture), "#1");

            // Returns "0.00" (implicit fallback)
            float meh = query.GetFloat("meh");
            Assert.AreEqual("0.00", meh.ToString("F2", CultureInfo.InvariantCulture), "#2");

            // Returns "1.23" (explicit fallback)
            float meh2 = query.GetFloat("meh", 1.23f);
            Assert.AreEqual("1.23", meh2.ToString("F2", CultureInfo.InvariantCulture), "#3");

            // Returns "null"
            float? meh3 = query.GetFloatOrNull("meh");
            Assert.IsNull(meh3, "#4");

        }

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
        public void GetDouble() {

            IQueryCollection query = new QueryCollection(new Dictionary<string, StringValues> {
                {"pi", new StringValues("3.1415926535")},
                {"values", new StringValues(new []{"3.1415926535", "6.283185307", "9.4247779605"})},
                {"otherValues", new StringValues(new []{"3.1415926535,6.283185307", "9.4247779605"})}
            });

            // Returns "3.1415926535"
            double pi = query.GetDouble("pi");
            Assert.AreEqual("3.1415926535", pi.ToString("F10", CultureInfo.InvariantCulture), "#1");

            // Returns "0.000" (implicit fallback)
            double meh = query.GetDouble("meh");
            Assert.AreEqual("0.000", meh.ToString("F3", CultureInfo.InvariantCulture), "#2");

            // Returns "1.230" (explicit fallback)
            double meh2 = query.GetDouble("meh", 1.23f);
            Assert.AreEqual("1.230", meh2.ToString("F3", CultureInfo.InvariantCulture), "#3");

            // Returns "null"
            double? meh3 = query.GetDoubleOrNull("meh");
            Assert.IsNull(meh3, "#4");

        }

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