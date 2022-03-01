using System;

namespace Helpers.Helper.Convert
{
    public static class ConvertHelper
    {
        public static string Now()
        {            
            var dateNow = DateTime.Now.ToString("o");
            return dateNow;
        }
    }

    public static partial class Extensions
    {
        /// <summary>
        ///     Converts a time to the time in a particular time zone.
        /// </summary>
        /// <param name="dateTimeOffset">The date and time to convert.</param>
        /// <param name="destinationTimeZone">The time zone to convert  to.</param>
        /// <returns>The date and time in the destination time zone.</returns>
        public static DateTimeOffset ConvertTime(this DateTimeOffset dateTimeOffset)
        {
            //2022.01.22
            //https://csharp-extension.com/en/method/1002275/datetimeoffset-converttime
            //https://dotnetfiddle.net/zcc9CF
            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            return TimeZoneInfo.ConvertTime(dateTimeOffset, tst);
        }
    }
}
