using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public class AddCommunicationFieldsManifest
    {
        internal AddCommunicationFieldsManifest()
        {
        }

        public TextTableField ContactField
        {
            get;
            internal set;
        }

        public TextTableField PhoneNoField
        {
            get;
            internal set;
        }

        public TextTableField TelexNoField
        {
            get;
            internal set;
        }

        public TextTableField TelexAnswerBackField
        {
            get;
            internal set;
        }

        public TextTableField FaxNoField
        {
            get;
            internal set;
        }

        public TextTableField EMailField
        {
            get;
            internal set;
        }

        public TextTableField HomePageField
        {
            get;
            internal set;
        }
    }

    public static class AddCommunicationFieldsExtensionMethods
    {
        public static AddCommunicationFieldsManifest AddCommunicationFields(this Table table, IEnumerable<int> range, bool contact = true, bool phoneNo = true, bool faxNo = true, bool telexNo = false, bool email=true, bool homePage = true, string prefix = null)
        {
            var manifest = new AddCommunicationFieldsManifest();

            if (contact)    
            {
                manifest.ContactField = table.Fields.Add(new TextTableField(range.GetNextTableFieldNo(table), string.Format("{0}Contact", prefix), 50).AutoCaption());
            }

            if (phoneNo)
            {
                manifest.PhoneNoField = table.Fields.Add(new TextTableField(range.GetNextTableFieldNo(table), string.Format("{0}Phone No.", prefix), 30).AutoCaption());
                manifest.PhoneNoField.Properties.ExtendedDatatype = ExtendedDataType.PhoneNo;
            }

            if (telexNo)
            {
                manifest.TelexNoField = table.Fields.Add(new TextTableField(range.GetNextTableFieldNo(table), string.Format("{0}Telex No.", prefix), 30).AutoCaption());
                manifest.TelexAnswerBackField = table.Fields.Add(new TextTableField(range.GetNextTableFieldNo(table), string.Format("{0}Telex Answer Back", prefix), 20).AutoCaption());
            }

            if (faxNo)
            {
                manifest.FaxNoField = table.Fields.Add(new TextTableField(range.GetNextTableFieldNo(table), string.Format("{0}Fax No.", prefix), 30).AutoCaption());
            }

            if (email)
            {
                manifest.EMailField = table.Fields.Add(new TextTableField(range.GetNextTableFieldNo(table), string.Format("{0}E-Mail", prefix), 80).AutoCaption());
                manifest.EMailField.Properties.ExtendedDatatype = ExtendedDataType.EMail;
            }

            if (homePage)
            {
                manifest.HomePageField = table.Fields.Add(new TextTableField(range.GetNextTableFieldNo(table), string.Format("{0}Home Page", prefix), 80).AutoCaption());
                manifest.HomePageField.Properties.ExtendedDatatype = ExtendedDataType.Url;
            }

            return manifest;
        }
    }
}
