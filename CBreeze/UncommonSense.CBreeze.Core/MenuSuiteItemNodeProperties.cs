using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class MenuSuiteItemNodeProperties : Properties
    {
#if NAV2015
        private AccessByPermissionProperty accessByPermission = new AccessByPermissionProperty("AccessByPermission");
#endif
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private NullableBooleanProperty deleted = new NullableBooleanProperty("Deleted");
        private MenuItemDepartmentCategoryProperty departmentCategory = new MenuItemDepartmentCategoryProperty("DepartmentCategory");
        private NullableGuidProperty memberOfMenu = new NullableGuidProperty("MemberOfMenu");
        private StringProperty name = new StringProperty("Name");
        private NullableGuidProperty nextNodeID = new NullableGuidProperty("NextNodeID");
        private NullableGuidProperty parentNodeID = new NullableGuidProperty("ParentNodeID");
        private NullableIntegerProperty runObjectID = new NullableIntegerProperty("RunObjectID");
        private MenuItemRunObjectTypeProperty runObjectType = new MenuItemRunObjectTypeProperty("RunObjectType");
        private NullableBooleanProperty visible = new NullableBooleanProperty("Visible");

        internal MenuSuiteItemNodeProperties()
        {
            innerList.Add(name);
#if NAV2015
            innerList.Add(accessByPermission);
#endif
            innerList.Add(captionML);
            innerList.Add(memberOfMenu);
            innerList.Add(runObjectType);
            innerList.Add(runObjectID);
            innerList.Add(parentNodeID);
            innerList.Add(visible);
            innerList.Add(nextNodeID);
            innerList.Add(deleted);
            innerList.Add(departmentCategory);
        }

#if NAV2015
        public AccessByPermission AccessByPermission
        {
            get
            {
                return this.accessByPermission.Value;
            }
        }
#endif

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public bool? Deleted
        {
            get
            {
                return this.deleted.Value;
            }
            set
            {
                this.deleted.Value = value;
            }
        }

        public MenuItemDepartmentCategory? DepartmentCategory
        {
            get
            {
                return this.departmentCategory.Value;
            }
            set
            {
                this.departmentCategory.Value = value;
            }
        }

      public System.Guid? MemberOfMenu
        {
            get
            {
                return this.memberOfMenu.Value;
            }
            set
            {
                this.memberOfMenu.Value = value;
            }
        }

      public string Name
        {
            get
            {
                return this.name.Value;
            }
            set
            {
                this.name.Value = value;
            }
        }

      public System.Guid? NextNodeID
        {
            get
            {
                return this.nextNodeID.Value;
            }
            set
            {
                this.nextNodeID.Value = value;
            }
        }

      public System.Guid? ParentNodeID
        {
            get
            {
                return this.parentNodeID.Value;
            }
            set
            {
                this.parentNodeID.Value = value;
            }
        }

      public int? RunObjectID
        {
            get
            {
                return this.runObjectID.Value;
            }
            set
            {
                this.runObjectID.Value = value;
            }
        }

        public MenuItemRunObjectType? RunObjectType
        {
            get
            {
                return this.runObjectType.Value;
            }
            set
            {
                this.runObjectType.Value = value;
            }
        }

      public bool? Visible
        {
            get
            {
                return this.visible.Value;
            }
            set
            {
                this.visible.Value = value;
            }
        }
    }
}
