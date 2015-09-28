using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTableFilterTableField")]
    public class AddCBreezeTableFilterTableField : AddCBreezeTableField
    {
        [Parameter()]
        public string TableIDExpr
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            foreach (var table in Table)
            {
                var field = table.Fields.Add(new TableFilterTableField(GetNo(table), Name));

                field.Properties.Description = Description;
                field.Properties.TableIDExpr = TableIDExpr;

                if (AutoCaption)
                    field.AutoCaption();

                if (PassThru)
                    WriteObject(field);
            }
        }
    }
}
