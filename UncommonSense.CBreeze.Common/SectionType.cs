using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Common
{
    public enum SectionType
    {
        // General:
        ObjectProperties,
        Properties,

        // Table:
        Fields,
        Keys,
        FieldGroups,

        // Page:
        Controls,

        // Query:
        Elements,

        // XmlPort:
        Events,
        RequestPage,

        // Report:
        Dataset,
        Labels,
        RdlData,
        WordLayout,

        // Menusuite:
        MenuNodes,

        // General:
        Code
    }
}
