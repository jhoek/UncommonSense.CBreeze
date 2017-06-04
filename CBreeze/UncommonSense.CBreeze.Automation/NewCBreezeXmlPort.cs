using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeXmlPort", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(XmlPort))]
    [Alias("XmlPort")]
    public class NewCBreezeXmlPort : NewCBreezeObject<XmlPort>
    {
        protected override void AddItemToInputObject(XmlPort item, Application inputObject)
        {
            inputObject.XmlPorts.Add(item);
        }

        protected override IEnumerable<XmlPort> CreateItems()
        {
            var xmlPort = new XmlPort(ID, Name);
            SetObjectProperties(xmlPort);

            xmlPort.Properties.DefaultFieldsValidation = DefaultFieldsValidation;
            xmlPort.Properties.DefaultNamespace = DefaultNamespace;
            xmlPort.Properties.Direction = Direction;
            xmlPort.Properties.Encoding = Encoding;
            xmlPort.Properties.FieldDelimiter = FieldDelimiter;
            xmlPort.Properties.FieldSeparator = FieldSeparator;
            xmlPort.Properties.FileName = FileName;
            xmlPort.Properties.Format = Format;
            xmlPort.Properties.FormatEvaluate = FormatEvaluate;
            xmlPort.Properties.InlineSchema = InlineSchema;
            xmlPort.Properties.PreserveWhiteSpace = PreserveWhitespace;
            xmlPort.Properties.RecordSeparator = RecordSeparator;
            xmlPort.Properties.TableSeparator = TableSeparator;
            xmlPort.Properties.TextEncoding = TextEncoding;
            xmlPort.Properties.TransactionType = TransactionType;
            xmlPort.Properties.UseDefaultNamespace = UseDefaultNamespace;
            xmlPort.Properties.UseLax = UseLax;
            xmlPort.Properties.UseRequestPage = UseRequestPage;
            xmlPort.Properties.XmlVersionNo = XmlVersionNo;

            if (AutoCaption)
                xmlPort.AutoCaption();

            if (SubObjects != null)
            {
                var subObjects = SubObjects.Invoke().Select(o => o.BaseObject);
                xmlPort.Code.Documentation.CodeLines.AddRange(subObjects.OfType<string>());
                xmlPort.Nodes.AddRange(subObjects.OfType<XmlPortNode>());
                xmlPort.Code.Functions.AddRange(subObjects.OfType<Function>());
                xmlPort.Code.Variables.AddRange(subObjects.OfType<Variable>());
                xmlPort.Code.Events.AddRange(subObjects.OfType<Event>());
            }

            yield return xmlPort;
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSetNames.AddWithoutID)]
        public Application Application { get; set; }

        [Parameter()]
        public bool? DefaultFieldsValidation
        {
            get;
            set;
        }

        [Parameter()]
        public string DefaultNamespace
        {
            get;
            set;
        }

        [Parameter()]
        public Direction? Direction
        {
            get;
            set;
        }

        [Parameter()]
        public XmlPortEncoding? Encoding
        {
            get;
            set;
        }

        [Parameter()]
        public string FieldDelimiter
        {
            get;
            set;
        }

        [Parameter()]
        public string FieldSeparator
        {
            get;
            set;
        }

        [Parameter()]
        public string FileName
        {
            get;
            set;
        }

        [Parameter()]
        public XmlPortFormat? Format
        {
            get;
            set;
        }

        [Parameter()]
        public FormatEvaluate? FormatEvaluate
        {
            get;
            set;
        }

        [Parameter()]
        public bool? InlineSchema
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(ParameterSetName = ParameterSetNames.AddWithoutID)]
        public SwitchParameter PassThru { get; set; } = true;

        [Parameter()]
        public bool? PreserveWhitespace
        {
            get;
            set;
        }

        [Parameter()]
        public string RecordSeparator
        {
            get;
            set;
        }

        [Parameter()]
        public string TableSeparator
        {
            get;
            set;
        }

        [Parameter()]
        public TextEncoding? TextEncoding
        {
            get;
            set;
        }

        [Parameter()]
        public TransactionType? TransactionType
        {
            get;
            set;
        }

        [Parameter()]
        public bool? UseDefaultNamespace
        {
            get;
            set;
        }

        [Parameter()]
        public bool? UseLax
        {
            get;
            set;
        }

        [Parameter()]
        public bool? UseRequestPage
        {
            get;
            set;
        }

        [Parameter()]
        public XmlVersionNo? XmlVersionNo
        {
            get;
            set;
        }
    }
}