using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using System.Management.Automation;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class AddCBreezeTableField2<T> : NewNamedItemCmdlet<T, Table> where T : TableField
    {
        [Parameter()]
        public SwitchParameter AutoCaption { get; set; }

        [Parameter()]
        public string Description { get; set; }

        [Parameter()]
        public bool? Enabled { get; set; }

        protected override void AddItemToInputObject(T item, Table inputObject)
        {
            inputObject.Fields.Add(item);
        }
    }
}