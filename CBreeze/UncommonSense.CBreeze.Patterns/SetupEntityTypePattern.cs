using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Patterns
{
    public class SetupEntityTypePattern : EntityTypePattern
    {
        public SetupEntityTypePattern(Application application, IEnumerable<int> range, string name)
            : base(application, range)
        {
            Name = name;
        }

        protected override void VerifyRequirements()
        {
            base.VerifyRequirements();
        }

        protected override void MakeChanges()
        {
            Table = Application.Tables.Add(new Table(Range.GetNextTableID(Application), Name).AutoCaption());
            Page = Application.Pages.Add(new Page(Range.GetNextPageID(Application), Name).AutoCaption());

            new PrimaryKeyPattern(Range, Table).Apply();

            Page.Properties.PageType = PageType.Card;
            Page.Properties.InsertAllowed = false;
            Page.Properties.DeleteAllowed = false;
            Page.Properties.SourceTable = Table.ID;

            var codeLines = Page.Properties.OnOpenPage.CodeLines;

            codeLines.Add("RESET;");
            codeLines.Add("IF NOT GET THEN BEGIN");
            codeLines.Add("  INIT;");
            codeLines.Add("  INSERT;");
            codeLines.Add("END;");
        }

        public string Name
        {
            get;
            set;
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
    }
}
