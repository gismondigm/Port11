﻿using Microsoft.CSharp.RuntimeBinder;
using Port11.Models;
using System;
using System.Text;
using System.Threading;

namespace Port11.Utilities
{
    public class Helper
    {
        public static readonly Random GetRandom = new Random();
        public static string SplitCamelCase(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
        }
        public static int GetCurrentEpochTime()
        {
            return (int)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
        public static int GetEpochTimeFromDateTime(DateTime input)
        {
            return (int)(input - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
        public static string GetEpochJsonStringFromDateTime(DateTime input)
        {
            return $"/Date({GetEpochTimeFromDateTime(input)})/";
        }
        public static string GetCurrentEpochJsonString()
        {
            return $"/Date({GetCurrentEpochTime()})/";
        }

        public static bool IsNumeric(string s)
        {
            return int.TryParse(s, out _);
        }
        public static void Wait(double seconds)
        {
            var milisecondsDouble = seconds * 1000;
            var miliseconds = (int)milisecondsDouble;
            Thread.Sleep(miliseconds);
        }

        public static int GetRandomNumber(int min, int max)
        {
            lock (GetRandom)
            {
                return GetRandom.Next(min, max);
            }
        }
        public static bool IsPropertyExist(dynamic dynamicObject, string property)
        {
            try
            {
                var value = dynamicObject.property;
                Log.Info(value);
                return true;
            }
            catch (RuntimeBinderException)
            {
                return false;
            }
        }
        public static string GetFormattedUrl(string url)
        {
            var formattedUrl = url.Replace("=&", "&");
            if (formattedUrl.StartsWith("/"))
            {
                formattedUrl = formattedUrl.TrimStart('/');
            }
            return formattedUrl;
        }
        public static string EncodeTo64(string toEncode)
        {
            var toEncodeAsBytes = Encoding.ASCII.GetBytes(toEncode);
            var returnValue = Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
        public static string GetAuthBase64TokenFromPersonalAccessToken(string personalAccessToken)
        {
            var value = Convert.ToBase64String(
                Encoding.ASCII.GetBytes(
                    $":{personalAccessToken}"));
            return $"Basic {value}";
        }
    }
}
