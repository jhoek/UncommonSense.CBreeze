namespace UncommonSense.CBreeze.Core.Table
{
#if NAV2016
    public enum TableType
    {
        Normal,
        CRM,
        ExternalSQL,
#if NAV2017
        Exchange,
        MicrosoftGraph
#endif
    }
#endif
}
