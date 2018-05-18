namespace UncommonSense.CBreeze.Core.Codeunit
{
    public enum CodeunitSubType
    {
        Normal,
        Test,
        TestRunner,
#if NAV2015
        Upgrade,
#endif
    }

}
