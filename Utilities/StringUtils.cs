using System.Globalization;
using System.Text;

namespace study_together_api.Utilities
{
    public static class StringUtils
    {

        private static readonly TextInfo TextCulture = new CultureInfo("en-US", false).TextInfo;

        /// <summary>
        /// Simple converter to <i>TitleCase</i> using <b>CultureInfo</b>.
        /// Will improve with custom algorithm if needed later on.
        /// </summary>
        /// <param name="V">String value to convert</param>
        /// <returns>Converted string value</returns>
        public static string ToTitleCase(string V)
        {
            return TextCulture.ToTitleCase(V);
        }

        /// <summary>
        /// Simple converter to <i>lowercase</i> using <b>CultureInfo</b>.
        /// Will improve with custom algorithm if needed later on.
        /// </summary>
        /// <param name="V">String value to convert</param>
        /// <returns>Converted string value</returns>
        public static string ToLowerCase(string V)
        {
            return TextCulture.ToLower(V);
        }

        /// <summary>
        /// Simple converter to <i>UPPERCASE</i> using <b>CultureInfo</b>.
        /// Will improve with custom algorithm if needed later on.
        /// </summary>
        /// <param name="V">String value to convert</param>
        /// <returns>Converted string value</returns>
        public static string ToUpperCase(string V)
        {
            return TextCulture.ToUpper(V);
        }

        /// <summary>
        /// Simple converter to <i>camelCase</i> using <b>CultureInfo</b>.
        /// Will improve with custom algorithm if needed later on.
        /// </summary>
        /// <param name="V">String value to convert</param>
        /// <returns>Converted string value</returns>
        public static string ToCamelCase(string V)
        {
            var first = Char.ToLower(V.ToCharArray()[0]);
            return first + ToTitleCase(V)[1..];
        }

        public static string ConcatWhitespace(string Whitespace, string[] V)
        {
            StringBuilder builder = new();
            return builder.AppendJoin(Whitespace, V).ToString();
        }
    }
}