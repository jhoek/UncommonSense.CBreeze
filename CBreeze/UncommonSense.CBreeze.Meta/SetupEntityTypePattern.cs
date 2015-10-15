using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Patterns;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Meta
{
    public class SetupEntityTypePattern : EntityTypePattern
    {
        public SetupEntityTypePattern(Application application, IEnumerable<int> range, string name)
            : base(application, range, name)
        {
        }

        protected override void VerifyRequirements()
        {
            base.VerifyRequirements();
        }

        protected override void CreateObjects()
        {
            Table = Application.Tables.Add(new Table(Range.GetNextTableID(Application), Name).AutoCaption());
            Page = Application.Pages.Add(new Page(Range.GetNextPageID(Application), Name).AutoCaption());

            Page.Properties.PageType = PageType.Card;
            Page.Properties.InsertAllowed = false;
            Page.Properties.DeleteAllowed = false;

            var codeLines = Page.Properties.OnOpenPage.CodeLines;
            codeLines.Add("RESET;");
            codeLines.Add("IF NOT GET THEN BEGIN");
            codeLines.Add("  INIT;");
            codeLines.Add("  INSERT;");
            codeLines.Add("END;");
        }

        protected override void AfterCreateObjects()
        {
            Page.Properties.SourceTable = Table.ID;
        }

        protected override void CreateFields()
        {
            //var primaryKeyPattern = new PrimaryKeyPattern(Range, Table);
            //primaryKeyPattern.Apply();
            //PrimaryKeyField = primaryKeyPattern.PrimaryKeyField;
        }

        protected override void CreateControls()
        {
            var contentArea = Page.GetContentArea(Range);
            contentArea.GetGroupByCaption("General", Range, Position.FirstWithinContainer);
        }

        public Table Table
        {
            get;
            protected set;
        }

        public Page Page
        {
            get;
            protected set;
        }

        public CodeTableField PrimaryKeyField
        {
            get;
            protected set;
        }
    }
}
