using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeXmlPortNode")]
    [OutputType(typeof(XmlPortNode))]
    public class AddCBreezeXmlPortNode : NewCBreezeXmlPortNode
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

        [Parameter()]
        public SwitchParameter PassThru
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var indentation = GetIndentationLevel();
            var node = CreateXmlPortNode(indentation);

            if (InputObject.BaseObject is XmlPort)
            {
                switch (Position.GetValueOrDefault(Core.Position.LastWithinContainer))
                {
                    case Core.Position.FirstWithinContainer:
                        (InputObject.BaseObject as XmlPort).Nodes.Insert(0, node);
                        break;

                    case Core.Position.LastWithinContainer:
                        (InputObject.BaseObject as XmlPort).Nodes.Add(node);
                        break;
                }
            }
            else if (InputObject.BaseObject is XmlPortNodes)
            {
                switch (Position.GetValueOrDefault(Core.Position.LastWithinContainer))
                {
                    case Core.Position.FirstWithinContainer:
                        (InputObject.BaseObject as XmlPortNodes).Insert(0, node);
                        break;

                    case Core.Position.LastWithinContainer:
                        (InputObject.BaseObject as XmlPortNodes).Add(node);
                        break;
                }
            }
            else if (InputObject.BaseObject is XmlPortNode)
            {
                (InputObject.BaseObject as XmlPortNode).AddChildNode(node, Position.GetValueOrDefault(Core.Position.LastWithinContainer));
            }
            else
            {
                throw new ArgumentOutOfRangeException("Don't know how to add an XmlPort node to this InputObject.");
            }

            if (PassThru)
                WriteObject(node);
        }

        protected override int? GetIndentationLevel()
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