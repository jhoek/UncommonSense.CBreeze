using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseMenuSuiteNode(Lines lines)
        {
            var match = lines.FirstLineMustMatch(Patterns.MenuSuiteNode);
            var nodeType = match.Groups[1].Value.ToMenuSuiteNodeType();
            var nodeID = match.Groups[2].Value.ToGuid();
            var nodeSeparator = match.Groups[3].Value;

            Listener.OnBeginMenuSuiteNode(nodeType, nodeID);

            if (nodeSeparator == ";")
            {

                lines.Unindent(60);
                lines.LastLineMustMatch(Patterns.EndMenuSuiteNode);

                foreach (var chunk in lines.Chunks(Patterns.PropertySignature))
                {
                    ParseProperty(chunk, true);
                }
            }

            Listener.OnEndMenuSuiteNode();
        }
    }
}
