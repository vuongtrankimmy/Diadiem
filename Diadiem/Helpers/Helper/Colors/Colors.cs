using System;

namespace Helpers.Helper.Colors
{
   public static class Colors
    {
        public static string Color()
        {
            var random = new Random();
            var color = $"#{random.Next(0x1000000):X6}"; // = "#A197B9"
            return color;
        }
    }
}
