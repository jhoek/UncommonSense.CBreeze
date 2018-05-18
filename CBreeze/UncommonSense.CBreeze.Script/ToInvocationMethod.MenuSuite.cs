using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.MenuSuite;

namespace UncommonSense.CBreeze.Script
{
    public static partial class ToInvocationMethod
    {
        public static Invocation ToInvocation(this MenuSuite menuSuite)
        {
            IEnumerable<ParameterBase> signature = new[] {
                new SimpleParameter("ID", menuSuite.ID),
                new SimpleParameter("Name", menuSuite.Name)
            };

            IEnumerable<ParameterBase> objectProperties = menuSuite
                .ObjectProperties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> properties = menuSuite
                .Properties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> subObjects = new[] {
                new ScriptBlockParameter(
                    "SubObjects",
                    menuSuite.Nodes.ToInvocations().Cast<Statement>()
                )
            };

            return new Invocation(
                "New-CBreezeMenuSuite",
                signature
                    .Concat(objectProperties)
                    .Concat(properties)
                    .Concat(subObjects)
            );
        }

        public static IEnumerable<Invocation> ToInvocations(this MenuSuiteNodes menuSuiteNodes) => menuSuiteNodes.Select(n => n.ToInvocation());

        public static Invocation ToInvocation(this MenuSuiteNode menuSuiteNode)
        {
            switch (menuSuiteNode)
            {
                case RootNode rootNode: return rootNode.ToInvocation();
                case DeltaNode deltaNode: return deltaNode.ToInvocation();
                case MenuNode menuNode: return menuNode.ToInvocation();
                case ItemNode itemNode: return itemNode.ToInvocation();
                case GroupNode groupNode: return groupNode.ToInvocation();
                default: throw new ArgumentOutOfRangeException("menuSuiteNode");
            }
        }

        public static Invocation ToInvocation(this RootNode rootNode) => new Invocation("New-CBreezeRootMenuSuiteNode", rootNode.ToParameters());

        public static Invocation ToInvocation(this DeltaNode deltaNode) => new Invocation("New-CBreezeDeltaMenuSuiteNode", deltaNode.ToParameters());

        public static Invocation ToInvocation(this MenuNode menuNode) => new Invocation("New-CBreezeMenuMenuSuiteNode", menuNode.ToParameters());

        public static Invocation ToInvocation(this ItemNode itemNode) => new Invocation("New-CBreezeItemMenuSuiteNode", itemNode.ToParameters());

        public static Invocation ToInvocation(this GroupNode groupNode) => new Invocation("New-CBreezeGroupMenuSuiteNode", groupNode.ToParameters());
    }
}
