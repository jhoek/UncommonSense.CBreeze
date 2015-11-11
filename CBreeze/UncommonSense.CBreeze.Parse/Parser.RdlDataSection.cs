using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseRdlDataSection(Lines lines)
        {
            var rdlData = lines.Extract("  RDLDATA", "  }");

            if (rdlData != null)
            {
                rdlData.FirstLineMustMatch(Patterns.RdlDataSectionSignature);
                rdlData.FirstLineMustMatch(Patterns.BeginRdlDataSection);
                rdlData.LastLineMustMatch(Patterns.EndRdlDataSection);

                if (rdlData.Any())
                {
                    rdlData.LastLineMustMatch(Patterns.EndRdlData);

                    Listener.OnBeginSection(SectionType.RdlData);

                    foreach (var line in rdlData)
                    {
                        Listener.OnCodeLine(line);
                    }

                    Listener.OnEndSection();
                }
            }
        }
    }
}
