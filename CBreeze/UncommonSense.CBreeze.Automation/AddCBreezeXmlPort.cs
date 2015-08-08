using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

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

        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                var xmlport = Application.XmlPorts.Add(ID, Name);

                xmlport.ObjectProperties.DateTime = DateTime;
                xmlport.ObjectProperties.Modified = Modified;
                xmlport.ObjectProperties.VersionList = VersionList;

                xmlport.Properties.DefaultFieldsValidation = DefaultFieldsValidation;
                xmlport.Properties.DefaultNamespace = DefaultNamespace;

                xmlport.AutoCaptionIf(AutoCaption);

                yield return xmlport;
            }
        }
    }
}
