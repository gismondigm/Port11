using Port11.Enums;
using Port11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Port11.Utilities
{
    [TestClass]
    public class BaseUnitTest
    {
        private static TestContext _testContext;
        public TestContext TestContext { get; set; }
        public static string StandardOutput;
        public BaseUnitTest()
        {
            Log.Initialize();
        }
        public static void SetSettings(TestContext context, bool isAdmin = false)
        {
        }
        public void FinalizeTest(TestContext context = null)
        {
            UnitTestOutcome testResult;

            if (_testContext == null || _testContext.CurrentTestOutcome == UnitTestOutcome.Unknown || TestContext != null)
            {
                _testContext = TestContext;
            }

            try
            {
                testResult = _testContext.CurrentTestOutcome;
            }
            catch (Exception e)
            {
                testResult = UnitTestOutcome.Failed;
                var errorMessage = new ErrorMessage($"Test Context was not properly set {e}");
                Log.Error(errorMessage);
            }

            TestOutcomes testOutcome;

            switch (testResult)
            {
                case UnitTestOutcome.Failed:
                case UnitTestOutcome.Error:
                case UnitTestOutcome.Inconclusive:
                case UnitTestOutcome.Unknown:
                case UnitTestOutcome.Timeout:
                case UnitTestOutcome.InProgress:
                    {
                        var errorMessage = new ErrorMessage("Test Aborted");
                        Log.Error(errorMessage);

                        testOutcome = TestOutcomes.Fail;
                        break;
                    }

                case UnitTestOutcome.Aborted:
                    {
                        var errorMessage = new ErrorMessage("Test Aborted");
                        Log.Error(errorMessage);
                        testOutcome = TestOutcomes.Fail;
                        break;
                    }

                case UnitTestOutcome.Passed:
                    {
                        if (Log.ErrorCount == 0 && Log.FailCount == 0)
                        {
                            testOutcome = TestOutcomes.Pass;
                            break;
                        }

                        testOutcome = TestOutcomes.Fail;
                        break;
                    }

                case UnitTestOutcome.NotRunnable:
                {
                    var errorMessage = new ErrorMessage("Test Not Runnable");
                    Log.Error(errorMessage);
                    testOutcome = TestOutcomes.Fail;
                    break;
                }
                default:
                    {
                        try
                        {
                            var errorMessage = new ErrorMessage("\r\n Test Failed due to unexpected error. UnitTestOutcome was NOT set");
                            Log.Error(errorMessage);
                        }
                        catch (Exception e)
                        {
                            Log.Error($"\r\n Test Failed due to unexpected error - \r\n {e}");
                        }
                        testOutcome = TestOutcomes.Fail;
                        break;
                    }
            }
            if (testOutcome == TestOutcomes.Fail)
            {
                var output = "N/A";
                if (!string.IsNullOrEmpty(StandardOutput))
                {
                    output = StandardOutput;
                }
                Log.Initialize();
                Assert.Fail($"Test Failed. For More Information, Please Check Attachments For Standard Console Output. Please Check Work Items For Any Existing Bugs Or Tasks. StandardOutput: {output}");
            }
            Log.Initialize();
        }
        public static class Verify
        {
            /// <summary>
            /// Verifies a generic condition is true.
            /// </summary>
            /// <param name="value"></param>
            /// <param name="message"></param>
            public static void IsTrue(bool value, string message)
            {
                Console.Write(message);

                try
                {
                    try
                    {
                        Assert.IsTrue(value);
                    }
                    catch (AssertFailedException)
                    {
                        var errorMessage = new ErrorMessage("\r\n Expected the condition to be True but was False \r\n ");
                        Log.Fail(message, errorMessage);
                    }
                }
                catch (Exception e)
                {
                    var errorMessage = new ErrorMessage(e);
                    Log.Error(message, errorMessage);
                }
            }

            /// <summary>
            /// Verifies a generic condition is false
            /// </summary>
            /// <param name="value"></param>
            /// <param name="message"></param>
            public static void IsFalse(bool value, string message)
            {
                Console.Write(message);

                try
                {
                    try
                    {
                        Assert.IsFalse(value);
                    }
                    catch (AssertFailedException)
                    {
                        var errorMessage = new ErrorMessage("\r\n Expected the condition to be False but was True \r\n ");
                        Log.Fail(message, errorMessage);
                    }
                }
                catch (Exception e)
                {
                    var errorMessage = new ErrorMessage(e);
                    Log.Error(message, errorMessage);
                }

            }

            public static class Strings
            {
                /// <summary>
                /// Verifies two strings are exactly equal.
                /// Trims whitespace around each string.
                /// </summary>
                /// <param name="stringFromServiceResponse"></param>
                /// <param name="stringFromUserVerfication"></param>
                /// <param name="message"></param>
                /// <param name="ignoreCase"></param>
                public static void AreEqual(string stringFromServiceResponse, string stringFromUserVerfication, string message, bool ignoreCase = false)
                {
                    Console.Write(message);

                    try
                    {
                        try
                        {
                            stringFromServiceResponse = stringFromServiceResponse.Trim();
                            stringFromUserVerfication = stringFromUserVerfication.Trim();
                            stringFromServiceResponse = string.IsNullOrEmpty(stringFromServiceResponse) ? "<BLANK STRING>" : stringFromServiceResponse;
                            stringFromUserVerfication = string.IsNullOrEmpty(stringFromUserVerfication) ? "<BLANK STRING>" : stringFromUserVerfication;
                            Assert.IsTrue(ignoreCase ? string.Equals(stringFromServiceResponse, stringFromUserVerfication, StringComparison.InvariantCultureIgnoreCase) : string.Equals(stringFromServiceResponse, stringFromUserVerfication));
                        }
                        catch (AssertFailedException)
                        {
                            var errorMessage = new ErrorMessage("\r\n  String values are not equal.\r\nActual Values:\r\nSTRING 1: " + stringFromServiceResponse + "\r\nSTRING 2: " + stringFromUserVerfication);
                            Log.Fail(message, errorMessage);
                        }
                    }
                    catch (Exception e)
                    {
                        var errorMessage = new ErrorMessage(e);
                        Log.Error(message, errorMessage);
                    }
                }

                /// <summary>
                /// Verifies string 1 contains string 2.
                /// Trims whitespace around each string.
                /// </summary>
                /// <param name="stringFromServiceResponse"></param>
                /// <param name="stringFromUserVerfication"></param>
                /// <param name="message"></param>
                /// <param name="ignoreCase"></param>
                public static void ArePartiallyEqual(string stringFromServiceResponse, string stringFromUserVerfication, string message, bool ignoreCase = false)
                {
                    Console.Write(message);
                    if (string.IsNullOrEmpty(stringFromUserVerfication) || string.IsNullOrEmpty(stringFromUserVerfication))
                    {
                        var errorMessage = new ErrorMessage("One or both the strings are empty.\r\nActual Values:\r\nSTRING 1: " +
                                                            stringFromServiceResponse + "\r\nSTRING 2: " + stringFromUserVerfication);
                        Log.Fail(message, errorMessage);
                        return;
                    }
                    try
                    {
                        if (ignoreCase)
                        {
                            stringFromServiceResponse = stringFromServiceResponse.ToLower();
                            stringFromUserVerfication = stringFromUserVerfication.ToLower();
                        }

                        try
                        {
                            stringFromServiceResponse = stringFromServiceResponse.Trim();
                            stringFromUserVerfication = stringFromUserVerfication.Trim();
                            stringFromServiceResponse = string.IsNullOrEmpty(stringFromServiceResponse) ? "<BLANK STRING>" : stringFromServiceResponse;
                            stringFromUserVerfication = string.IsNullOrEmpty(stringFromUserVerfication) ? "<BLANK STRING>" : stringFromUserVerfication;

                            Assert.IsTrue(stringFromServiceResponse.Contains(stringFromUserVerfication));
                        }
                        catch (AssertFailedException)
                        {
                            var errorMessage = new ErrorMessage("\r\n String Two is not contained within String One.\r\nActual Values:\r\nSTRING 1: " + stringFromServiceResponse + "\r\nSTRING 2: " + stringFromUserVerfication);
                            Log.Fail(message, errorMessage);
                        }
                    }
                    catch (Exception e)
                    {
                        var errorMessage = new ErrorMessage(e);
                        Log.Error(message, errorMessage);
                    }
                }

                /// <summary>
                /// Verifies string 1 and string 2 are not the same.
                /// Trims whitespace around each string.
                /// </summary>
                /// <param name="stringFromServiceResponse"></param>
                /// <param name="stringFromUserVerfication"></param>
                /// <param name="message"></param>
                /// <param name="ignoreCase"></param>
                public static void AreNotEqual(string stringFromServiceResponse, string stringFromUserVerfication, string message, bool ignoreCase = false)
                {
                    Console.Write(message);

                    try
                    {
                        try
                        {
                            stringFromServiceResponse = stringFromServiceResponse.Trim();
                            stringFromUserVerfication = stringFromUserVerfication.Trim();
                            Assert.IsFalse(ignoreCase ? string.Equals(stringFromServiceResponse, stringFromUserVerfication, StringComparison.InvariantCultureIgnoreCase) : string.Equals(stringFromServiceResponse, stringFromUserVerfication));
                            stringFromServiceResponse = string.IsNullOrEmpty(stringFromServiceResponse) ? "<BLANK STRING>" : stringFromServiceResponse;
                            stringFromUserVerfication = string.IsNullOrEmpty(stringFromUserVerfication) ? "<BLANK STRING>" : stringFromUserVerfication;
                        }
                        catch (AssertFailedException)
                        {
                            var errorMessage = new ErrorMessage("\r\n String Two is equal to String One.\r\nActual Values:\r\nSTRING 1: " + stringFromServiceResponse + "\r\nSTRING 2: " + stringFromUserVerfication);
                            Log.Fail(message, errorMessage);
                        }
                    }
                    catch (Exception e)
                    {
                        var errorMessage = new ErrorMessage(e);
                        Log.Error(message, errorMessage);
                    }
                }
            }

            public static class Collections
            {
                public static void AreEqual(List<List<string>> collection1, List<List<string>> collection2, string message)
                {
                    Console.WriteLine(message);
                    var collection1CellValue = "";
                    var collection2CellValue = "";
                    try
                    {
                        try
                        {
                            for (var i = 0; i < collection1.Count; i++)
                            {
                                for (var j = 0; j < collection1[i].Count; j++)
                                {
                                    collection1CellValue = string.IsNullOrEmpty(collection1[i][j]) ? "<Cell is empty>" : collection1[i][j];
                                    collection2CellValue = string.IsNullOrEmpty(collection2[i][j]) ? "<Cell is empty>" : collection2[i][j];
                                    Assert.AreEqual(collection1CellValue, collection2CellValue);
                                }
                            }
                            if (collection1.Count == 0 || collection2.Count == 0) throw new ArgumentException();
                            Console.WriteLine(@"\r\n PASS! Collections are equal");
                        }
                        catch (AssertFailedException)
                        {
                            var errorMessage = new ErrorMessage("\r\n String values are not equal.\r\nActual Values:\r\nFirst unmatching Collection 1 value: " + collection1CellValue + "\r\nFirst unmatching Collection 2 value: " + collection2CellValue);
                            Log.Fail(message, errorMessage);
                        }
                        catch (ArgumentException)
                        {
                            var errorMessage = new ErrorMessage("\r\n One of the collections have less items or empty");
                            Log.Fail(message, errorMessage);
                        }
                    }
                    catch (Exception e)
                    {
                        var errorMessage = new ErrorMessage(e);
                        Log.Error(message, errorMessage);
                    }

                }
            }
            public static class List
            {
                public static bool IsNotAny(List<string> list1, List<string> list2)
                {
                    return !list1.Any() && !list2.Any();
                }

                public static void AreEqual(List<string> listFromService, List<string> listFromExpected, string message)
                {
                    Log.Write(message);
                    try
                    {
                        var list1 = listFromService.Except(listFromExpected).ToList();
                        var list2 = listFromExpected.Except(listFromService).ToList();
                        Assert.IsTrue(IsNotAny(list1, list2));
                    }
                    catch (AssertFailedException ex)
                    {
                        Log.Write(ex.Message);
                        var errorMessage = new ErrorMessage($"String values are not equal.\r\nActual Values:\r\nList From Service: {listFromService} \r\nList From Expected: {listFromExpected}");
                        Log.Fail(message, errorMessage);
                    }

                    catch (ArgumentException ex)
                    {
                        Log.Write(ex.Message);
                        var error = new ErrorMessage("One of the list is empty");
                        Log.Fail(message, error);
                    }
                    catch (Exception ex)
                    {
                        Log.Warning(ex.Message);
                    }
                }
            }
            public static class Models
            {
                public static void AreEqual(dynamic modelFromService, dynamic modelFromExpected, string message)
                {
                    Log.Write(message);
                    var string1 = JsonHelper.GetJsonFromModel(modelFromService);
                    var string2 = JsonHelper.GetJsonFromModel(modelFromExpected);
                    try
                    {
                        Strings.AreEqual(string1, string2, message, true);
                    }
                    catch (AssertFailedException ex)
                    {
                        Log.Write(ex.Message);
                        var errorMessage = new ErrorMessage($"String values are not equal.\r\nActual Values:\r\nJson From Service: {string1} \r\nJson From Expected: {string2}");
                        Log.Fail(message, errorMessage);
                    }

                    catch (ArgumentException ex)
                    {
                        Log.Write(ex.Message);
                        var error = new ErrorMessage("One of the models is empty");
                        Log.Fail(message, error);
                    }
                    catch (Exception ex)
                    {
                        Log.Warning(ex.Message);
                    }
                }
            }
        }
    }
}