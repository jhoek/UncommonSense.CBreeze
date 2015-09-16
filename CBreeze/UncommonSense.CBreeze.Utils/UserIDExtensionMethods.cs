using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class UserIDExtensionMethods
    {
        public static UserIDControlsManifest AddUserIDControls(this Page page, UserIDFieldsManifest fieldsManifest, IEnumerable<int> range)
        {
            var manifest = new UserIDControlsManifest();
            var contentArea = page.GetContentArea(range);

            switch(page.Properties.PageType)
            {
                case PageType.List:
                    var listGroup = contentArea.GetGroupByType(GroupType.Repeater, range, Position.FirstWithinContainer);
                    manifest.UserIDControl = listGroup.AddChildPageControl(page.Controls.Add(new FieldPageControl(range.GetNextPageControlID(page), 2)), Position.LastWithinContainer);
                    manifest.UserIDControl.Properties.SourceExpr = fieldsManifest.UserIDField.Name.Quoted();
                    break;
            }

            return manifest;
        }
    }
}
