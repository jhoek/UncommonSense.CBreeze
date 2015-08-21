using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeXmlPort")]
    public class AddCBreezeXmlPort : AddCBreezeObject
    {
        [Parameter()]
        public bool DefaultFieldsValidation
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
        public XmlPortEncoding Encoding
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
        public XmlPortFormat Format
        {
            get;
            set;
        }

        [Parameter()]
        public FormatEvaluate FormatEvaluate
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
        public TextEncoding TextEncoding
        {
            get;
            set;
        }

        [Parameter()]
        public TransactionType TransactionType
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
        public XmlVersionNo XmlVersionNo
        {
            get;
            set;
        }

        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                var xmlport = Application.XmlPorts.Add(new XmlPort(ID, Name));

                xmlport.ObjectProperties.DateTime = DateTime;
                xmlport.ObjectProperties.Modified = Modified;
                xmlport.ObjectProperties.VersionList = VersionList;

                xmlport.Properties.DefaultFieldsValidation = DefaultFieldsValidation;
                xmlport.Properties.DefaultNamespace = DefaultNamespace;
                xmlport.Properties.Direction = Direction;
                xmlport.Properties.Encoding = Encoding;
                xmlport.Properties.FieldDelimiter = FieldDelimiter;
                xmlport.Properties.FieldSeparator = FieldSeparator;
                xmlport.Properties.FileName = FileName;
                xmlport.Properties.Format = Format;
                xmlport.Properties.FormatEvaluate = FormatEvaluate;
                xmlport.Properties.InlineSchema = InlineSchema;
                xmlport.Properties.PreserveWhiteSpace = PreserveWhitespace;
                xmlport.Properties.RecordSeparator = RecordSeparator;
                xmlport.Properties.TableSeparator = TableSeparator;
                xmlport.Properties.TextEncoding = TextEncoding;
                xmlport.Properties.TransactionType = TransactionType;
                xmlport.Properties.UseDefaultNamespace = UseDefaultNamespace;
                xmlport.Properties.UseLax = UseLax;
                xmlport.Properties.UseRequestPage = UseRequestPage;
                xmlport.Properties.XmlVersionNo = XmlVersionNo;

                if (AutoCaption)
                    xmlport.AutoCaption();

                yield return xmlport;
            }
        }
    }
}
