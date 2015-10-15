using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.IO;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsLifecycle.Invoke, "CBreezeObject")]
    public class InvokeCBreezeObject : Cmdlet
    {
        public InvokeCBreezeObject()
        {
            RoleTailoredClientPath = @"C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\Microsoft.Dynamics.Nav.Client.exe";
            ServerName = "localhost";
            ServerPort = 7046;
            ServerInstance = "DynamicsNAV70";
            CompanyName = "CRONUS International Ltd.";
        }

        [Parameter(Mandatory = true)]
        public UncommonSense.CBreeze.Core.Object Object
        {
            get;
            set;
        }

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        public string RoleTailoredClientPath
        {
            get;
            set;
        }

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        public string ServerName
        {
            get;
            set;
        }

        [Parameter()]
        [ValidateRange(1, int.MaxValue)]
        public int ServerPort
        {
            get;
            set;
        }

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        public string ServerInstance
        {
            get;
            set;
        }

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        public string CompanyName
        {
            get;
            set;
        }

        [Parameter()]
        public PageMode PageMode
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter HideNavigationPane
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter FullScreen
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            switch (Object.Type)
            {
                case ObjectType.Table:
                    ObjectRunner.Run(Object as Table, RoleTailoredClientPath, ServerName, ServerPort, ServerInstance, CompanyName);
                    break;

                case ObjectType.Page:
                    ObjectRunner.Run(Object as Page, RoleTailoredClientPath, ServerName, ServerPort, ServerInstance, CompanyName, PageMode, HideNavigationPane, FullScreen);
                    break;

                case ObjectType.Report:
                    ObjectRunner.Run(Object as Report, RoleTailoredClientPath, ServerName, ServerPort, ServerInstance, CompanyName);
                    break;

                case ObjectType.Codeunit:
                    ObjectRunner.Run(Object as Codeunit, RoleTailoredClientPath, ServerName, ServerPort, ServerInstance, CompanyName);
                    break;

                case ObjectType.XmlPort:
                    ObjectRunner.Run(Object as XmlPort, RoleTailoredClientPath, ServerName, ServerPort, ServerInstance, CompanyName);
                    break;

                case ObjectType.Query:
                    ObjectRunner.Run(Object as Query, RoleTailoredClientPath, ServerName, ServerPort, ServerInstance, CompanyName);
                    break;

                default:
                    throw new ApplicationException(string.Format("Don't know how to invoke an object of type {0}.", Object.Type));
            }

        }
    }
}
