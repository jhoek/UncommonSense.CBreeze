using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class ColumnQueryElementProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private ColumnFilterProperty columnFilter = new ColumnFilterProperty("ColumnFilter");
        private StringProperty dataSource = new StringProperty("DataSource");
        private DateMethodProperty dateMethod = new DateMethodProperty("DateMethod");
        private StringProperty description = new StringProperty("Description");
        private MethodTypeProperty methodType = new MethodTypeProperty("MethodType");
        private NullableBooleanProperty reverseSign = new NullableBooleanProperty("ReverseSign");
        private TotalsMethodProperty totalsMethod = new TotalsMethodProperty("TotalsMethod");

        internal ColumnQueryElementProperties(ColumnQueryElement columnQueryElement)
        {
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(columnFilter);
            innerList.Add(dataSource);
            innerList.Add(reverseSign);
            innerList.Add(methodType);
            innerList.Add(dateMethod);
            innerList.Add(totalsMethod);
        }

        public ColumnQueryElement ColumnQueryElement { get; protected set; }

        public override INode ParentNode => ColumnQueryElement;

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public ColumnFilter ColumnFilter
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

        public DateMethod? DateMethod
        {
            get
            {
                return this.dateMethod.Value;
            }
            set
            {
                this.dateMethod.Value = value;
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

        public MethodType? MethodType
        {
            get
            {
                return this.methodType.Value;
            }
            set
            {
                this.methodType.Value = value;
            }
        }

      public bool? ReverseSign
        {
            get
            {
                return this.reverseSign.Value;
            }
            set
            {
                this.reverseSign.Value = value;
            }
        }

        public TotalsMethod? TotalsMethod
        {
            get
            {
                return this.totalsMethod.Value;
            }
            set
            {
                this.totalsMethod.Value = value;
            }
        }
    }
}
