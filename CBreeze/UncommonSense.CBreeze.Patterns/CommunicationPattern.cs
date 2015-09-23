using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Patterns
{
    public class CommunicationPattern : AddFieldsPattern
    {
        public CommunicationPattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
            ContactControls = new MappedResults<Page, FieldPageControl>();
            PhoneNoControls = new MappedResults<Page, FieldPageControl>();
            PhoneNoControls2 = new MappedResults<Page, FieldPageControl>();
            TelexNoControls = new MappedResults<Page, FieldPageControl>();
            TelexAnswerBackControls = new MappedResults<Page, FieldPageControl>();
            FaxNoControls = new MappedResults<Page, FieldPageControl>();
            EMailControls = new MappedResults<Page, FieldPageControl>();
            HomePageControls = new MappedResults<Page, FieldPageControl>();

            HasContact = true;
            HasPhoneNo = true;
            HasFaxNo = true;
            HasTelexNo = false;
            HasEmail = true;
            HasHomePage = true;

            GroupCaption = "Communication";
            CardPageGroupPosition = Utils.Position.LastWithinContainer;
            ListPageGroupPosition = Utils.Position.FirstWithinContainer;
        }

        protected override void CreateFields()
        {
            if (HasContact)
            {
                ContactField = Table.Fields.Add(new TextTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}Contact", Prefix), 50).AutoCaption());
            }

            if (HasPhoneNo)
            {
                PhoneNoField = Table.Fields.Add(new TextTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}Phone No.", Prefix), 30).AutoCaption());
                PhoneNoField.Properties.ExtendedDatatype = ExtendedDataType.PhoneNo;
            }

            if (HasTelexNo)
            {
                TelexNoField = Table.Fields.Add(new TextTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}Telex No.", Prefix), 20).AutoCaption());
                TelexAnswerBackField = Table.Fields.Add(new TextTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}Telex Answer Back", Prefix), 20).AutoCaption());
            }

            if (HasFaxNo)
            {
                FaxNoField = Table.Fields.Add(new TextTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}Fax No.", Prefix),30).AutoCaption());
            }

            if (HasEmail)
            {
                EMailField = Table.Fields.Add(new TextTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}E-Mail", Prefix), 80).AutoCaption());
                EMailField.Properties.ExtendedDatatype = ExtendedDataType.EMail;
            }

            if (HasHomePage)
            {
                HomePageField = Table.Fields.Add(new TextTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}Home Page", Prefix), 80).AutoCaption());
                HomePageField.Properties.ExtendedDatatype = ExtendedDataType.Url;
            }
        }

        protected override void CreateCardPageControls(Page page)
        {
            if (HasPhoneNo)
            {
                PhoneNoControls.Add(page, CreateCardPageControl(page, "General", Position.FirstWithinContainer, Position.LastWithinContainer, PhoneNoField.Name));
                PhoneNoControls2.Add(page, CreateCardPageControl(page, GroupCaption, Position.LastWithinContainer, Position.LastWithinContainer, PhoneNoField.Name).Promote());
            }

            if (HasContact)
            {
                ContactControls.Add(page, CreateCardPageControl(page, "General", Position.FirstWithinContainer, Position.LastWithinContainer, ContactField.Name).Promote());
            }

            if (HasFaxNo)
            {
                FaxNoControls.Add(page, CreateCardPageControl(page,GroupCaption, Position.LastWithinContainer, Position.LastWithinContainer, FaxNoField.Name));
            }

            if (HasEmail)
            {
                EMailControls.Add(page, CreateCardPageControl(page, GroupCaption, Position.LastWithinContainer, Position.LastWithinContainer, EMailField.Name).Promote());
            }

            if (HasHomePage)
            {
                HomePageControls.Add(page, CreateCardPageControl(page, GroupCaption, Position.LastWithinContainer, Position.LastWithinContainer, HomePageField.Name));
            }
        }

        protected override void CreateListPageControls(Page page)
        {
            if (HasPhoneNo)
            {
                PhoneNoControls.Add(page, CreateListPageControl(page, Position.LastWithinContainer, PhoneNoField.Name)); 
            }

            if (HasFaxNo)
            {
                FaxNoControls.Add(page, CreateListPageControl(page, Position.LastWithinContainer, FaxNoField.Name).Hide());
            }

            if (HasContact)
            {
                ContactControls.Add(page, CreateListPageControl(page, Position.LastWithinContainer, ContactField.Name));
            }
        }

        public bool HasContact
        {
            get;
            set;
        }

        public bool HasPhoneNo
        {
            get;
            set;
        }

        public bool HasFaxNo
        {
            get;
            set;
        }

        public bool HasTelexNo
        {
            get;
            set;
        }

        public bool HasEmail
        {
            get;
            set;
        }

        public bool HasHomePage
        {
            get;
            set;
        }

        public TextTableField ContactField
        {
            get;
            protected set;
        }
        
        public MappedResults<Page, FieldPageControl> ContactControls
        {
            get;
            protected set;
        }

        public TextTableField PhoneNoField
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> PhoneNoControls
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> PhoneNoControls2
        {
            get;
            protected set;
        }

        public TextTableField TelexNoField
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> TelexNoControls
        {
            get;
            protected set;
        }

        public TextTableField TelexAnswerBackField
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> TelexAnswerBackControls
        {
            get;
            protected set;
        }

        public TextTableField FaxNoField
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> FaxNoControls
        {
            get;
            protected set;
        }

        public TextTableField EMailField
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> EMailControls
        {
            get;
            protected set;
        }

        public TextTableField HomePageField
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> HomePageControls
        {
            get;
            protected set;
        }
    }
}
