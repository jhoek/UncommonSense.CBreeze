using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeCodeTableField")]
    public class AddCBreezeCodeTableField : AddCBreezeTableField
    {
        public AddCBreezeCodeTableField()
        {
            DataLength = 10;
        }

        [Parameter()]
        [ValidateRange(1, 250)]
        public int DataLength
        {
            get;
            set;
        }

        [Parameter()]
        public bool? NotBlank
        {
            get;
            set;
        }

        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                No = AutoAssignNo(No);

                var field = Table.Fields.AddCodeTableField(No, Name, DataLength);
                field.Properties.NotBlank = NotBlank;

                field.AutoCaptionIf(AutoCaption);

                yield return field;
            }
        }

    }
}
