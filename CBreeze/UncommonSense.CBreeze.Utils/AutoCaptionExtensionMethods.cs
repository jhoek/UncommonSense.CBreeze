using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class AutoCaptionExtensionMethods
    {
        public static T AutoCaption<T>(this T item) where T : IHasProperties, IHasName
        {
            var captionML = item.AllProperties["CaptionML"];

            if (captionML != null)
                (captionML as MultiLanguageProperty).Value.Set("ENU", item.GetName());

            return item;
        }

        public static T AutoOptionCaption<T>(this T item) where T : IHasProperties, IHasOptionString
        {
            var optionCaptionML = item.AllProperties["OptionCaptionML"];

            if (optionCaptionML != null)
                (optionCaptionML as MultiLanguageProperty).Value.Set("ENU", item.GetOptionString());

            return item;
        }
    }
}
