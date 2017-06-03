using System;
using System.Linq;
using System.Management.Automation;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeXmlPortFieldAttribute")]
    [OutputType(typeof(XmlPortFieldAttribute))]
    [Alias("FieldAttribute")]
    public class NewCBreezeXmlPortFieldAttribute : NewNamedItemCmdlet<XmlPortFieldAttribute, Guid, PSObject>
    {
        protected override void AddItemToInputObject(XmlPortFieldAttribute item, PSObject inputObject)
        {
            throw new NotImplementedException(); // FIXME
        }

        protected override XmlPortFieldAttribute CreateItem()
        {
            var xmlPortFieldAttribute = new XmlPortFieldAttribute(Name, GetIndentation(), ID);

            xmlPortFieldAttribute.Properties.AutoCalcField = AutoCalcField;
            xmlPortFieldAttribute.Properties.DataType = DataType;
            xmlPortFieldAttribute.Properties.FieldValidate = FieldValidate;
            xmlPortFieldAttribute.Properties.Occurrence = Occurrence;
            xmlPortFieldAttribute.Properties.SourceField.FieldName = SourceFieldName;
            xmlPortFieldAttribute.Properties.SourceField.TableVariableName = SourceFieldTableVariableName;
            xmlPortFieldAttribute.Properties.Width = Width;

            return xmlPortFieldAttribute;
        }

        protected int? GetIndentation()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.AddWithID:
                case ParameterSetNames.AddWithoutID:
                    if (InputObject.BaseObject is XmlPort) { return null; }
                    if (InputObject.BaseObject is XmlPortNodes) { return null; }
                    if (InputObject.BaseObject is XmlPortNode) { return (InputObject.BaseObject as XmlPortNode).IndentationLevel.GetValueOrDefault(0) + 1; };
                    throw new ArgumentOutOfRangeException("Cannot determine indentation.");

                case ParameterSetNames.NewWithID:
                case ParameterSetNames.NewWithoutID:
                    return (int?)GetVariableValue("Indentation", null);

                default:
                    return null;
            }
        }

        [Parameter()]
        public Nullable<Boolean> AutoCalcField { get; set; }

        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.NewWithID)]
        public ScriptBlock ChildNodes { get; set; }

        [Parameter()]
        public Nullable<XmlPortNodeDataType> DataType { get; set; }

        [Parameter()]
        public Nullable<Boolean> FieldValidate { get; set; }

        [Parameter()]
        public Nullable<Occurrence> Occurrence { get; set; }

        [Parameter()]
        public String SourceFieldName { get; set; }

        [Parameter()]
        public String SourceFieldTableVariableName { get; set; }

        [Parameter()]
        public Nullable<Int32> Width { get; set; }
    }

    [Cmdlet(VerbsCommon.New, "CBreezeXmlPortFieldElement")]
    [OutputType(typeof(XmlPortFieldElement))]
    [Alias("FieldElement")]
    public class NewCBreezeXmlPortFieldElement : NewNamedItemCmdlet<XmlPortFieldElement, Guid, PSObject>
    {
        protected override void AddItemToInputObject(XmlPortFieldElement item, PSObject inputObject)
        {
            throw new NotImplementedException(); // FIXME
        }

        protected override XmlPortFieldElement CreateItem()
        {
            var xmlPortFieldElement = new XmlPortFieldElement(Name, GetIndentation(), ID);

            xmlPortFieldElement.Properties.AutoCalcField = AutoCalcField;
            xmlPortFieldElement.Properties.DataType = DataType;
            xmlPortFieldElement.Properties.FieldValidate = FieldValidate;
            xmlPortFieldElement.Properties.MaxOccurs = MaxOccurs;
            xmlPortFieldElement.Properties.MinOccurs = MinOccurs;
            xmlPortFieldElement.Properties.NamespacePrefix = NamespacePrefix;
            xmlPortFieldElement.Properties.SourceField.FieldName = SourceFieldName;
            xmlPortFieldElement.Properties.SourceField.TableVariableName = SourceFieldTableVariableName;
            xmlPortFieldElement.Properties.Unbound = Unbound;
            xmlPortFieldElement.Properties.Width = Width;

            return xmlPortFieldElement;
        }

        protected int? GetIndentation()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.AddWithID:
                case ParameterSetNames.AddWithoutID:
                    if (InputObject.BaseObject is XmlPort) { return null; }
                    if (InputObject.BaseObject is XmlPortNodes) { return null; }
                    if (InputObject.BaseObject is XmlPortNode) { return (InputObject.BaseObject as XmlPortNode).IndentationLevel.GetValueOrDefault(0) + 1; };
                    throw new ArgumentOutOfRangeException("Cannot determine indentation.");

                case ParameterSetNames.NewWithID:
                case ParameterSetNames.NewWithoutID:
                    return (int?)GetVariableValue("Indentation", null);

                default:
                    return null;
            }
        }

        [Parameter()]
        public Nullable<Boolean> AutoCalcField { get; set; }

        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.NewWithID)]
        public ScriptBlock ChildNodes { get; set; }

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
        public String SourceFieldName { get; set; }

        [Parameter()]
        public String SourceFieldTableVariableName { get; set; }

        [Parameter()]
        public Nullable<Boolean> Unbound { get; set; }

        [Parameter()]
        public Nullable<Int32> Width { get; set; }
    }

    [Cmdlet(VerbsCommon.New, "CBreezeXmlPortTableAttribute")]
    [OutputType(typeof(XmlPortTableAttribute))]
    [Alias("TableAttribute")]
    public class NewCBreezeXmlPortTableAttribute : NewNamedItemCmdlet<XmlPortTableAttribute, Guid, PSObject>
    {
        protected override void AddItemToInputObject(XmlPortTableAttribute item, PSObject inputObject)
        {
            throw new NotImplementedException(); // FIXME
        }

        protected override XmlPortTableAttribute CreateItem()
        {
            var xmlPortTableAttribute = new XmlPortTableAttribute(Name, GetIndentation(), ID);

            xmlPortTableAttribute.Properties.AutoReplace = AutoReplace;
            xmlPortTableAttribute.Properties.AutoSave = AutoSave;
            xmlPortTableAttribute.Properties.AutoUpdate = AutoUpdate;
            xmlPortTableAttribute.Properties.CalcFields.AddRange(CalcFields);
            xmlPortTableAttribute.Properties.LinkTable = LinkTable;
            xmlPortTableAttribute.Properties.LinkTableForceInsert = LinkTableForceInsert;
            xmlPortTableAttribute.Properties.Occurrence = Occurrence;
            xmlPortTableAttribute.Properties.ReqFilterFields.AddRange(ReqFilterFields);
            xmlPortTableAttribute.Properties.SourceTable = SourceTable;
            xmlPortTableAttribute.Properties.SourceTableView.Key = SourceTableViewKey;
            xmlPortTableAttribute.Properties.SourceTableView.Order = SourceTableViewOrder;
            xmlPortTableAttribute.Properties.Temporary = Temporary;
            xmlPortTableAttribute.Properties.VariableName = VariableName;
            xmlPortTableAttribute.Properties.Width = Width;

            return xmlPortTableAttribute;
        }

        protected int? GetIndentation()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.AddWithID:
                case ParameterSetNames.AddWithoutID:
                    if (InputObject.BaseObject is XmlPort) { return null; }
                    if (InputObject.BaseObject is XmlPortNodes) { return null; }
                    if (InputObject.BaseObject is XmlPortNode) { return (InputObject.BaseObject as XmlPortNode).IndentationLevel.GetValueOrDefault(0) + 1; };
                    throw new ArgumentOutOfRangeException("Cannot determine indentation.");

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

        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.NewWithID)]
        public ScriptBlock ChildNodes { get; set; }

        [Parameter()]
        public String LinkTable { get; set; }

        [Parameter()]
        public Nullable<Boolean> LinkTableForceInsert { get; set; }

        [Parameter()]
        public Nullable<Occurrence> Occurrence { get; set; }

        [Parameter()]
        public FieldList ReqFilterFields { get; set; }

        [Parameter()]
        public Nullable<Int32> SourceTable { get; set; }

        [Parameter()]
        public String SourceTableViewKey { get; set; }

        [Parameter()]
        public Nullable<Order> SourceTableViewOrder { get; set; }

        [Parameter()]
        public Nullable<Boolean> Temporary { get; set; }

        [Parameter()]
        public String VariableName { get; set; }

        [Parameter()]
        public Nullable<Int32> Width { get; set; }
    }

    [Cmdlet(VerbsCommon.New, "CBreezeXmlPortTableElement")]
    [OutputType(typeof(XmlPortTableElement))]
    [Alias("TableElement")]
    public class NewCBreezeXmlPortTableElement : NewNamedItemCmdlet<XmlPortTableElement, Guid, PSObject>
    {
        protected override void AddItemToInputObject(XmlPortTableElement item, PSObject inputObject)
        {
            throw new NotImplementedException(); // FIXME
        }

        protected override XmlPortTableElement CreateItem()
        {
            var xmlPortTableElement = new XmlPortTableElement(Name, GetIndentation(), ID);

            xmlPortTableElement.Properties.AutoReplace = AutoReplace;
            xmlPortTableElement.Properties.AutoSave = AutoSave;
            xmlPortTableElement.Properties.AutoUpdate = AutoUpdate;
            xmlPortTableElement.Properties.CalcFields.AddRange(CalcFields);
            xmlPortTableElement.Properties.LinkTable = LinkTable;
            xmlPortTableElement.Properties.LinkTableForceInsert = LinkTableForceInsert;
            xmlPortTableElement.Properties.MaxOccurs = MaxOccurs;
            xmlPortTableElement.Properties.MinOccurs = MinOccurs;
            xmlPortTableElement.Properties.NamespacePrefix = NamespacePrefix;
            xmlPortTableElement.Properties.ReqFilterFields.AddRange(ReqFilterFields);
            xmlPortTableElement.Properties.SourceTable = SourceTable;
            xmlPortTableElement.Properties.SourceTableView.Key = SourceTableViewKey;
            xmlPortTableElement.Properties.SourceTableView.Order = SourceTableViewOrder;
            xmlPortTableElement.Properties.Temporary = Temporary;
            xmlPortTableElement.Properties.VariableName = VariableName;
            xmlPortTableElement.Properties.Width = Width;

            return xmlPortTableElement;
        }

        protected int? GetIndentation()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.AddWithID:
                case ParameterSetNames.AddWithoutID:
                    if (InputObject.BaseObject is XmlPort) { return null; }
                    if (InputObject.BaseObject is XmlPortNodes) { return null; }
                    if (InputObject.BaseObject is XmlPortNode) { return (InputObject.BaseObject as XmlPortNode).IndentationLevel.GetValueOrDefault(0) + 1; };
                    throw new ArgumentOutOfRangeException("Cannot determine indentation.");

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

        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.NewWithID)]
        public ScriptBlock ChildNodes { get; set; }

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
        public Nullable<Int32> SourceTable { get; set; }

        [Parameter()]
        public String SourceTableViewKey { get; set; }

        [Parameter()]
        public Nullable<Order> SourceTableViewOrder { get; set; }

        [Parameter()]
        public Nullable<Boolean> Temporary { get; set; }

        [Parameter()]
        public String VariableName { get; set; }

        [Parameter()]
        public Nullable<Int32> Width { get; set; }
    }

    [Cmdlet(VerbsCommon.New, "CBreezeXmlPortTextAttribute")]
    [OutputType(typeof(XmlPortTextAttribute))]
    [Alias("TextAttribute")]
    public class NewCBreezeXmlPortTextAttribute : NewNamedItemCmdlet<XmlPortTextAttribute, Guid, PSObject>
    {
        protected override void AddItemToInputObject(XmlPortTextAttribute item, PSObject inputObject)
        {
            throw new NotImplementedException(); // FIXME
        }

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

        protected int? GetIndentation()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.AddWithID:
                case ParameterSetNames.AddWithoutID:
                    if (InputObject.BaseObject is XmlPort) { return null; }
                    if (InputObject.BaseObject is XmlPortNodes) { return null; }
                    if (InputObject.BaseObject is XmlPortNode) { return (InputObject.BaseObject as XmlPortNode).IndentationLevel.GetValueOrDefault(0) + 1; };
                    throw new ArgumentOutOfRangeException("Cannot determine indentation.");

                case ParameterSetNames.NewWithID:
                case ParameterSetNames.NewWithoutID:
                    return (int?)GetVariableValue("Indentation", null);

                default:
                    return null;
            }
        }

        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.NewWithID)]
        public ScriptBlock ChildNodes { get; set; }

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

    [Cmdlet(VerbsCommon.New, "CBreezeXmlPortTextElement")]
    [OutputType(typeof(XmlPortTextElement))]
    [Alias("TextElement")]
    public class NewCBreezeXmlPortTextElement : NewNamedItemCmdlet<XmlPortTextElement, Guid, PSObject>
    {
        protected override void AddItemToInputObject(XmlPortTextElement item, PSObject inputObject)
        {
            throw new NotImplementedException(); // FIXME
        }

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

        protected int? GetIndentation()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.AddWithID:
                case ParameterSetNames.AddWithoutID:
                    if (InputObject.BaseObject is XmlPort) { return null; }
                    if (InputObject.BaseObject is XmlPortNodes) { return null; }
                    if (InputObject.BaseObject is XmlPortNode) { return (InputObject.BaseObject as XmlPortNode).IndentationLevel.GetValueOrDefault(0) + 1; };
                    throw new ArgumentOutOfRangeException("Cannot determine indentation.");

                case ParameterSetNames.NewWithID:
                case ParameterSetNames.NewWithoutID:
                    return (int?)GetVariableValue("Indentation", null);

                default:
                    return null;
            }
        }

        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.NewWithID)]
        public ScriptBlock ChildNodes { get; set; }

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