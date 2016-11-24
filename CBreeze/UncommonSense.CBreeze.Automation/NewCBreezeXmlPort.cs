using System;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeXmlPort")]
    public class NewCBreezeXmlPort : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        [Alias("Range")]
        public PSObject ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateLength(1, 30)]
        public string Name
        {
            get;
            set;
        }

        [Parameter()]
        public DateTime? DateTime
        {
            get;
            set;
        }

        [Parameter()]
        public bool Modified
        {
            get;
            set;
        }

        [Parameter()]
        public string VersionList
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter AutoCaption
        {
            get;
            set;
        }

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

        protected override void ProcessRecord()
        {
            var xmlPort = new XmlPort(ID.GetID(null, 0), Name);

            xmlPort.ObjectProperties.DateTime = DateTime;
            xmlPort.ObjectProperties.Modified = Modified;
            xmlPort.ObjectProperties.VersionList = VersionList;

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

            WriteObject(xmlPort);
        }
    }
}
