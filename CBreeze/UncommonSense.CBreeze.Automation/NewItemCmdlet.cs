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

        protected abstract TItem CreateItem();

        protected override void ProcessRecord()
        {
            var item = CreateItem();

            switch (ParameterSetName)
            {
                case ParameterSetNames.NewWithoutID:
                case ParameterSetNames.NewWithID:
                    WriteVerbose($"Creating new item '{item}'");
                    WriteObject(item);
                    break;

                case ParameterSetNames.AddWithoutID:
                case ParameterSetNames.AddWithID:
                    WriteVerbose($"Adding new item '{item}' to '{InputObject}'");
                    AddItemToInputObject(item, InputObject);

                    if (PassThru)
                    {
                        WriteVerbose("Passing through new item");
                        WriteObject(item);
                    }

                    break;
            }
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSetNames.AddWithoutID)]
        public virtual TInputObject InputObject { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(ParameterSetName = ParameterSetNames.AddWithoutID)]
        public SwitchParameter PassThru { get; set; }
    }
}