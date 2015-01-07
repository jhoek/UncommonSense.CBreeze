using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "NAVMasterEntityType")]
    public class NewMasterEntityType : Cmdlet
    {
        private Application application;
        private int tableID = 50000;

        [Parameter(ValueFromPipeline = true)]
        [ValidateNotNull()]
        public Application Application
        {
            get
            {
                if (this.application == null)
                {
                    this.application = new Application();
                }

                return this.application;
            }
            set
            {
                this.application = value;
            }
        }

        [Parameter()]
        [ValidateRange(0, int.MaxValue)]
        public int TableID
        {
            get
            {
                return this.tableID;
            }
            set
            {
                this.tableID = value;
            }
        }

        protected override void ProcessRecord()
        {
            var table = Application.Tables.Add(TableID, TableName);


            WriteObject(table);
        }
    }
}
