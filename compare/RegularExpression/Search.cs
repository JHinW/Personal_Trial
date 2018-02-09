using RegularExpression;
using System;
using System.Text.RegularExpressions;


namespace Reguration
{
    public class Search
    {
        // https://www.dotnetperls.com/regex
        // https://docs.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions
        // https://docs.microsoft.com/en-us/dotnet/standard/base-types/anchors-in-regular-expressions
        public static Result GetMatchedLine(string destinationStr, string sourceStr)
        {
            var regexString = $@"{destinationStr}\s(\d+)\r?\n";
            MatchCollection matches = Regex.Matches(sourceStr, regexString);

            var ret = new Result();
            if (matches.Count == 0)
            {
                ret.isMactched = false;
                return ret;
            }

            ret.isMactched = true;
            ret.outputs = matches[0].Groups[1].Value;
            return ret;

        }
    }
}
