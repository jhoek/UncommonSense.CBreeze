using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class NewItemCmdlet<TItem, TInputObject> : PSCmdlet
    {
        protected abstract void AddItemToInputObject(TItem item, TInputObject inputObject);

        protected abstract IEnumerable<TItem> CreateItems();

        protected override void ProcessRecord()
        {
            CreateItems()
                .ForEachIf(i => ParameterSetNames.IsAdd(ParameterSetName), i => AddItemToInputObject(i, InputObject))
                .ForEachIf(i => ParameterSetNames.IsNew(ParameterSetName) || PassThru, i => WriteObject(i));
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSetNames.AddWithoutID)]
        public virtual TInputObject InputObject { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(ParameterSetName = ParameterSetNames.AddWithoutID)]
        public SwitchParameter PassThru { get; set; }
    }
}