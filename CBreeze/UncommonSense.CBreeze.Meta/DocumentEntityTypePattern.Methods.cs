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
            CardPages = new MappedResults<string, Page>();
            ListPages = new MappedResults<string, Page>();
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

        protected override void AfterCreateObjects()
        {
            var tableRelation = LineTableDocumentNoField.Properties.TableRelation.Set(HeaderTable.Name, HeaderTableNoField.Name);

            if (!string.IsNullOrEmpty(DocumentTypeOptions))
            {
                tableRelation.TableFilter.Add(HeaderTableDocumentTypeField.Name, TableFilterType.Field, LineTableDocumentTypeField.Name);
            }

            foreach (var documentType in DocumentTypes)
            {
                CardPages[documentType].Properties.SourceTable = HeaderTable.ID;
                CardPages[documentType].Properties.PageType = PageType.Card;

                ListPages[documentType].Properties.SourceTable = HeaderTable.ID;
                ListPages[documentType].Properties.PageType = PageType.List;
            }
        }

        protected override void CreateFields()
        {
            if (!string.IsNullOrEmpty(DocumentTypeOptions))
            {
                HeaderTableDocumentTypeField = HeaderTable.Fields.Add(new OptionTableField(Range.GetNextPrimaryKeyFieldNo(HeaderTable), "Document Type").AutoCaption());
                HeaderTableDocumentTypeField.Properties.OptionString = DocumentTypeOptions;
                HeaderTableDocumentTypeField.AutoOptionCaption();

                LineTableDocumentTypeField = LineTable.Fields.Add(new OptionTableField(Range.GetNextPrimaryKeyFieldNo(LineTable), "Document Type").AutoCaption());
                LineTableDocumentTypeField.Properties.OptionString = DocumentTypeOptions;
                LineTableDocumentTypeField.AutoOptionCaption();
            }

            // FIXME: Quite possibly, NoSeriesPattern should handle the Document Type as well (since it already needs to create multiple setup fields etc.).
            // FIXME: Create No. and Document No. field

            // FIXME: Pattern for Line No. for document line could be reused for subsidiary entity types whose differentiator type is LineNo?
            // FIXME: Create primary keys
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
