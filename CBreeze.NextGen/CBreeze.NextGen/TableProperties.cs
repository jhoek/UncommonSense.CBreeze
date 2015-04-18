using System;
using System.Linq;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class TableProperties : Properties
	{
		private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
		private FieldListProperty dataCaptionFields = new FieldListProperty("DataCaptionFields");
		private NullableIntProperty lookupPageID = new NullableIntProperty("LookupPageID");
		private NullableIntProperty drillDownPageID = new NullableIntProperty("DrillDownPageID");
		private NullableBoolProperty dataPerCompany = new NullableBoolProperty("DataPerCompany");
		private StringProperty description = new StringProperty("Description");
		//		private NullableBoolProperty linkedInTransaction = new NullableBoolProperty("LinkedInTransaction");
		//		private NullableBoolProperty linkedObject = new NullableBoolProperty("LinkedObject");
		//		private TriggerProperty onInsert = new TriggerProperty("OnInsert");
		//		private TriggerProperty onModify = new TriggerProperty("OnModify");
		//		private TriggerProperty onDelete = new TriggerProperty("OnDelete");
		//		private TriggerProperty onRename = new TriggerProperty("OnRename");

		/*
			<member name="PasteIsValid" propertyType="NullableBooleanProperty" fieldName="pasteIsValid" sortOrder="100"/>
			<member name="Permissions" propertyType="PermissionsProperty" fieldName="permissions" sortOrder="20"/>
         */

		internal TableProperties(Node parentNode)
			: base(parentNode)
		{
		}

		public override string ToString()
		{
			return "Properties";
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

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return captionML;
				yield return dataPerCompany;
				yield return dataCaptionFields;
				yield return lookupPageID;
			}
		}
	}
}

