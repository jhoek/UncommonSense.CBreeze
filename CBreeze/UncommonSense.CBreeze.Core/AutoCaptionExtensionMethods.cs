using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public static class AutoCaptionExtensionMethods
    {
        public static T AutoCaption<T>(this T item, bool condition = true) where T : IHasProperties, IHasName
        {
            if (condition)
            {
                var captionML = item.AllProperties["CaptionML"];

                if (captionML != null)
                    (captionML as MultiLanguageProperty).Value.Set("ENU", item.GetName());
            }

            return item;
        }

        public static T AutoOptionCaption<T>(this T item, bool condition = true) where T : IHasProperties, IHasOptionString
        {
            if (condition)
            {
                var optionCaptionML = item.AllProperties["OptionCaptionML"];

                if (optionCaptionML != null)
                    (optionCaptionML as MultiLanguageProperty).Value.Set("ENU", item.GetOptionString());
            }

            return item;
        }
    }
}
