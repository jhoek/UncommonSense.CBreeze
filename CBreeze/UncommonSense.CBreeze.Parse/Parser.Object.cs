using System;
using System.Linq;
using System.Xml;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
	public partial class Parser
	{
		internal void ParseObject(Lines lines)
		{
			var match = lines.FirstLineMustMatch(Patterns.ObjectSignature);
			var objectType = match.Groups [1].Value.ToEnum<ObjectType>();
			var objectID = match.Groups [2].Value.ToInteger();
			var objectName = match.Groups [3].Value;

			Listener.OnBeginObject(objectType, objectID, objectName);

			lines.FirstLineMustMatch(Patterns.BeginObject);
			lines.LastLineTryMatch(Patterns.BlankLine);
			lines.LastLineMustMatch(Patterns.EndObject);

            // Because of the odd indentation of RDLData, we need to extract it 
            // first (if present), so that the remaining lines follow the normal
            // section pattern.
            if (objectType == ObjectType.Report)
            {
                ParseRdlDataSection(lines);
            }

            lines.Unindent(2);

			foreach (var chunk in lines.Chunks(Patterns.SectionSignature))
			{
				ParseSection(chunk, objectType);
			}

			Listener.OnEndObject();
		}
	}
}

