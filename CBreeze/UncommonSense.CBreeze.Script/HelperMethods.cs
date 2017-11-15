using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script
{
    public static class HelperMethods
    {
        public static string FunctionType(this Function function)
        {
            if (function.TestFunctionType.HasValue)
                return "TestFunction";
            if (function.UpgradeFunctionType.HasValue)
                return "UpgradeFunction";
            if (!function.Event.HasValue)
                return "Function";
            if (function.Event == EventPublisherSubscriber.Subscriber)
                return "EventSubscriberFunction";
            if (function.EventType == EventType.Business)
                return "BusinessEventPublisherFunction";

            return "IntegrationEventPublisherFunction";
        }

        public static string Escape(this string text)
        {
            return text.Replace("'", "''"); 
        }
    }
}
