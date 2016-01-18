using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class ColumnReportElementProperties : Properties
    {
        private NullableBooleanProperty autoCalcField = new NullableBooleanProperty("AutoCalcField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private DecimalPlacesProperty decimalPlaces = new DecimalPlacesProperty("DecimalPlaces");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty includeCaption = new NullableBooleanProperty("IncludeCaption");
        private MultiLanguageProperty optionCaptionML = new MultiLanguageProperty("OptionCaptionML");
        private OptionStringProperty optionString = new OptionStringProperty("OptionString");
        private StringProperty sourceExpr = new StringProperty("SourceExpr");

        internal ColumnReportElementProperties()
        {
            innerList.Add(optionCaptionML);
            innerList.Add(optionString);
            innerList.Add(decimalPlaces);
            innerList.Add(description);
            innerList.Add(includeCaption);
            innerList.Add(sourceExpr);
            innerList.Add(autoCalcField);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
        }

        public bool? AutoCalcField
        {
            get
            {
                return this.autoCalcField.Value;
            }
            set
            {
                this.autoCalcField.Value = value;
            }
        }

        public string AutoFormatExpr
        {
            get
            {
                return this.autoFormatExpr.Value;
            }
            set
            {
                this.autoFormatExpr.Value = value;
            }
        }

        public AutoFormatType? AutoFormatType
        {
            get
            {
                return this.autoFormatType.Value;
            }
            set
            {
                this.autoFormatType.Value = value;
            }
        }

        public DecimalPlaces DecimalPlaces
        {
            get
            {
                return this.decimalPlaces.Value;
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

        public bool? IncludeCaption
        {
            get
            {
                return this.includeCaption.Value;
            }
            set
            {
                this.includeCaption.Value = value;
            }
        }

        public MultiLanguageValue OptionCaptionML
        {
            get
            {
                return this.optionCaptionML.Value;
            }
        }

        public string OptionString
        {
            get
            {
                return this.optionString.Value;
            }
            set
            {
                this.optionString.Value = value;
            }
        }

        public string SourceExpr
        {
            get
            {
                return this.sourceExpr.Value;
            }
            set
            {
                this.sourceExpr.Value = value;
            }
        }
    }
}
