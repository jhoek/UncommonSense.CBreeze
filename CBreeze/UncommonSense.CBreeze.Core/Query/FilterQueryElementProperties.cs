using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Query
{
    public class FilterQueryElementProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private ColumnFilterProperty columnFilter = new ColumnFilterProperty("ColumnFilter");
        private StringProperty dataSource = new StringProperty("DataSource");
        private StringProperty description = new StringProperty("Description");

        internal FilterQueryElementProperties(FilterQueryElement element)
        {
            Element = element;

            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(columnFilter);
            innerList.Add(dataSource);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public TableFilter ColumnFilter
        {
            get
            {
                return this.columnFilter.Value;
            }
        }

        public string DataSource
        {
            get
            {
                return this.dataSource.Value;
            }
            set
            {
                this.dataSource.Value = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description.Value;
            }
            set
            {
                this.description.Value = value;
            }
        }

        public FilterQueryElement Element { get; protected set; }

        public override INode ParentNode => Element;
    }
}