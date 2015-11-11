using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace UncommonSense.CBreeze.Parse
{
    [DebuggerStepThrough()]
    internal static class LinesExtensionMethods
    {
        internal static Match FirstLineMustMatch(this Lines lines, Regex regex)
        {
            return LineMustMatch(lines, 0, regex);
        }

        internal static Match LastLineMustMatch(this Lines lines, Regex regex)
        {
            return LineMustMatch(lines, lines.Count() - 1, regex);
        }

        internal static Match LineMustMatch(this Lines lines, int lineNo, Regex regex)
        {
            var line = lines[lineNo];
            var match = regex.Match(line);

            if (!match.Success)
                Exceptions.ThrowException(Exceptions.TextDoesNotMatchPattern, line, regex);

            lines.Consume(lineNo, match.Index, match.Length);

            return match;
        }

        [DebuggerStepThrough()]
        internal static bool FirstLineTryMatch(this Lines lines, Regex regex)
        {
            Match match;
            return FirstLineTryMatch(lines, regex, out match);
        }

        [DebuggerStepThrough()]
        internal static bool FirstLineTryMatch(this Lines lines, Regex regex, out Match match)
        {
            return LineTryMatch(lines, 0, regex, out match);
        }

        internal static bool LastLineTryMatch(this Lines lines, Regex regex)
        {
            Match match;
            return LastLineTryMatch(lines, regex, out match);
        }

        internal static bool LastLineTryMatch(this Lines lines, Regex regex, out Match match)
        {
            return LineTryMatch(lines, lines.Count() - 1, regex, out match);
        }

        [DebuggerStepThrough()]
        internal static bool LineTryMatch(this Lines lines, int lineNo, Regex regex, out Match match)
        {
            if (!lines.Any())
            {
                match = null;
                return false;
            }

            var line = lines[lineNo];
            match = regex.Match(line);

            if (match.Success)
            {
                lines.Consume(lineNo, match.Index, match.Length);
            }

            return match.Success;
        }
    }
}

