namespace UncommonSense.CBreeze.Core.Code.Function
{
    public enum TestFunctionType
    {
        Normal,
        Test,
        MessageHandler,
        ConfirmHandler,
        StrMenuHandler,
        PageHandler,
        ModalPageHandler,
        ReportHandler,
        RequestPageHandler,
#if NAV2016
        FilterPageHandler,
        HyperlinkHandler,
#endif
#if NAV2017
        SendNotificationHandler,
        RecallNotificationHandler
#endif
    }
    // 
}
