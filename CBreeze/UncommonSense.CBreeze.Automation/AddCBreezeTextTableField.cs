using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTextTableField")]
    public class AddCBreezeTextTableField : AddCBreezeTableField
    {
        public AddCBreezeTextTableField()
        {
            DataLength = 30;
        }

        [Parameter()]
        [ValidateRange(1, 250)]
        public int DataLength
        {
            get;
            set;
        }

        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                No = GetNo();

                var field = Table.Fields.Add(new TextTableField(No, Name, DataLength));

                if (AutoCaption)
                    field.AutoCaption();

                yield return field;
            }
        }
    }
}
