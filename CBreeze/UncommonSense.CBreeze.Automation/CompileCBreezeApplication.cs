using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.IO;

namespace UncommonSense.CBreeze.Automation
{
    /// <summary>
    /// <para type="description">Compiles one or more objects in a Microsoft Dynamics NAV database</para>
    /// </summary>
    [Cmdlet("Compile", "CBreezeApplication")]
    [Alias("Compile")]
    public class CompileCBreezeApplication : DevClientCmdlet
    {
        /// <summary>
        /// <para type="description">Sets the set of objects to be compiled</para>
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0)] public Application Application { get; set; }

        /// <summary>
        /// <para type="description">Sets the path to the Microsoft Dynamics NAV client (finsql.exe)</para>
        /// </summary>
        [Parameter()] public string DevClientPath { get; set; }

        /// <summary>
        /// <para type="description">Sets the Microsoft Dynamics NAV server name</para>
        /// </summary>
        [Parameter()] public string ServerName { get; set; } = ".";

        /// <summary>
        /// <para type="description">Sets the Microsoft Dynamics NAV database name</para>
        /// </summary>
        [Parameter(Mandatory = true)] public string Database { get; set; }

        /// <exlude/>
        protected override void ProcessRecord()
        {
            ApplicationCompiler.Compile(Application, DevClientPath ?? DefaultDevClientPath, ServerName, Database);
        }
    }
}