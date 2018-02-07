using System.Text;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseProperty(Lines lines, bool mayHaveTriggers)
        {
            if (mayHaveTriggers)
                if (ParseTrigger(lines))
                    return;

            var match = lines.FirstLineMustMatch(Patterns.PropertySignature);
            var propertyName = match.Groups[1].Value;
            var propertyValueFirstLine = match.Groups[2].Value;

            if (propertyName == "ActionList")
            {
                lines.FirstLineMustMatch(Patterns.BeginSection);
                lines.LastLineMustMatch(Patterns.EndSection);
                lines.Unindent(2);
                ParseActionList(lines);
                return;
            }

            var stringBuilder = new StringBuilder(propertyValueFirstLine);
            lines.Unindent(propertyName.Length + 1);

            foreach (var line in lines)
            {
                stringBuilder.AppendFormat(" {0}", line.TrimStart());
                // stringBuilder.Append(line.TrimStart());
            }

            var propertyValue = stringBuilder.ToString().TrimEnd(";".ToCharArray());

            Listener.OnProperty(propertyName, propertyValue);
        }
    }
}