using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class CodeunitProperties : Properties
	{
		private NullableValueProperty<bool> cfrontMayUsePermissions = new NullableValueProperty<bool>("CFRONTMayUsePermissions");
		private TriggerProperty onRun = new TriggerProperty("OnRun");
		private PermissionsProperty permissions = new PermissionsProperty();
		private NullableValueProperty<bool> singleInstance = new NullableValueProperty<bool>("SingleInstance");
		private NullableValueProperty<CodeunitSubType> subType = new NullableValueProperty<CodeunitSubType>("Subtype");
		private NullableValueProperty<int> tableNo = new NullableValueProperty<int>("TableNo");
		private NullableValueProperty<TestIsolation> testIsolation = new NullableValueProperty<TestIsolation>("TestIsolation");

		internal CodeunitProperties(Node parentNode)
			: base(parentNode)
		{
		}

		public bool? CFrontMayUsePermissions
		{
			get
			{
				return this.cfrontMayUsePermissions.Value;
			}
			set
			{
				this.cfrontMayUsePermissions.Value = value;
			}
		}

		public Trigger OnRun
		{
			get
			{
				return onRun.Value;
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

		public CodeunitSubType? SubType
		{
			get
			{
				return this.subType.Value;
			}set
			{
				this.subType.Value = value;
			}
		}

		public int? TableNo
		{
			get
			{
				return this.tableNo.Value;
			}set
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

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return this.tableNo;
				yield return this.permissions;
				yield return this.cfrontMayUsePermissions;
				yield return this.singleInstance;
				yield return this.subType;
				yield return this.testIsolation;
				yield return this.onRun;
			}
		}
	}
}

