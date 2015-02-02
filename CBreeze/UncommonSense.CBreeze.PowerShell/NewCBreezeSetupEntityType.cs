using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.PowerShell
{
    [Cmdlet(VerbsCommon.New, "CBreezeSetupEntityType")]
    public class NewCBreezeSetupEntityType : CBreezePSCmdlet
    {
        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int TableID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int PageID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        [ValidateLength(1, 30)]
        public string TableName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        [ValidateLength(1, 30)]
        public string PageName
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var manifest = new SetupEntityTypeManifest(Application);

            manifest.SetupTable = Application.Tables.Add(TableID, TableName);
            manifest.SetupTable.Properties.CaptionML.Add("ENU", manifest.SetupTable.Name);

            manifest.SetupTablePrimaryKeyField = manifest.SetupTable.Fields.AddCodeTableField(1, "Primary Key");
            manifest.SetupTablePrimaryKeyField.Properties.CaptionML.Add("ENU", manifest.SetupTablePrimaryKeyField.Name);

            WriteObject(manifest);
        }
    }
}
