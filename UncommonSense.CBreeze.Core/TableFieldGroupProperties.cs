using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class TableFieldGroupProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");

        internal TableFieldGroupProperties(TableFieldGroup tableFieldGroup)
        {
            TableFieldGroup = tableFieldGroup;

            innerList.Add(captionML);
        }

        public TableFieldGroup TableFieldGroup { get; protected set; }

        public override INode ParentNode => TableFieldGroup;

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }
    }
}
