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
                var property = item.AllProperties["CaptionML"];

                if (property != null)
                {
                    var typedProperty = (property as MultiLanguageProperty);
                    typedProperty.Value.Set("ENU", typedProperty.Value["ENU"] ?? item.GetName());
                }
            }

            return item;
        }

        public static T AutoOptionCaption<T>(this T item, bool condition = true) where T : IHasProperties, IHasOptionString
        {
            if (condition)
            {
                var property = item.AllProperties["OptionCaptionML"];

                if (property != null)
                {
                    var typedProperty = (property as MultiLanguageProperty);
                    typedProperty.Value.Set("ENU", typedProperty.Value["ENU"] ?? item.GetOptionString());
                }
            }

            return item;
        }
    }
}
