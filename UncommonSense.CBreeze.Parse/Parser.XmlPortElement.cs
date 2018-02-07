using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseXmlPortElement(Lines lines)
        {
            var match = lines.FirstLineMustMatch(Patterns.XmlPortElement);
            var elementID = match.Groups[1].Value.ToGuid();
            var elementIndentation = match.Groups[2].Value.ToNullableInteger();
            var elementName = match.Groups[3].Value;
            var elementNodeType = match.Groups[4].Value.ToEnum<XmlPortNodeType>();
            var elementSourceType = match.Groups[5].Value.ToEnum<XmlPortSourceType>();
            var elementSeparator = match.Groups[6].Value;

            Listener.OnBeginXmlPortElement(elementID, elementIndentation, elementName, elementNodeType, elementSourceType);

            if (elementSeparator == ";")
            {
                lines.Unindent(Math.Min(match.Length, 46));
                ParseXmlPortElementProperties(lines);
            }

            Listener.OnEndXmlPortElement();
        }
    }
}
