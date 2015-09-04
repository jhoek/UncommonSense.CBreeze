using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public class CommunicationFieldsManifest
    {
        internal CommunicationFieldsManifest()
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

    public class CommunicationControlsManifest
    {
        internal CommunicationControlsManifest()
        {
        }

        public FieldPageControl ContactControl
        {
            get;
            internal set;
        }

        public FieldPageControl PhoneNoControl
        {
            get;
            internal set;
        }

        public FieldPageControl TelexNoControl
        {
            get;
            internal set;
        }

        public FieldPageControl TelexAnswerBackControl
        {
            get;
            internal set;
        }

        public FieldPageControl FaxNoControl
        {
            get;
            internal set;
        }

        public FieldPageControl EMailControl
        {
            get;
            internal set;
        }

        public FieldPageControl HomePageControl
        {
            get;
            internal set;
        }
    }

    public static class CommunicationExtensionMethods
    {
        public static CommunicationFieldsManifest AddCommunicationFields(this Table table, IEnumerable<int> range, bool contact = true, bool phoneNo = true, bool faxNo = true, bool telexNo = false, bool email=true, bool homePage = true, string prefix = null)
        {
            var manifest = new CommunicationFieldsManifest();

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

        public static CommunicationControlsManifest AddCommunicationControls(this Page page, CommunicationFieldsManifest fieldsManifest, IEnumerable<int> range, Position position)
        {
            var manifest = new CommunicationControlsManifest();
            var contentArea = page.GetContentArea();

            switch (page.Properties.PageType)
            {
                case PageType.Card:
                    var generalGroup = contentArea.GetGroupByCaption("General", range, position);

                    if (fieldsManifest.PhoneNoField != null)
                    {
                        
                    }

                    break;
                case PageType.List:
                    var listGroup = contentArea.GetGroupByType(GroupType.Repeater, range, Position.FirstWithinContainer);

                    if (fieldsManifest.PhoneNoField != null)
                    {
                        manifest.PhoneNoControl = listGroup.AddChildPageControl(new FieldPageControl(range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
                        manifest.PhoneNoControl.Properties.SourceExpr = fieldsManifest.PhoneNoField.Name.Quoted();
                    }

                    if (fieldsManifest.FaxNoField != null)
                    {
                        manifest.FaxNoControl = listGroup.AddChildPageControl(new FieldPageControl(range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
                        manifest.FaxNoControl.Properties.SourceExpr = fieldsManifest.FaxNoField.Name.Quoted();
                        manifest.FaxNoControl.Properties.Visible = "FALSE";
                    }

                    if (fieldsManifest.ContactField != null)
                    {
                        manifest.ContactControl = listGroup.AddChildPageControl(new FieldPageControl(range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
                        manifest.ContactControl.Properties.SourceExpr = fieldsManifest.ContactField.Name.Quoted();
                    }

                    break;
            }

            return manifest;
        }
    }
}
