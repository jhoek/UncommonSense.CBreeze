using Microsoft.PowerShell.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.IO;
using UncommonSense.CBreeze.Read;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsData.Import, "CBreezeApplication", DefaultParameterSetName = "FromPath")]
    [OutputType(typeof(Application))]
    [Alias("Import")]
    public class ImportCBreezeApplication : DevClientCmdlet
    {
        protected List<string> CachedPaths = new List<string>();

        public ImportCBreezeApplication()
        {
            ServerName = ".";
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Position = 0, ParameterSetName = "FromPath")]
        public string[] Path
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "FromDatabase")]
        public string DevClientPath
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "FromDatabase")]
        public string ServerName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "FromDatabase")]
        public string Database
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "FromDatabase")]
        public string Filter
        {
            get;
            set;
        }

        protected IEnumerable<string> FilesFromCachedPaths()
        {
            foreach (var cachedPath in CachedPaths)
            {
                var fileNames = GetResolvedProviderPathFromPSPath(cachedPath, out ProviderInfo provider);

                if (provider.ImplementingType == typeof(FileSystemProvider))
                {
                    foreach (var fileName in fileNames)
                    {
                        yield return fileName;
                    }
                }
            }
        }

        protected override void BeginProcessing()
        {
            CachedPaths.Clear();
        }

        protected override void ProcessRecord()
        {
            foreach (var fileName in Path)
            {
                CachedPaths.Add(fileName);
            }
        }

        protected override void EndProcessing()
        {
            switch (ParameterSetName)
            {
                case "FromPath":
                    WriteObject(ApplicationBuilder.ReadFromFiles(FilesFromCachedPaths()));
                    break;

                case "FromDatabase":
                    WriteObject(ApplicationExporter.Export(DevClientPath ?? DefaultDevClientPath, ServerName, Database, Filter));
                    break;
            }
        }
    }
}