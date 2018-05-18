using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Extension
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
