using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Patterns
{
    public class NoSeriesPattern : AddFieldsPattern
    {
        public NoSeriesPattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
        }

        public override void VerifyRequirements()
        {
            base.VerifyRequirements();

            if (SetupTable == null)
                throw new ArgumentNullException("SetupTable");

            if (SetupPage == null)
                throw new ArgumentNullException("SetupPage");
        }

        public override void Apply()
        {
            base.Apply();

            CreateFields();
            SetFieldProperties();
            CreateControls();
        }

        protected override void CreateFields()
        {
            NoField = Table.Fields.Add(new CodeTableField(Range.GetNextPrimaryKeyFieldNo(Table), "No.", 20).AutoCaption());
            NoSeriesField = Table.Fields.Add(new CodeTableField(Range.GetNextTableFieldNo(Table, 90), "No. Series", 10).AutoCaption());

        }

        protected override void CreateCardPageControls(Page page)
        {
            throw new NotImplementedException();
        }

        protected override void CreateListPageControls(Page page)
        {
            throw new NotImplementedException();
        }

        public Table SetupTable
        {
            get;
            set;
        }

        public Page SetupPage
        {
            get;
            set;
        }

        public CodeTableField NoField
        {
            get;
            protected set;
        }

        public CodeTableField NoSeriesField
        {
            get;
            protected set;
        }

        public CodeTableField SetupField
        {
            get;
            protected set;
        }
    }
}
