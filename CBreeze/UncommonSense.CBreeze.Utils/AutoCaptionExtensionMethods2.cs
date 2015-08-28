using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class AutoCaptionExtensionMethods2
    {
        public static T AutoCaption<T>(this T item) where T : IHasProperties
        {
            var captionML = item.AllProperties.FirstOrDefault(p => p.Name == "CaptionML");

            if (captionML != null)
                (captionML as MultiLanguageProperty).Value.Set("ENU", "FIXME");

            return item;
        }
    }
}
