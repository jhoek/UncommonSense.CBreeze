using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Patterns
{
    public class UserIDPattern : AddFieldsPattern
    {
        private Dictionary<Page, FieldPageControl> userIDControls = new Dictionary<Page, FieldPageControl>();

        public UserIDPattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
        }

        protected override void CreateFields()
        {
            UserIDField = Table.Fields.Add(new CodeTableField(Range.GetNextTableFieldNo(Table), "User ID", 50).AutoCaption());
            UserIDField.Properties.TableRelation.Set(BaseApp.TableNames.User, "User Name");
            UserIDField.Properties.TestTableRelation = false;
            UserIDField.Properties.ValidateTableRelation = false;

            var userMgt = UserIDField.Properties.OnValidate.Variables.Add(new CodeunitVariable(Range.GetNextVariableID(UserIDField.Properties.OnValidate), "UserMgt", BaseApp.CodeunitIDs.User_Management));
            UserIDField.Properties.OnValidate.CodeLines.Add("{0}.ValidateUserID({1});", userMgt.Name, UserIDField.Name.Quoted());

            userMgt = UserIDField.Properties.OnLookup.Variables.Add(new CodeunitVariable(Range.GetNextVariableID(UserIDField.Properties.OnLookup), "UserMgt", BaseApp.CodeunitIDs.User_Management));
            UserIDField.Properties.OnLookup.CodeLines.Add("{0}.LookupUserID({1});", userMgt.Name, UserIDField.Name.Quoted());
        }

        protected override void CreateListPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByType(GroupType.Repeater, Range, Position.FirstWithinContainer);
            var userIDControl = group.AddFieldPageControl(Range.GetNextPageControlID(page), Position.LastWithinContainer, UserIDField.Name);

            userIDControls.Add(page, userIDControl);
        }

        public CodeTableField UserIDField
        {
            get;
            protected set;
        }

        public ReadOnlyDictionary<Page, FieldPageControl> UserIDControls
        {
            get
            {
                return userIDControls.AsReadOnly();
            }
        }
    }
}
