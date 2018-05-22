using UncommonSense.CBreeze.Core.Code.Function;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Codeunit
{
    public class CodeunitProperties : Properties
    {
#if NAV2016
        private EventSubscriberInstanceProperty eventSubscriberInstance = new EventSubscriberInstanceProperty("EventSubscriberInstance");
#endif
#if !NAV2016
        private NullableBooleanProperty cFRONTMayUsePermissions = new NullableBooleanProperty("CFRONTMayUsePermissions");
#endif
        private TriggerProperty onRun = new TriggerProperty("OnRun");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
        private NullableBooleanProperty singleInstance = new NullableBooleanProperty("SingleInstance");
        private CodeunitSubTypeProperty subtype = new CodeunitSubTypeProperty("Subtype");
        private NullableIntegerProperty tableNo = new NullableIntegerProperty("TableNo");
        private TestIsolationProperty testIsolation = new TestIsolationProperty("TestIsolation");
#if NAV2017
        private TestPermissionsProperty testPermissions = new TestPermissionsProperty("TestPermissions");
#endif

        internal CodeunitProperties(Codeunit codeunit)
        {
            Codeunit = codeunit;

            innerList.Add(tableNo);
#if NAV2016
            innerList.Add(eventSubscriberInstance);
#endif
            innerList.Add(permissions);
#if !NAV2016
            innerList.Add(cFRONTMayUsePermissions);
#endif
            innerList.Add(singleInstance);
            innerList.Add(subtype);
            innerList.Add(testIsolation);
#if NAV2017
            innerList.Add(testPermissions);
#endif
            innerList.Add(onRun);
        }

        public Codeunit Codeunit { get; protected set; }

        public override INode ParentNode => Codeunit;

#if NAV2016
        public EventSubscriberInstance? EventSubscriberInstance
        {
            get
            {
                return this.eventSubscriberInstance.Value;
            }
            set
            {
                this.eventSubscriberInstance.Value = value;
            }
        }
#endif

#if !NAV2016
        public bool? CFRONTMayUsePermissions
        {
            get
            {
                return this.cFRONTMayUsePermissions.Value;
            }
            set
            {
                this.cFRONTMayUsePermissions.Value = value;
            }
        }
#endif

        public Trigger OnRun
        {
            get
            {
                return this.onRun.Value;
            }
        }

        public Permissions Permissions
        {
            get
            {
                return this.permissions.Value;
            }
        }

        public bool? SingleInstance
        {
            get
            {
                return this.singleInstance.Value;
            }
            set
            {
                this.singleInstance.Value = value;
            }
        }

        public CodeunitSubType? Subtype
        {
            get
            {
                return this.subtype.Value;
            }
            set
            {
                this.subtype.Value = value;
            }
        }

        public int? TableNo
        {
            get
            {
                return this.tableNo.Value;
            }
            set
            {
                this.tableNo.Value = value;
            }
        }

        public TestIsolation? TestIsolation
        {
            get
            {
                return this.testIsolation.Value;
            }
            set
            {
                this.testIsolation.Value = value;
            }
        }

#if NAV2017
        public TestPermissions? TestPermissions
        {
            get => testPermissions.Value;
            set => testPermissions.Value = value;
        }
#endif
    }
}
