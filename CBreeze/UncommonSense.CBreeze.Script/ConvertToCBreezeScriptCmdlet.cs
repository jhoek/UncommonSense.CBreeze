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
    [Cmdlet(VerbsData.ConvertTo, "CBreezeScript", DefaultParameterSetName = ParameterSets.ToStdOut)]
    [OutputType(typeof(string), ParameterSetName = new string[] { ParameterSets.ToStdOut })]
    [OutputType(typeof(FileInfo), ParameterSetName = new string[] { ParameterSets.ToPath })]
    public class ConvertToCBreezeScriptCmdlet : PSCmdlet
    {
        public class ParameterSets
        {
            public const string ToPath = "ToPath";
            public const string ToStdOut = "ToStdOut";
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Application Application { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ParameterSets.ToPath)]
        public string Path { get; set; }

        protected override void EndProcessing()
        {
            switch (ParameterSetName)
            {
                case ParameterSets.ToStdOut:
                    WriteObject(Application.ToInvocation().ToString());
                    break;

                case ParameterSets.ToPath:
                    var path = GetUnresolvedProviderPathFromPSPath(Path);
                    File.WriteAllText(path, Application.ToInvocation().ToString(), Encoding.UTF8);
                    WriteObject(new FileInfo(path));
                    break;
            }
        }
    }
}