using System;
using System.Linq;
using System.Management.Automation;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation 
{
	[Cmdlet(VerbsCommon.Add, "CBreezeXmlPortFieldAttribute")]
	[OutputType(typeof(XmlPortFieldAttribute))]
	[Alias("FieldAttribute")]
	public class AddCBreezeXmlPortFieldAttribute : NewNamedItemCmdlet<XmlPortFieldAttribute, Guid, PSObject>
	{
		protected override XmlPortFieldAttribute CreateItem()
		{
			var xmlPortFieldAttribute = new XmlPortFieldAttribute(Name, GetIndentation(), ID);

			xmlPortFieldAttribute.Properties.AutoCalcField = AutoCalcField;
			xmlPortFieldAttribute.Properties.DataType = DataType;
			xmlPortFieldAttribute.Properties.FieldValidate = FieldValidate;
			xmlPortFieldAttribute.Properties.Occurrence = Occurrence;
			xmlPortFieldAttribute.Properties.SourceField = SourceField;
			xmlPortFieldAttribute.Properties.Width = Width;

			return xmlPortFieldAttribute;
		}

		protected override void AddItemToInputObject(XmlPortFieldAttribute item, PSObject inputObject)
		{
			throw new NotImplementedException(); // FIXME
		}

		protected int? GetIndentation()
		{
			switch(ParameterSetName)
			{
				case ParameterSetNames.AddWithID:
				case ParameterSetNames.AddWithoutID:
					return null; // FIXME
					
				case ParameterSetNames.NewWithID:
				case ParameterSetNames.NewWithoutID:
					return (int?)GetVariableValue("Indentation", null);

				default: 
					return null;
			}
		}

		[Parameter()]
		public Nullable<Boolean> AutoCalcField { get; set; }

		[Parameter()]
		public Nullable<XmlPortNodeDataType> DataType { get; set; }

		[Parameter()]
		public Nullable<Boolean> FieldValidate { get; set; }

		[Parameter()]
		public Nullable<Occurrence> Occurrence { get; set; }

		[Parameter()]
		public SourceField SourceField { get; set; }

		[Parameter()]
		public Nullable<Int32> Width { get; set; }

	}

	[Cmdlet(VerbsCommon.Add, "CBreezeXmlPortFieldElement")]
	[OutputType(typeof(XmlPortFieldElement))]
	[Alias("FieldElement")]
	public class AddCBreezeXmlPortFieldElement : NewNamedItemCmdlet<XmlPortFieldElement, Guid, PSObject>
	{
		protected override XmlPortFieldElement CreateItem()
		{
			var xmlPortFieldElement = new XmlPortFieldElement(Name, GetIndentation(), ID);

			xmlPortFieldElement.Properties.AutoCalcField = AutoCalcField;
			xmlPortFieldElement.Properties.DataType = DataType;
			xmlPortFieldElement.Properties.FieldValidate = FieldValidate;
			xmlPortFieldElement.Properties.MaxOccurs = MaxOccurs;
			xmlPortFieldElement.Properties.MinOccurs = MinOccurs;
			xmlPortFieldElement.Properties.NamespacePrefix = NamespacePrefix;
			xmlPortFieldElement.Properties.SourceField = SourceField;
			xmlPortFieldElement.Properties.Unbound = Unbound;
			xmlPortFieldElement.Properties.Width = Width;

			return xmlPortFieldElement;
		}

		protected override void AddItemToInputObject(XmlPortFieldElement item, PSObject inputObject)
		{
			throw new NotImplementedException(); // FIXME
		}

		protected int? GetIndentation()
		{
			switch(ParameterSetName)
			{
				case ParameterSetNames.AddWithID:
				case ParameterSetNames.AddWithoutID:
					return null; // FIXME
					
				case ParameterSetNames.NewWithID:
				case ParameterSetNames.NewWithoutID:
					return (int?)GetVariableValue("Indentation", null);

				default: 
					return null;
			}
		}

		[Parameter()]
		public Nullable<Boolean> AutoCalcField { get; set; }

		[Parameter()]
		public Nullable<XmlPortNodeDataType> DataType { get; set; }

		[Parameter()]
		public Nullable<Boolean> FieldValidate { get; set; }

		[Parameter()]
		public Nullable<MaxOccurs> MaxOccurs { get; set; }

		[Parameter()]
		public Nullable<MinOccurs> MinOccurs { get; set; }

		[Parameter()]
		public String NamespacePrefix { get; set; }

		[Parameter()]
		public SourceField SourceField { get; set; }

		[Parameter()]
		public Nullable<Boolean> Unbound { get; set; }

		[Parameter()]
		public Nullable<Int32> Width { get; set; }

	}

	[Cmdlet(VerbsCommon.Add, "CBreezeXmlPortTableAttribute")]
	[OutputType(typeof(XmlPortTableAttribute))]
	[Alias("TableAttribute")]
	public class AddCBreezeXmlPortTableAttribute : NewNamedItemCmdlet<XmlPortTableAttribute, Guid, PSObject>
	{
		protected override XmlPortTableAttribute CreateItem()
		{
			var xmlPortTableAttribute = new XmlPortTableAttribute(Name, GetIndentation(), ID);

			xmlPortTableAttribute.Properties.AutoReplace = AutoReplace;
			xmlPortTableAttribute.Properties.AutoSave = AutoSave;
			xmlPortTableAttribute.Properties.AutoUpdate = AutoUpdate;
			xmlPortTableAttribute.Properties.CalcFields = CalcFields;
			xmlPortTableAttribute.Properties.LinkFields = LinkFields;
			xmlPortTableAttribute.Properties.LinkTable = LinkTable;
			xmlPortTableAttribute.Properties.LinkTableForceInsert = LinkTableForceInsert;
			xmlPortTableAttribute.Properties.Occurrence = Occurrence;
			xmlPortTableAttribute.Properties.ReqFilterFields = ReqFilterFields;
			xmlPortTableAttribute.Properties.ReqFilterHeadingML = ReqFilterHeadingML;
			xmlPortTableAttribute.Properties.SourceTable = SourceTable;
			xmlPortTableAttribute.Properties.SourceTableView = SourceTableView;
			xmlPortTableAttribute.Properties.Temporary = Temporary;
			xmlPortTableAttribute.Properties.VariableName = VariableName;
			xmlPortTableAttribute.Properties.Width = Width;

			return xmlPortTableAttribute;
		}

		protected override void AddItemToInputObject(XmlPortTableAttribute item, PSObject inputObject)
		{
			throw new NotImplementedException(); // FIXME
		}

		protected int? GetIndentation()
		{
			switch(ParameterSetName)
			{
				case ParameterSetNames.AddWithID:
				case ParameterSetNames.AddWithoutID:
					return null; // FIXME
					
				case ParameterSetNames.NewWithID:
				case ParameterSetNames.NewWithoutID:
					return (int?)GetVariableValue("Indentation", null);

				default: 
					return null;
			}
		}

		[Parameter()]
		public Nullable<Boolean> AutoReplace { get; set; }

		[Parameter()]
		public Nullable<Boolean> AutoSave { get; set; }

		[Parameter()]
		public Nullable<Boolean> AutoUpdate { get; set; }

		[Parameter()]
		public FieldList CalcFields { get; set; }

		[Parameter()]
		public LinkFields LinkFields { get; set; }

		[Parameter()]
		public String LinkTable { get; set; }

		[Parameter()]
		public Nullable<Boolean> LinkTableForceInsert { get; set; }

		[Parameter()]
		public Nullable<Occurrence> Occurrence { get; set; }

		[Parameter()]
		public FieldList ReqFilterFields { get; set; }

		[Parameter()]
		public MultiLanguageValue ReqFilterHeadingML { get; set; }

		[Parameter()]
		public Nullable<Int32> SourceTable { get; set; }

		[Parameter()]
		public TableView SourceTableView { get; set; }

		[Parameter()]
		public Nullable<Boolean> Temporary { get; set; }

		[Parameter()]
		public String VariableName { get; set; }

		[Parameter()]
		public Nullable<Int32> Width { get; set; }

	}

	[Cmdlet(VerbsCommon.Add, "CBreezeXmlPortTableElement")]
	[OutputType(typeof(XmlPortTableElement))]
	[Alias("TableElement")]
	public class AddCBreezeXmlPortTableElement : NewNamedItemCmdlet<XmlPortTableElement, Guid, PSObject>
	{
		protected override XmlPortTableElement CreateItem()
		{
			var xmlPortTableElement = new XmlPortTableElement(Name, GetIndentation(), ID);

			xmlPortTableElement.Properties.AutoReplace = AutoReplace;
			xmlPortTableElement.Properties.AutoSave = AutoSave;
			xmlPortTableElement.Properties.AutoUpdate = AutoUpdate;
			xmlPortTableElement.Properties.CalcFields = CalcFields;
			xmlPortTableElement.Properties.LinkFields = LinkFields;
			xmlPortTableElement.Properties.LinkTable = LinkTable;
			xmlPortTableElement.Properties.LinkTableForceInsert = LinkTableForceInsert;
			xmlPortTableElement.Properties.MaxOccurs = MaxOccurs;
			xmlPortTableElement.Properties.MinOccurs = MinOccurs;
			xmlPortTableElement.Properties.NamespacePrefix = NamespacePrefix;
			xmlPortTableElement.Properties.ReqFilterFields = ReqFilterFields;
			xmlPortTableElement.Properties.ReqFilterHeadingML = ReqFilterHeadingML;
			xmlPortTableElement.Properties.SourceTable = SourceTable;
			xmlPortTableElement.Properties.SourceTableView = SourceTableView;
			xmlPortTableElement.Properties.Temporary = Temporary;
			xmlPortTableElement.Properties.VariableName = VariableName;
			xmlPortTableElement.Properties.Width = Width;

			return xmlPortTableElement;
		}

		protected override void AddItemToInputObject(XmlPortTableElement item, PSObject inputObject)
		{
			throw new NotImplementedException(); // FIXME
		}

		protected int? GetIndentation()
		{
			switch(ParameterSetName)
			{
				case ParameterSetNames.AddWithID:
				case ParameterSetNames.AddWithoutID:
					return null; // FIXME
					
				case ParameterSetNames.NewWithID:
				case ParameterSetNames.NewWithoutID:
					return (int?)GetVariableValue("Indentation", null);

				default: 
					return null;
			}
		}

		[Parameter()]
		public Nullable<Boolean> AutoReplace { get; set; }

		[Parameter()]
		public Nullable<Boolean> AutoSave { get; set; }

		[Parameter()]
		public Nullable<Boolean> AutoUpdate { get; set; }

		[Parameter()]
		public FieldList CalcFields { get; set; }

		[Parameter()]
		public LinkFields LinkFields { get; set; }

		[Parameter()]
		public String LinkTable { get; set; }

		[Parameter()]
		public Nullable<Boolean> LinkTableForceInsert { get; set; }

		[Parameter()]
		public Nullable<MaxOccurs> MaxOccurs { get; set; }

		[Parameter()]
		public Nullable<MinOccurs> MinOccurs { get; set; }

		[Parameter()]
		public String NamespacePrefix { get; set; }

		[Parameter()]
		public FieldList ReqFilterFields { get; set; }

		[Parameter()]
		public MultiLanguageValue ReqFilterHeadingML { get; set; }

		[Parameter()]
		public Nullable<Int32> SourceTable { get; set; }

		[Parameter()]
		public TableView SourceTableView { get; set; }

		[Parameter()]
		public Nullable<Boolean> Temporary { get; set; }

		[Parameter()]
		public String VariableName { get; set; }

		[Parameter()]
		public Nullable<Int32> Width { get; set; }

	}

	[Cmdlet(VerbsCommon.Add, "CBreezeXmlPortTextAttribute")]
	[OutputType(typeof(XmlPortTextAttribute))]
	[Alias("TextAttribute")]
	public class AddCBreezeXmlPortTextAttribute : NewNamedItemCmdlet<XmlPortTextAttribute, Guid, PSObject>
	{
		protected override XmlPortTextAttribute CreateItem()
		{
			var xmlPortTextAttribute = new XmlPortTextAttribute(Name, GetIndentation(), ID);

			xmlPortTextAttribute.Properties.DataType = DataType;
			xmlPortTextAttribute.Properties.Occurrence = Occurrence;
			xmlPortTextAttribute.Properties.TextType = TextType;
			xmlPortTextAttribute.Properties.VariableName = VariableName;
			xmlPortTextAttribute.Properties.Width = Width;

			return xmlPortTextAttribute;
		}

		protected override void AddItemToInputObject(XmlPortTextAttribute item, PSObject inputObject)
		{
			throw new NotImplementedException(); // FIXME
		}

		protected int? GetIndentation()
		{
			switch(ParameterSetName)
			{
				case ParameterSetNames.AddWithID:
				case ParameterSetNames.AddWithoutID:
					return null; // FIXME
					
				case ParameterSetNames.NewWithID:
				case ParameterSetNames.NewWithoutID:
					return (int?)GetVariableValue("Indentation", null);

				default: 
					return null;
			}
		}

		[Parameter()]
		public Nullable<XmlPortNodeDataType> DataType { get; set; }

		[Parameter()]
		public Nullable<Occurrence> Occurrence { get; set; }

		[Parameter()]
		public Nullable<TextType> TextType { get; set; }

		[Parameter()]
		public String VariableName { get; set; }

		[Parameter()]
		public Nullable<Int32> Width { get; set; }

	}

	[Cmdlet(VerbsCommon.Add, "CBreezeXmlPortTextElement")]
	[OutputType(typeof(XmlPortTextElement))]
	[Alias("TextElement")]
	public class AddCBreezeXmlPortTextElement : NewNamedItemCmdlet<XmlPortTextElement, Guid, PSObject>
	{
		protected override XmlPortTextElement CreateItem()
		{
			var xmlPortTextElement = new XmlPortTextElement(Name, GetIndentation(), ID);

			xmlPortTextElement.Properties.DataType = DataType;
			xmlPortTextElement.Properties.MaxOccurs = MaxOccurs;
			xmlPortTextElement.Properties.MinOccurs = MinOccurs;
			xmlPortTextElement.Properties.NamespacePrefix = NamespacePrefix;
			xmlPortTextElement.Properties.TextType = TextType;
			xmlPortTextElement.Properties.Unbound = Unbound;
			xmlPortTextElement.Properties.VariableName = VariableName;
			xmlPortTextElement.Properties.Width = Width;

			return xmlPortTextElement;
		}

		protected override void AddItemToInputObject(XmlPortTextElement item, PSObject inputObject)
		{
			throw new NotImplementedException(); // FIXME
		}

		protected int? GetIndentation()
		{
			switch(ParameterSetName)
			{
				case ParameterSetNames.AddWithID:
				case ParameterSetNames.AddWithoutID:
					return null; // FIXME
					
				case ParameterSetNames.NewWithID:
				case ParameterSetNames.NewWithoutID:
					return (int?)GetVariableValue("Indentation", null);

				default: 
					return null;
			}
		}

		[Parameter()]
		public Nullable<XmlPortNodeDataType> DataType { get; set; }

		[Parameter()]
		public Nullable<MaxOccurs> MaxOccurs { get; set; }

		[Parameter()]
		public Nullable<MinOccurs> MinOccurs { get; set; }

		[Parameter()]
		public String NamespacePrefix { get; set; }

		[Parameter()]
		public Nullable<TextType> TextType { get; set; }

		[Parameter()]
		public Nullable<Boolean> Unbound { get; set; }

		[Parameter()]
		public String VariableName { get; set; }

		[Parameter()]
		public Nullable<Int32> Width { get; set; }

	}

}
