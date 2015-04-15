using System;
using System.Linq;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class TableProperties : Properties
	{
		private ReferenceProperty<MultiLanguageValue> captionML = new ReferenceProperty<MultiLanguageValue>("CaptionML");
		//        private ReferenceProperty<FieldList> dataCaptionFields = new ReferenceProperty<FieldList>("DataCaptionFields");
		private ValueProperty<int?> lookupPageID = new ValueProperty<int?>("LookupPageID");
		private ValueProperty<bool?> dataPerCompany = new ValueProperty<bool?>("DataPerCompany");


		/*
CORE	TableProperties	DataPerCompany	NullableBooleanProperty	dataPerCompany	10
CORE	TableProperties	Description	StringProperty	description	90
CORE	TableProperties	DrillDownPageID	PageReferenceProperty	drillDownPageID	120
CORE	TableProperties	LinkedInTransaction	NullableBooleanProperty	linkedInTransaction	130
CORE	TableProperties	LinkedObject	NullableBooleanProperty	linkedObject	140
CORE	TableProperties	LookupPageID	PageReferenceProperty	lookupPageID	110
CORE	TableProperties	OnDelete	TriggerProperty	onDelete	60
CORE	TableProperties	OnInsert	TriggerProperty	onInsert	40
CORE	TableProperties	OnModify	TriggerProperty	onModify	50
CORE	TableProperties	OnRename	TriggerProperty	onRename	70
CORE	TableProperties	PasteIsValid	NullableBooleanProperty	pasteIsValid	100
CORE	TableProperties	Permissions	PermissionsProperty	permissions	20
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

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return captionML;
				yield return dataPerCompany;
				yield return lookupPageID;
			}
		}
	}
}

