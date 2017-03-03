using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class OptionTableField : TableField, IHasOptionString
    {
        public OptionTableField(string name) : this(0, name)
        {
        }

        public OptionTableField(int no, string name)
            : base(no, name)
        {
            Properties = new OptionTableFieldProperties(this);
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public OptionTableFieldProperties Properties
        {
            get;
            protected set;
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Option;
            }
        }

        public string GetOptionString()
        {
            return Properties.OptionString;
        }
    }
}