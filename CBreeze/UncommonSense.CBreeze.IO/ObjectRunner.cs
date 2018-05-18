using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Codeunit;
using UncommonSense.CBreeze.Core.Page;
using UncommonSense.CBreeze.Core.Query;
using UncommonSense.CBreeze.Core.Report;
using UncommonSense.CBreeze.Core.Table;
using UncommonSense.CBreeze.Core.XmlPort;

namespace UncommonSense.CBreeze.IO
{
    public static class ObjectRunner
    {
        public static void Run(this Page page, string roleTailoredClient, string serverName, int? serverPort, string serverInstance, string companyName, PageMode? mode, bool hideNavigationPage = false, bool fullScreen=false)
        {
            var commands = new StringBuilder();
            commands.AppendFormat("runpage?page={0}", page.ID);
            commands.AppendFormatIf(mode.HasValue, "&mode={0}", mode.Value);

            RoleTailoredClient.Run(roleTailoredClient, BuildHyperlink(serverName, serverPort, serverInstance, companyName, commands.ToString()), hideNavigationPage, fullScreen);
        }

        public static void Run(this Report report, string roleTailoredClient, string serverName, int? serverPort, string serverInstance, string companyName)
        {
            var commands = new StringBuilder();
            commands.AppendFormat("runreport?report={0}", report.ID);

            RoleTailoredClient.Run(roleTailoredClient, BuildHyperlink(serverName, serverPort, serverInstance, companyName, commands.ToString()));
        }

        public static void Run(this Query query, string roleTailoredClient, string serverName, int? serverPort, string serverInstance, string companyName)
        {
            var commands = new StringBuilder();
            commands.AppendFormat("runquery?query={0}", query.ID);

            RoleTailoredClient.Run(roleTailoredClient, BuildHyperlink(serverName, serverPort, serverInstance, companyName, commands.ToString()));
        }

        public static void Run(this XmlPort xmlPort, string roleTailoredClient, string serverName, int? serverPort, string serverInstance, string companyName)
        {
            var commands = new StringBuilder();
            commands.AppendFormat("runxmlport?xmlport={0}", xmlPort.ID);

            RoleTailoredClient.Run(roleTailoredClient, BuildHyperlink(serverName, serverPort, serverInstance, companyName, commands.ToString()));
        }

        public static void Run(this Codeunit codeunit, string roleTailoredClient, string serverName, int? serverPort, string serverInstance, string companyName)
        {
            var commands = new StringBuilder();
            commands.AppendFormat("runcodeunit?codeunit={0}", codeunit.ID);

            RoleTailoredClient.Run(roleTailoredClient, BuildHyperlink(serverName, serverPort, serverInstance, companyName, commands.ToString()));
        }

        public static void Run(this Table table, string roleTailoredClient, string serverName, int? serverPort, string serverInstance, string companyName)
        {
            var commands = new StringBuilder();
            commands.AppendFormat("runtable?table={0}", table.ID);

            RoleTailoredClient.Run(roleTailoredClient, BuildHyperlink(serverName, serverPort, serverInstance, companyName, commands.ToString()));
        }

        public static string BuildHyperlink(string serverName, int? serverPort, string serverInstance, string companyName, string commands)
        {
            return string.Format("DynamicsNAV://{0}{1}/{2}/{3}/{4}", serverName, serverPort.HasValue ? string.Format(":{0}", serverPort.Value) : null, serverInstance, companyName, commands);
        }
    }
}
