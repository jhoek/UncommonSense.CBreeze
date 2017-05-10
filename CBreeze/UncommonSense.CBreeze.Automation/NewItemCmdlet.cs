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
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.AddWithID)]
        public int ID { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSetNames.AddWithoutID)]
        public TInputObject InputObject { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(ParameterSetName = ParameterSetNames.AddWithoutID)]
        public SwitchParameter PassThru { get; set; }

        protected abstract void AddItemToInputObject(TItem item, TInputObject inputObject);

        protected abstract TItem CreateItem();

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.NewWithoutID:
                case ParameterSetNames.NewWithID:
                    WriteObject(CreateItem());
                    break;

                case ParameterSetNames.AddWithoutID:
                case ParameterSetNames.AddWithID:
                    var item = CreateItem();
                    AddItemToInputObject(item, InputObject);

                    if (PassThru)
                        WriteObject(item);

                    break;
            }
        }
    }
}