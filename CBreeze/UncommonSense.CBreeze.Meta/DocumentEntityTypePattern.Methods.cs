using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Patterns;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Meta
{
    public partial class DocumentEntityTypePattern : EntityTypePattern
    {
        public DocumentEntityTypePattern(Application application, IEnumerable<int> range, string name)
            : base(application, range, name)
        {
            CardPages = new PatternResults<string, Page>();
            ListPages = new PatternResults<string, Page>();
        }

        protected override void CreateObjects()
        {
            HeaderTable = Application.Tables.Add(new Table(Range.GetNextTableID(Application), HeaderName).AutoCaption());
            LineTable = Application.Tables.Add(new Table(Range.GetNextTableID(Application), LineName).AutoCaption());

            foreach (var documentType in DocumentTypes)
            {
                CardPages.Add(documentType, Application.Pages.Add(new Page(Range.GetNextPageID(Application), string.Format("{0} {1}", Name, documentType)).AutoCaption()));
                ListPages.Add(documentType, Application.Pages.Add(new Page(Range.GetNextPageID(Application), string.Format("{0} {1} List", Name, documentType)).AutoCaption()));
            }
        }

        protected IEnumerable<string> DocumentTypes
        {
            get
            {
                if (string.IsNullOrEmpty(DocumentTypeOptions))
                {
                    yield return Name;
                    yield break;
                }

                foreach(var documentType in DocumentTypeOptions.Split(','))
                {
                    yield return documentType;
                }
            }
        }
    }
}
