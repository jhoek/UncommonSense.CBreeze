namespace UncommonSense.CBreeze.Core.Code.Function
{
#if NAV2015
    public enum UpgradeFunctionType
    {
        Normal,
#if NAV2016
        UpgradePerCompany,
#else
        Upgrade,
#endif
        TableSyncSetup,
        CheckPrecondition,
#if NAV2016
        UpgradePerDatabase,
#endif
    }
#endif
}
