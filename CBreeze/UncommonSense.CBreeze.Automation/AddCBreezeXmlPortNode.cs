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
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory=true)]
        [ValidateSet("Element", "Attribute")]
        public string NodeType
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        [ValidateSet("Table", "Field", "Text")]
        public string SourceType
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

        protected override void ProcessRecord()
        {
            var xmlPortNode = CreateXmlPortNode();



            if (PassThru)
                WriteObject(xmlPortNode);
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
            switch (NodeType)
            {
                case "Element":
                    return GetElementNodeType();
                case "Attribute":
                    return GetAttributeNodeType();
                default:
                    throw new ArgumentOutOfRangeException("Unknown node type.");
            }
        }

        protected XmlPortNodeType GetElementNodeType()
        {
            switch (SourceType)
            {
                case "Table":
                    return XmlPortNodeType.XmlPortTableElement;
                case "Field":
                    return XmlPortNodeType.XmlPortFieldElement;
                case "Text":
                    return XmlPortNodeType.XmlPortTextElement;
                default:
                    throw new ArgumentOutOfRangeException("Unknown source type.");
            }
        }

        protected XmlPortNodeType GetAttributeNodeType()
        {
            switch (SourceType)
            {
                case "Table":
                    return XmlPortNodeType.XmlPortTableAttribute;
                case "Field":
                    return XmlPortNodeType.XmlPortFieldAttribute;
                case "Text":
                    return XmlPortNodeType.XmlPortTextAttribute;
                default:
                    throw new ArgumentOutOfRangeException("Unknown source type.");
            }
        }

        protected XmlPortTableElement CreateTableElementNode()
        {
            var node = new XmlPortTableElement(ID ?? Guid.NewGuid(), Name, GetIndentationLevel());

            return node;
        }

        protected XmlPortFieldElement CreateFieldElementNode()
        {
            var node = new XmlPortFieldElement(ID ?? Guid.NewGuid(), Name, GetIndentationLevel());

            return node;
        }

        protected XmlPortTextElement CreateTextElementNode()
        {
            var node = new XmlPortTextElement(ID ?? Guid.NewGuid(), Name, GetIndentationLevel());

            return node;
        }

        protected XmlPortTableAttribute CreateTableAttributeNode()
        {
            var node = new XmlPortTableAttribute(ID ?? Guid.NewGuid(), Name, GetIndentationLevel());

            return node;
        }

        protected XmlPortFieldAttribute CreateFieldAttributeNode()
        {
            var node = new XmlPortFieldAttribute(ID ?? Guid.NewGuid(), Name, GetIndentationLevel());

            return node;
        }

        protected XmlPortTextAttribute CreateTextAttributeNode()
        {
            var node = new XmlPortTextAttribute(ID ?? Guid.NewGuid(), Name, GetIndentationLevel());

            return node;
        }

        protected int GetIndentationLevel()
        {
            if (InputObject.BaseObject is XmlPort)
                return 0;
            else if (InputObject.BaseObject is XmlPortNodes)
                return 0;
            else if (InputObject.BaseObject is XmlPortNode)
                return (InputObject.BaseObject as XmlPortNode).IndentationLevel.GetValueOrDefault(0) + 1;
            else
                throw new ArgumentOutOfRangeException("Cannot determine indentation.");
        }
    }
}
