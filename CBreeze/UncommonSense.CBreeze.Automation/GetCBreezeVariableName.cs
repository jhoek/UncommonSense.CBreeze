using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Code.Variable;

namespace UncommonSense.CBreeze.Automation
{
    /// <summary>
    /// <para type="synopsis">Converts a name that may contain spaces and special characters to a valid C/SIDE variable name</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CBreezeVariableName")]
    [OutputType(typeof(string))]
    public class GetCBreezeVariableName : Cmdlet
    {
        /// <summary>
        /// <para type="synopsis">The name to be converted</para>
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Position = 1)]
        public string[] Name { get; set; }

        /// <exclude/>
        protected override void ProcessRecord()
        {
            foreach (var name in Name)
            {
                WriteObject(name.MakeVariableName());
            }
        }
    }
}
