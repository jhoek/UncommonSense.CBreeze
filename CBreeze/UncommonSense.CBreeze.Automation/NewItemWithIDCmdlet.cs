using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class NewItemWithIDCmdlet<TItem, TID, TInputObject> : NewItemCmdlet<TItem, TInputObject>
    {
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.AddWithID)]
        public TID ID { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSetNames.AddWithoutID)]
        public override TInputObject InputObject { get; set; }
    }
}