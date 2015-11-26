using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeXmlPortNode")]
    public class AddCBreezeXmlPortNode : Cmdlet
    {
        private const string TableElement = "TableElement";
        private const string FieldElement = "FieldElement";
        private const string TextElement = "TextElement";
        private const string TableAttribute = "TableAttribute";
        private const string FieldAttribute = "FieldAttribute";
        private const string TextAttribute = "TextAttribute";

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }

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

        [Parameter(Mandatory = true)]
        public string Name
        {
            get;
            set;
        }

        [Parameter()]
        public Position? Position
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter PassThru
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
        [Parameter(ParameterSetName=TextElement)]
        public TableFieldType? DataType
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

        [Parameter(ParameterSetName = TableAttribute)]
        [Parameter(ParameterSetName = FieldAttribute)]
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
        public int? Width
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var node = CreateXmlPortNode();

            if (InputObject.BaseObject is XmlPort)
            {
                switch (Position.GetValueOrDefault(Utils.Position.LastWithinContainer))
                {
                    case Utils.Position.FirstWithinContainer:
                        (InputObject.BaseObject as XmlPort).Nodes.Insert(0, node);
                        break;
                    case Utils.Position.LastWithinContainer:
                        (InputObject.BaseObject as XmlPort).Nodes.Add(node);
                        break;
                }
            }
            else if (InputObject.BaseObject is XmlPortNodes)
            {
                switch (Position.GetValueOrDefault(Utils.Position.LastWithinContainer))
                {
                    case Utils.Position.FirstWithinContainer:
                        (InputObject.BaseObject as XmlPortNodes).Insert(0, node);
                        break;
                    case Utils.Position.LastWithinContainer:
                        (InputObject.BaseObject as XmlPortNodes).Add(node);
                        break;
                }
            }
            else if (InputObject.BaseObject is XmlPortNode)
            {
                (InputObject.BaseObject as XmlPortNode).AddChildNode(node, Position.GetValueOrDefault(Utils.Position.LastWithinContainer));
            }
            else
            {
                throw new ArgumentOutOfRangeException("Don't know how to add an XmlPort node to this InputObject.");
            }

            if (PassThru)
                WriteObject(node);
        }

        protected XmlPortNode CreateXmlPortNode()
        {
            switch (GetNodeType())
            {
                case XmlPortNodeType.XmlPortTableElement:
                    return CreateTableElementNode();
                case XmlPortNodeType.XmlPortFieldElement:
                    return CreateFieldElementNode();
                case XmlPortNodeType.XmlPortTextElement:
                    return CreateTextElementNode();
                case XmlPortNodeType.XmlPortTableAttribute:
                    return CreateTableAttributeNode();
                case XmlPortNodeType.XmlPortFieldAttribute:
                    return CreateFieldAttributeNode();
                case XmlPortNodeType.XmlPortTextAttribute:
                    return CreateTextAttributeNode();
                default:
                    throw new ArgumentOutOfRangeException("Don't know how to create this node.");
            }
        }

        protected XmlPortNodeType GetNodeType()
        {
            if (Element.IsPresent)
            {
                if (Table.IsPresent)
                    return XmlPortNodeType.XmlPortTableElement;
                if (Field.IsPresent)
                    return XmlPortNodeType.XmlPortFieldElement;
                if (Text.IsPresent)
                    return XmlPortNodeType.XmlPortTextElement;

                throw new ArgumentOutOfRangeException("Unknown source type.");
            }

            if (Attribute.IsPresent)
            {
                if (Table.IsPresent)
                    return XmlPortNodeType.XmlPortTableAttribute;
                if (Field.IsPresent)
                    return XmlPortNodeType.XmlPortFieldAttribute;
                if (Text.IsPresent)
                    return XmlPortNodeType.XmlPortTextAttribute;

                throw new ArgumentOutOfRangeException("Unknown source type.");
            }

            throw new ArgumentOutOfRangeException("Unknown node type.");
        }

        protected XmlPortTableElement CreateTableElementNode()
        {
            var node = new XmlPortTableElement(ID ?? Guid.NewGuid(), Name, GetIndentationLevel());

            node.Properties.AutoReplace = AutoReplace;
            node.Properties.AutoSave = AutoSave;
            node.Properties.AutoUpdate = AutoUpdate;
            node.Properties.CalcFields.AddRange(CalcFields ?? new string[] { });
            // FIXME: node.Properties.LinkFields
            node.Properties.LinkTable = LinkTable;
            node.Properties.LinkTableForceInsert = LinkTableForceInsert;
            node.Properties.MaxOccurs = MaxOccurs;
            node.Properties.MinOccurs = MinOccurs;
            node.Properties.ReqFilterFields.AddRange(ReqFilterFields ?? new string[] { });
            node.Properties.SourceTable = SourceTable;
            node.Properties.SourceTableView.Key = SourceTableViewKey;
            node.Properties.SourceTableView.Order = SourceTableViewOrder;
            node.Properties.Temporary = Temporary;
            node.Properties.VariableName = VariableName;
            node.Properties.Width = Width;

            return node;
        }

        protected XmlPortFieldElement CreateFieldElementNode()
        {
            var node = new XmlPortFieldElement(ID ?? Guid.NewGuid(), Name, GetIndentationLevel());

            node.Properties.AutoCalcField = AutoCalcField;
            node.Properties.DataType = DataType;
            node.Properties.FieldValidate = FieldValidate;
            node.Properties.MaxOccurs = MaxOccurs;
            node.Properties.MinOccurs = MinOccurs;
            node.Properties.SourceField.TableVariableName = SourceFieldTableVariableName;
            node.Properties.SourceField.FieldName = SourceFieldName;
#if NAV2013R2
            node.Properties.Unbound = Unbound;
            node.Properties.Width = Width;
#endif

            return node;
        }

        protected XmlPortTextElement CreateTextElementNode()
        {
            var node = new XmlPortTextElement(ID ?? Guid.NewGuid(), Name, GetIndentationLevel());

            node.Properties.DataType = DataType;
            node.Properties.MaxOccurs = MaxOccurs;
            node.Properties.MinOccurs = MinOccurs;
            node.Properties.TextType = TextType;
#if NAV2013R2
            node.Properties.Unbound = Unbound;
#endif
            node.Properties.VariableName = VariableName;
            node.Properties.Width = Width;

            return node;
        }

        protected XmlPortTableAttribute CreateTableAttributeNode()
        {
            var node = new XmlPortTableAttribute(ID ?? Guid.NewGuid(), Name, GetIndentationLevel());

            node.Properties.AutoReplace = AutoReplace;
            node.Properties.AutoSave = AutoSave;
            node.Properties.AutoUpdate = AutoUpdate;
            node.Properties.CalcFields.AddRange(CalcFields ?? new string[] { });
            // FIXME: node.Properties.LinkFields
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

        protected XmlPortFieldAttribute CreateFieldAttributeNode()
        {
            var node = new XmlPortFieldAttribute(ID ?? Guid.NewGuid(), Name, GetIndentationLevel());

            node.Properties.AutoCalcField = AutoCalcField;
            node.Properties.DataType = DataType;
            node.Properties.FieldValidate = FieldValidate;
            node.Properties.Occurrence = Occurrence;
            node.Properties.SourceField.TableVariableName = SourceFieldTableVariableName;
            node.Properties.SourceField.FieldName = SourceFieldName;
            node.Properties.Width = Width;

            return node;
        }

        protected XmlPortTextAttribute CreateTextAttributeNode()
        {
            var node = new XmlPortTextAttribute(ID ?? Guid.NewGuid(), Name, GetIndentationLevel());

            return node;
        }

        protected int? GetIndentationLevel()
        {
            if (InputObject.BaseObject is XmlPort)
                return null;
            else if (InputObject.BaseObject is XmlPortNodes)
                return null;
            else if (InputObject.BaseObject is XmlPortNode)
                return (InputObject.BaseObject as XmlPortNode).IndentationLevel.GetValueOrDefault(0) + 1;
            else
                throw new ArgumentOutOfRangeException("Cannot determine indentation.");
        }
    }
}
