using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class AddCBreezeParameter : AddCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter Var
        {
            get;
            set;
        }

        [Parameter()]
        [ValidateRange(1, int.MaxValue)]
        public int ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        public string Name
        {
            get;
            set;
        }

        [Parameter()]
        public string Dimensions
        {
            get;
            set;
        }

        protected int AutoAssignID(int id)
        {
            if (id != 0)
                return id;

            if (!Parameters.Any())
                return 1;

            return Parameters.Last().ID + 1;
        }

        protected Parameters Parameters
        {
            get
            {
                if (InputObject.BaseObject is Parameters)
                    return (InputObject.BaseObject as Parameters);
                if (InputObject.BaseObject is Function)
                    return (InputObject.BaseObject as Function).Parameters;
                if (InputObject.BaseObject is Event)
                    return (InputObject.BaseObject as Event).Parameters;

                throw new ApplicationException("Cannot add parameters to this object.");
            }
        }
    }
}
