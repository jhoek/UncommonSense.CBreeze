﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Code.Function;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Property.Type;

namespace UncommonSense.CBreeze.Script
{
    public static class HelperMethods
    {
        public static string FunctionType(this Function function)
        {
            if (function.TestFunctionType.HasValue)
                return "TestFunction";
#if NAV2015
            if (function.UpgradeFunctionType.HasValue)
                return "UpgradeFunction";
#endif
#if NAV2016
            if (!function.Event.HasValue)
                return "Function";
            if (function.Event == EventPublisherSubscriber.Subscriber)
                return "EventSubscriberFunction";
            if (function.EventType == EventType.Business)
                return "BusinessEventPublisherFunction";

            return "IntegrationEventPublisherFunction";
#else
            return "Function";
#endif
        }

        public static string Escape(this string text)
        {
            return text.Replace("'", "''"); 
        }

        public static IEnumerable<T> ToEnumerable<T>(this T item) => new T[] { item };
    }
}
