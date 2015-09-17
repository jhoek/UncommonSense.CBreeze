using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Meta
{
    public partial class DocumentEntityTypePattern : EntityTypePattern
    {
        public DocumentEntityTypePattern(Application application, IEnumerable<int> range, string name)
            : base(application, range, name)
        {
        }

        protected override void CreateObjects()
        {
            HeaderTable = Application.Tables.Add(new Table(Range.GetNextTableID(Application), HeaderName).AutoCaption());
            LineTable = Application.Tables.Add(new Table(Range.GetNextTableID(Application), LineName).AutoCaption());

            var documentTypes = new List<string>();

            if (string.IsNullOrEmpty(DocumentTypeOptions))
            {
                documentTypes.Add(Name);
            }
            else
            {
                documentTypes.AddRange(DocumentTypeOptions.Split(','));
            }

            foreach(var documentType in documentTypes)
            {
                cardPages.Add(documentType, Application.Pages.Add(new Page(Range.GetNextPageID(Application), string.Format("{0} {1}", Name, documentType)).AutoCaption()));
                listPages.Add(documentType, Application.Pages.Add(new Page(Range.GetNextPageID(Application), string.Format("{0} {1} List", Name, documentType)).AutoCaption()));
            }
        }

        protected override void LinkObjects()
        {
               
        }
    }
}
