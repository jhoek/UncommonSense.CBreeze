using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeXmlPortNode")]
    [OutputType(typeof(XmlPortNode))]
    public class NewCBreezeXmlPortNode : PSCmdlet
    {
        private const string TableElement = "TableElement";
        private const string FieldElement = "FieldElement";
        private const string TextElement = "TextElement";
        private const string TableAttribute = "TableAttribute";
        private const string FieldAttribute = "FieldAttribute";
        private const string TextAttribute = "TextAttribute";

        [Parameter(Mandatory = true, ParameterSetName = TableElement)]
        [Parameter(Mandatory = true, ParameterSetName = FieldElement)]
        [Parameter(Mandatory = true, ParameterSetName = TextElement)]
        public SwitchParameter Element
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = TableAttribute)]
        [Parameter(Mandatory = true, ParameterSetName = FieldAttribute)]
        [Parameter(Mandatory = true, ParameterSetName = TextAttribute)]
        public SwitchParameter Attribute
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = TableElement)]
        [Parameter(Mandatory = true, ParameterSetName = TableAttribute)]
        public SwitchParameter Table
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = FieldElement)]
        [Parameter(Mandatory = true, ParameterSetName = FieldAttribute)]
        public SwitchParameter Field
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = TextElement)]
        [Parameter(Mandatory = true, ParameterSetName = TextAttribute)]
        public SwitchParameter Text
        {
            get;
            set;
        }

        [Parameter()]
        public Guid? ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Position = 2)]
        public ScriptBlock ChildNodes
        {
            get; set;
        }

        [Parameter()]
        public Position? Position
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = FieldElement)]
        [Parameter(ParameterSetName = FieldAttribute)]
        public bool? AutoCalcField
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = TableElement)]
        [Parameter(ParameterSetName = TableAttribute)]
        public bool? AutoReplace
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = TableElement)]
        [Parameter(ParameterSetName = TableAttribute)]
        public bool? AutoSave
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = TableElement)]
        [Parameter(ParameterSetName = TableAttribute)]
        public bool? AutoUpdate
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = TableElement)]
        [Parameter(ParameterSetName = TableAttribute)]
        public string[] CalcFields
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = FieldElement)]
        [Parameter(ParameterSetName = FieldAttribute)]
        [Parameter(ParameterSetName = TextElement)]
#if NAV2016
        [Parameter(ParameterSetName = TextAttribute)]
#endif
        public XmlPortNodeDataType? DataType
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = FieldElement)]
        [Parameter(ParameterSetName = FieldAttribute)]
        public bool? FieldValidate
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = TableElement)]
        [Parameter(ParameterSetName = TableAttribute)]
        public string LinkTable
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = TableElement)]
        [Parameter(ParameterSetName = TableAttribute)]
        public bool? LinkTableForceInsert
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = TableElement)]
        [Parameter(ParameterSetName = FieldElement)]
        [Parameter(ParameterSetName = TextElement)]
        public MaxOccurs? MaxOccurs
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = TableElement)]
        [Parameter(ParameterSetName = FieldElement)]
        [Parameter(ParameterSetName = TextElement)]
        public MinOccurs? MinOccurs
        {
            get;
            set;
        }

#if NAV2016

        [Parameter(ParameterSetName = TableElement)]
        [Parameter(ParameterSetName = FieldElement)]
        [Parameter(ParameterSetName = TextElement)]
        public string NamespacePrefix
        {
            get;
            set;
        }

#endif

        [Parameter(ParameterSetName = TableAttribute)]
        [Parameter(ParameterSetName = FieldAttribute)]
        [Parameter(ParameterSetName = TextAttribute)]
        public Occurrence? Occurrence
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = TableElement)]
        [Parameter(ParameterSetName = TableAttribute)]
        public string[] ReqFilterFields
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = FieldElement)]
        [Parameter(ParameterSetName = FieldAttribute)]
        public string SourceFieldName
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = FieldElement)]
        [Parameter(ParameterSetName = FieldAttribute)]
        public string SourceFieldTableVariableName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = TableElement)]
        [Parameter(Mandatory = true, ParameterSetName = TableAttribute)]
        [ValidateRange(1, int.MaxValue)]
        public int? SourceTable
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = TableElement)]
        [Parameter(ParameterSetName = TableAttribute)]
        public string SourceTableViewKey
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = TableElement)]
        [Parameter(ParameterSetName = TableAttribute)]
        public Order? SourceTableViewOrder
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = TableElement)]
        [Parameter(ParameterSetName = TableAttribute)]
        public bool? Temporary
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = TextElement)]
        [Parameter(ParameterSetName = TextAttribute)]
        public TextType? TextType
        {
            get;
            set;
        }

#if NAV2013R2

        [Parameter(ParameterSetName = FieldElement)]
        [Parameter(ParameterSetName = TextElement)]
        public bool? Unbound
        {
            get;
            set;
        }

#endif

        [Parameter(ParameterSetName = TableElement)]
        [Parameter(ParameterSetName = TableAttribute)]
        [Parameter(ParameterSetName = TextElement)]
        [Parameter(ParameterSetName = TextAttribute)]
        public string VariableName
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = TableElement)]
        [Parameter(ParameterSetName = TableAttribute)]
        [Parameter(ParameterSetName = FieldElement)]
        [Parameter(ParameterSetName = FieldAttribute)]
        [Parameter(ParameterSetName = TextElement)]
        [Parameter(ParameterSetName = TextAttribute)]
        public int? Width
        {
            get;
            set;
        }

        protected virtual int? GetIndentationLevel() => (int)GetVariableValue("Indentation", 0);

        protected override void ProcessRecord()
        {
            var indentation = GetIndentationLevel();
            WriteObject(CreateXmlPortNode(indentation));

            if (ChildNodes != null)
            {
                var variables = new List<PSVariable>() { new PSVariable("Indentation", indentation + 1) };
                WriteObject(ChildNodes.InvokeWithContext(null, variables), true);
            }
        }

        protected XmlPortNode CreateXmlPortNode(int? indentation)
        {
            switch (GetNodeType())
            {
                case XmlPortNodeAndSourceType.XmlPortTableElement:
                    return CreateTableElementNode(indentation);

                case XmlPortNodeAndSourceType.XmlPortFieldElement:
                    return CreateFieldElementNode(indentation);

                case XmlPortNodeAndSourceType.XmlPortTextElement:
                    return CreateTextElementNode(indentation);

                case XmlPortNodeAndSourceType.XmlPortTableAttribute:
                    return CreateTableAttributeNode(indentation);

                case XmlPortNodeAndSourceType.XmlPortFieldAttribute:
                    return CreateFieldAttributeNode(indentation);

                case XmlPortNodeAndSourceType.XmlPortTextAttribute:
                    return CreateTextAttributeNode(indentation);

                default:
                    throw new ArgumentOutOfRangeException("Don't know how to create this node.");
            }
        }

        protected XmlPortNodeAndSourceType GetNodeType()
        {
            if (Element.IsPresent)
            {
                if (Table.IsPresent)
                    return XmlPortNodeAndSourceType.XmlPortTableElement;
                if (Field.IsPresent)
                    return XmlPortNodeAndSourceType.XmlPortFieldElement;
                if (Text.IsPresent)
                    return XmlPortNodeAndSourceType.XmlPortTextElement;

                throw new ArgumentOutOfRangeException("Unknown source type.");
            }

            if (Attribute.IsPresent)
            {
                if (Table.IsPresent)
                    return XmlPortNodeAndSourceType.XmlPortTableAttribute;
                if (Field.IsPresent)
                    return XmlPortNodeAndSourceType.XmlPortFieldAttribute;
                if (Text.IsPresent)
                    return XmlPortNodeAndSourceType.XmlPortTextAttribute;

                throw new ArgumentOutOfRangeException("Unknown source type.");
            }

            throw new ArgumentOutOfRangeException("Unknown node type.");
        }

        protected XmlPortTableElement CreateTableElementNode(int? indentation)
        {
            var node = new XmlPortTableElement(Name, indentation, ID ?? Guid.NewGuid());

            node.Properties.AutoReplace = AutoReplace;
            node.Properties.AutoSave = AutoSave;
            node.Properties.AutoUpdate = AutoUpdate;
            node.Properties.CalcFields.AddRange(CalcFields ?? new string[] { });
            node.Properties.LinkTable = LinkTable;
            node.Properties.LinkTableForceInsert = LinkTableForceInsert;
            node.Properties.MaxOccurs = MaxOccurs;
            node.Properties.MinOccurs = MinOccurs;
#if NAV2016
            node.Properties.NamespacePrefix = NamespacePrefix;
#endif
            node.Properties.ReqFilterFields.AddRange(ReqFilterFields ?? new string[] { });
            node.Properties.SourceTable = SourceTable;
            node.Properties.SourceTableView.Key = SourceTableViewKey;
            node.Properties.SourceTableView.Order = SourceTableViewOrder;
            node.Properties.Temporary = Temporary;
            node.Properties.VariableName = VariableName;
            node.Properties.Width = Width;

            return node;
        }

        protected XmlPortFieldElement CreateFieldElementNode(int? indentation)
        {
            var node = new XmlPortFieldElement(Name, indentation, ID ?? Guid.NewGuid());

            node.Properties.AutoCalcField = AutoCalcField;
            node.Properties.DataType = DataType;
            node.Properties.FieldValidate = FieldValidate;
            node.Properties.MaxOccurs = MaxOccurs;
            node.Properties.MinOccurs = MinOccurs;
#if NAV2016
            node.Properties.NamespacePrefix = NamespacePrefix;
#endif
            node.Properties.SourceField.TableVariableName = SourceFieldTableVariableName;
            node.Properties.SourceField.FieldName = SourceFieldName;
#if NAV2013R2
            node.Properties.Unbound = Unbound;
#endif
            node.Properties.Width = Width;

            return node;
        }

        protected XmlPortTextElement CreateTextElementNode(int? indentation)
        {
            var node = new XmlPortTextElement(Name, indentation, ID ?? Guid.NewGuid());

            node.Properties.DataType = DataType;
            node.Properties.MaxOccurs = MaxOccurs;
            node.Properties.MinOccurs = MinOccurs;
#if NAV2016
            node.Properties.NamespacePrefix = NamespacePrefix;
#endif
            node.Properties.TextType = TextType;
#if NAV2013R2
            node.Properties.Unbound = Unbound;
#endif
            node.Properties.VariableName = VariableName;
            node.Properties.Width = Width;

            return node;
        }

        protected XmlPortTableAttribute CreateTableAttributeNode(int? indentation)
        {
            var node = new XmlPortTableAttribute(Name, indentation, ID ?? Guid.NewGuid());

            node.Properties.AutoReplace = AutoReplace;
            node.Properties.AutoSave = AutoSave;
            node.Properties.AutoUpdate = AutoUpdate;
            node.Properties.CalcFields.AddRange(CalcFields ?? new string[] { });
            node.Properties.LinkTable = LinkTable;
            node.Properties.LinkTableForceInsert = LinkTableForceInsert;
            node.Properties.Occurrence = Occurrence;
            node.Properties.ReqFilterFields.AddRange(ReqFilterFields ?? new string[] { });
            node.Properties.SourceTable = SourceTable;
            node.Properties.SourceTableView.Key = SourceTableViewKey;
            node.Properties.SourceTableView.Order = SourceTableViewOrder;
            node.Properties.Temporary = Temporary;
            node.Properties.VariableName = VariableName;
            node.Properties.Width = Width;

            return node;
        }

        protected XmlPortFieldAttribute CreateFieldAttributeNode(int? indentation)
        {
            var node = new XmlPortFieldAttribute(Name, indentation, ID ?? Guid.NewGuid());

            node.Properties.AutoCalcField = AutoCalcField;
            node.Properties.DataType = DataType;
            node.Properties.FieldValidate = FieldValidate;
            node.Properties.Occurrence = Occurrence;
            node.Properties.SourceField.TableVariableName = SourceFieldTableVariableName;
            node.Properties.SourceField.FieldName = SourceFieldName;
            node.Properties.Width = Width;

            return node;
        }

        protected XmlPortTextAttribute CreateTextAttributeNode(int? indentation)
        {
            var node = new XmlPortTextAttribute(Name, indentation, ID ?? Guid.NewGuid());

#if NAV2016
            node.Properties.DataType = DataType;
#endif

            node.Properties.Occurrence = Occurrence;
            node.Properties.TextType = TextType;
            node.Properties.VariableName = VariableName;
            node.Properties.Width = Width;

            return node;
        }
    }
}