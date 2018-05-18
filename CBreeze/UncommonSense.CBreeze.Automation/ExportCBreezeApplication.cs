using Microsoft.PowerShell.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.IO;
using UncommonSense.CBreeze.Write;
using Object = UncommonSense.CBreeze.Core.Base.Object;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsData.Export, "CBreezeApplication", DefaultParameterSetName = "ToTextWriter")]
    [Alias("Export")]
    public class ExportCBreezeApplication : DevClientCmdlet
    {
        protected Application CachedObjects = new Application();

        protected override void BeginProcessing()
        {
            CachedObjects.Clear();
        }

        protected override void EndProcessing()
        {
            Action<string, object> writeVerbose = (targetType, target) => WriteVerbose($"Exporting {CachedObjects.Objects.Count()} object(s) to {targetType} {target}");

            switch (ParameterSetName)
            {
                case "ToPath":
                    var path = GetUnresolvedProviderPathFromPSPath(Path);
                    writeVerbose("path", path);

                    this.WriteObjectIf(!PassThru, Directory ? CachedObjects.WriteToFolder(path) : CachedObjects.WriteToFile(path).AsEnumerable());
                    this.WriteObjectIf(PassThru, CachedObjects);

                    break;

                case "ToTextWriter":
                    writeVerbose("TextWriter", "");
                    CachedObjects.WriteToTextWriter(TextWriter ?? Console.Out);
                    this.WriteObjectIf(PassThru, CachedObjects);
                    break;

                case "ToStream":
                    writeVerbose("Stream", "");
                    CachedObjects.WriteToStream(Stream);
                    this.WriteObjectIf(PassThru, CachedObjects);
                    break;

                case "ToDatabase":
                    writeVerbose("database", Database);
                    ApplicationImporter.Import(CachedObjects, DevClientPath ?? DefaultDevClientPath, ServerName, Database, ImportAction);

                    if (AutoCompile)
                        ApplicationCompiler.Compile(CachedObjects, DevClientPath ?? DefaultDevClientPath, ServerName, Database);

                    this.WriteObjectIf(PassThru, CachedObjects);
                    break;
            }
        }

        protected override void ProcessRecord()
        {
            foreach (var item in InputObject)
            {
                switch (item.BaseObject)
                {
                    case Application a:
                        CachedObjects.Add(a.Objects);
                        break;

                    case Object o:
                        CachedObjects.Add(o);
                        break;
                }
            }
        }

        [Parameter(ParameterSetName = "ToDatabase")] public SwitchParameter AutoCompile { get; set; }
        [Parameter(Mandatory = true, ParameterSetName = "ToDatabase")] public string Database { get; set; }
        [Parameter(ParameterSetName = "ToDatabase")] public string DevClientPath { get; set; }
        [Parameter(ParameterSetName = "ToPath")] public SwitchParameter Directory { get; set; }
        [Parameter(ParameterSetName = "ToDatabase")] public ImportAction ImportAction { get; set; } = ImportAction.Default;
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0)] [Alias("Application")] public PSObject[] InputObject { get; set; }
        [Parameter()] public SwitchParameter PassThru { get; set; }
        [Parameter(Mandatory = true, ParameterSetName = "ToPath", Position = 1)] public string Path { get; set; }
        [Parameter(ParameterSetName = "ToDatabase")] public string ServerName { get; set; } = ".";
        [Parameter(Mandatory = true, ParameterSetName = "ToStream", Position = 1)] public Stream Stream { get; set; }
        [Parameter(ParameterSetName = "ToTextWriter", Position = 1)] public TextWriter TextWriter { get; set; }
    }
}