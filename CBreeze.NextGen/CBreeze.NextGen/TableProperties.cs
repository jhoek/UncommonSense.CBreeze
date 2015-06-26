using System;
using System.Linq;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class TableProperties : Properties
	{
		private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
		private FieldListProperty dataCaptionFields = new FieldListProperty("DataCaptionFields");
		private NullableValueProperty<int> lookupPageID = new NullableValueProperty<int>("LookupPageID");
		private NullableValueProperty<int> drillDownPageID = new NullableValueProperty<int>("DrillDownPageID");
		private NullableValueProperty<bool> dataPerCompany = new NullableValueProperty<bool>("DataPerCompany");
		private StringProperty description = new StringProperty("Description");
		private NullableValueProperty<bool> linkedInTransaction = new NullableValueProperty<bool>("LinkedInTransaction");
		private NullableValueProperty<bool> linkedObject = new NullableValueProperty<bool>("LinkedObject");
		private TriggerProperty onInsert = new TriggerProperty("OnInsert");
		private TriggerProperty onModify = new TriggerProperty("OnModify");
		private TriggerProperty onDelete = new TriggerProperty("OnDelete");
		private TriggerProperty onRename = new TriggerProperty("OnRename");
		private NullableValueProperty<bool> pasteIsValid = new NullableValueProperty<bool>("PasteIsValid");
		private PermissionsProperty permissions = new PermissionsProperty("Permissions");

		internal TableProperties(Node parentNode)
			: base(parentNode)
		{
		}

		public MultiLanguageValue CaptionML
		{
			get
			{
				return this.captionML.Value;
			}
		}

		public FieldList DataCaptionFields
		{
			get
			{
				return this.dataCaptionFields.Value;
			}
		}

		public int? LookupPageID
		{
			get
			{
				return this.lookupPageID.Value;
			}
			set
			{
				this.lookupPageID.Value = value;
			}
		}

		public int? DrillDownPageID
		{
			get
			{
				return this.drillDownPageID.Value;
			}
			set
			{
				this.drillDownPageID.Value = value;
			}
		}

		public bool? DataPerCompany
		{
			get
			{
				return this.dataPerCompany.Value;
			}
			set
			{
				this.dataPerCompany.Value = value;
			}
		}

		public string Description
		{
			get
			{
				return this.description.Value;
			}
			set
			{
				this.description.Value = value;
			}
		}

		public bool? LinkedInTransaction
		{
			get
			{
				return this.linkedInTransaction.Value;
			}set
			{
				this.linkedInTransaction.Value = value;
			}
		}

		public bool? LinkedObject
		{
			get
			{
				return this.linkedObject.Value;
			}set
			{
				this.linkedObject.Value = value;
			}
		}

		public Trigger OnInsert
		{
			get
			{
				return this.onInsert.Value;
			}
		}

		public Trigger OnModify
		{
			get
			{
				return this.onModify.Value;
			}
		}

		public Trigger OnDelete
		{
			get
			{
				return this.onDelete.Value;
			}
		}

		public Trigger OnRename
		{
			get
			{
				return this.onRename.Value;
			}
		}

		public bool? PasteIsValid
		{
			get
			{
				return this.pasteIsValid.Value;
			}set
			{
				this.pasteIsValid.Value = value;
			}
		}

		public Permissions Permissions
		{
			get
			{
				return this.permissions.Value;
			}
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return captionML;
				yield return dataCaptionFields;
				yield return lookupPageID;
				yield return drillDownPageID;
				yield return dataPerCompany;
				yield return description;
				yield return linkedInTransaction;
				yield return linkedObject;
				yield return onInsert;
				yield return onModify;
				yield return onDelete;
				yield return onRename;
				yield return pasteIsValid;
				yield return permissions;
			}
		}
	}
}

