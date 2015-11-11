using System;

namespace UncommonSense.CBreeze.Parse
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

    public enum XmlPortNodeType
    {
        Element,
        Attribute
    }

    public enum XmlPortSourceType
    {
        Text,
        Table,
        Field
    }

    public enum ReportElementType
    {
        DataItem,
        Column
    }
}

