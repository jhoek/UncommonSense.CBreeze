using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script
{
    [Cmdlet(VerbsData.ConvertTo, "CBreezeScript")]
    [OutputType(typeof(FileInfo))]
    public class ConvertToCBreezeScriptCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Application Application { get; set; }

        [Parameter(Mandatory = true, Position = 0)]
        public string Path { get; set; }

        protected override void EndProcessing()
        {
            var path = GetUnresolvedProviderPathFromPSPath(Path);
            var directory = System.IO.Path.GetDirectoryName(path);

            File.WriteAllText(path, Application.ToInvocation(directory).ToString(), Encoding.UTF8);
            WriteObject(new FileInfo(path));
        }
    }
}