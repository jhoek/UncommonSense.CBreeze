using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class AddCmdlet : Cmdlet
    {
        [Parameter()]
        public SwitchParameter PassThru
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            foreach (var addedObject in AddedObjects)
            {
                if (PassThru)
                {
                    WriteObject(addedObject);
                }
            }
        }

        protected abstract IEnumerable AddedObjects
        {
            get;
        }
    }
}
