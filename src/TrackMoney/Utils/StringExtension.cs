using System.Globalization;

namespace TrackMoney.Utils;

internal static class StringExtension
{
    internal static bool IsEmpty(this string str) => string.IsNullOrWhiteSpace(str);
    internal static bool IsNotEmpty(this string str) => !string.IsNullOrWhiteSpace(str);
    internal static bool EqualsTo(this string str, string value) => str.Equals(value, StringComparison.InvariantCultureIgnoreCase);

    internal static string Translate(this string str, params object?[] pars)
    {
        var locStr = AppRes.ResourceManager.GetString(str);

        if (!string.IsNullOrWhiteSpace(locStr))
            try
            {
                locStr = string.Format(CultureInfo.CurrentCulture, locStr, pars);
            }
            catch (Exception)
            {
            }

        return locStr ?? str;
    }


}
