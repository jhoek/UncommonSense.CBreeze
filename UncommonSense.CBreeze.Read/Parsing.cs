using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UncommonSense.CBreeze.Read
{
    internal static class Parsing
    {
        [DebuggerStepThrough()]
        internal static bool TryMatch(ref string text, string pattern)
        {
            return TryMatch(ref text, new Regex(pattern));
        }

        [DebuggerStepThrough()]
        internal static bool TryMatch(ref string text, Regex regex)
        {
            Match match;
            return TryMatch(ref text, regex, out match);
        }

        [DebuggerStepThrough()]
        internal static bool TryMatch(ref string text, string pattern, out Match match)
        {
            return TryMatch(ref text, new Regex(pattern), out match);
        }

        [DebuggerStepThrough()]
        internal static bool TryMatch(ref string text, Regex regex, out Match match)
        {
            match = regex.Match(text);

            if (match.Success)
            {
                text = text.Substring(match.Length);
                return true;
            }

            return false;
        }

        [DebuggerStepThrough()]
        internal static Match MustMatch(ref string text, string pattern)
        {
            return MustMatch(ref text, new Regex(pattern));
        }

        [DebuggerStepThrough()]
        internal static Match MustMatch(ref string text, Regex regex)
        {
            var match = regex.Match(text);

            if (!match.Success)
                throw new ApplicationException(string.Format("'{0}' does not match pattern '{1}'.", text, regex));

            text = text.Substring(match.Length);
            return match;
        }

        [DebuggerStepThrough()]
        internal static string MatchUntil(ref string value, char until, char ignoreBetween)
        {
            var length = value.Length;
            var index = 0;
            var ignoring = false;

            while (index < length)
            {
                var currentChar = value[index];

                if (currentChar == until && !ignoring)
                    break;

                if (currentChar == ignoreBetween)
                    ignoring = !ignoring;

                index++;
            }

            var result = value.Substring(0, index);
            value = value.Substring(index + 1);

            return result;
        }

        internal static string MatchUntilUnnested(ref string value, char closing, char opening)
        {
            var length = value.Length;
            var index = 0;
            var nestingLevel = 1;

            while (index < length)
            {
                var currentChar = value[index];

                if (currentChar == opening)
                {
                    nestingLevel++;
                }
                else if (currentChar == closing)
                {
                    nestingLevel--;
                    if (nestingLevel == 0)
                        break;
                }

                index++;
            }

            var result = value.Substring(0, index);
            value = value.Substring(index + 1);

            return result;
        }

        internal static string MatchUntilSingle(ref string value, char until)
        {
            var length = value.Length - 1;
            var index = 0;

            while (index < length)
            {
                var currentChar = value[index];
                var nextChar = value[index + 1];

                if (currentChar == until)
                    if (nextChar != until)
                        break;
                    else
                        index++;

                index++;
            }

            var result = value.Substring(0, index);
            value = value.Substring(index + 1);

            return result;
        }
    }
}
