using Microsoft.VisualStudio.TestTools.UnitTesting;
using Port11.Utilities;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class VerifyTests : BaseUnitTest
    {
        [ClassInitialize]
        public static void TestClassinitialize(TestContext context)
        {
            SetSettings(context);
        }
        [TestCleanup]
        public void TearDown()
        {
            FinalizeTest(TestContext);
        }
        [TestCategory("Unit"), TestMethod]
        public void VerifyStringsAreEqualTest()
        {
            const string stringFromService = "test";
            const string stringExpected = "test";
            Verify.Strings.AreEqual(stringFromService, stringExpected, "Testing Strings Are Equal");
        }
        [TestCategory("Unit"), TestMethod]
        public void VerifyStringsAreNotEqualTest()
        {
            const string stringFromService = "test";
            const string stringExpected = "test2";
            Verify.Strings.AreNotEqual(stringFromService, stringExpected, "Testing Strings Are NOT Equal");
        }
        [TestCategory("Unit"), TestMethod]
        public void VerifyStringsArePartiallyEqualTest()
        {
            const string stringFromTest = "test";
            const string stringExpected = "tes";
            Verify.Strings.ArePartiallyEqual(stringFromTest, stringExpected, "Testing Strings Are Patially Equal");
        }
        [TestCategory("Unit"), TestMethod]
        public void VerifyStringsArePartiallyEqualIgnoreCaseTest()
        {
            const string stringFromTest = "test";
            const string stringExpected = "Tes";
            Verify.Strings.ArePartiallyEqual(stringFromTest, stringExpected, "Testing Strings Are Patially Equal", ignoreCase: true);
        }
        [TestCategory("Unit"), TestMethod]
        public void VerifyCollectionsTest()
        {
            var collection1 = new List<List<string>> { new List<string> { "Test1", "Test2" }, new List<string> { "Test3", "Test4" } };
            var collection2 = new List<List<string>> { new List<string> { "Test1", "Test2" }, new List<string> { "Test3", "Test4" } };
            Verify.Collections.AreEqual(collection1, collection2, "Testing Collections Are Equal");
        }
        [TestCategory("Unit"), TestMethod]
        public void VerifyListsTest()
        {
            var list1 = new List<string> { "Test1", "Test2" };
            var list2 = new List<string> { "Test1", "Test2" };
            Verify.List.AreEqual(list1, list2, "Testing Collections Are Equal");
        }
    }
}
