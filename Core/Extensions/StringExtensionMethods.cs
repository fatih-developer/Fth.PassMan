namespace Core.Extensions
{
    public static class StringExtensionMethods
    {
        public static bool IsNumeric(this string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            return decimal.TryParse(str, out _);
        }

        public static bool IsInt(this string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            return int.TryParse(str, out _);
        }
    }
}