using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public class UserIDFieldsManifest
    {
        internal UserIDFieldsManifest()
        {
        }

        public CodeTableField UserIDField
        {
            get;
            internal set;
        }
    }

    public class UserIDControlsManifest
    {
        internal UserIDControlsManifest()
        {
        }

        public FieldPageControl UserIDControl
        {
            get;
            internal set;
        }
    }

    public static class UserIDExtensionMethods
    {
        public static UserIDFieldsManifest AddUserIDFields(this Table table, IEnumerable<int> range)
        {
            var manifest = new UserIDFieldsManifest();

            manifest.UserIDField = table.Fields.Add(new CodeTableField(range.GetNextTableFieldNo(table), "User ID", 50).AutoCaption());
            manifest.UserIDField.Properties.TableRelation.Set(BaseApp.TableNames.User, "User Name");
            manifest.UserIDField.Properties.TestTableRelation = false;
            manifest.UserIDField.Properties.ValidateTableRelation = false;

            var userMgtVariable = manifest.UserIDField.Properties.OnValidate.Variables.Add(new CodeunitVariable(range.GetNextVariableID(manifest.UserIDField.Properties.OnValidate), "UserMgt", 418));
            manifest.UserIDField.Properties.OnValidate.CodeLines.Add("{0}.ValidateUserID({1});", userMgtVariable.Name, manifest.UserIDField.Name.Quoted());

            userMgtVariable = manifest.UserIDField.Properties.OnLookup.Variables.Add(new CodeunitVariable(range.GetNextVariableID(manifest.UserIDField.Properties.OnLookup), "UserMgt", 418));
            manifest.UserIDField.Properties.OnLookup.CodeLines.Add("{0}.LookupUserID({1});", userMgtVariable.Name, manifest.UserIDField.Name.Quoted());

            return manifest;
        }

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
