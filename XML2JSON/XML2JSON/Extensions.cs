namespace XML2JSON
{
	using System;
  using System.Globalization;

  public static class Extensions
	{
		public static string RemoveHyphen(this string str)
		{
      var textInfo = new CultureInfo("en-US", false).TextInfo;
      str = textInfo.ToTitleCase(str);
			if (str.Contains("-"))
			{
				return str.Replace("-", "");
			}

      return str;
    }
		public static string ToCamelCase(this string str)
		{
      if (!string.IsNullOrEmpty(str) && str.Length > 1)
			{
				return char.ToLowerInvariant(str[0]) + str.Substring(1);
			}
			return str;
		}
	}
}
