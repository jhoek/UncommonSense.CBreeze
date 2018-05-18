using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Page;
using UncommonSense.CBreeze.Core.Page.Action;
using UncommonSense.CBreeze.Core.Page.Control;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Script
{
    public static partial class ToInvocationMethod
    {
        public static Invocation ToInvocation(this Page page)
        {
            IEnumerable<ParameterBase> signature = new[] {
                new SimpleParameter("ID", page.ID),
                new SimpleParameter("Name", page.Name)
            };

            IEnumerable<ParameterBase> objectProperties = page
                .ObjectProperties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> properties = page
                .Properties
                .Where(p => p.HasValue)
                .Where(p => p.GetType() != typeof(ActionListProperty))
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> subObjects = new[] {
                new ScriptBlockParameter(
                    "SubObjects",
                    page.Properties.ActionList.ToInvocations()
                        .Concat(page.Properties.SourceTableView.TableFilter.ToInvocations())
                        .Concat(page.Controls.ToInvocations().Cast<Statement>())
                        .Concat(page.Code.Variables.ToInvocations().Cast<Statement>())
                        .Concat(page.Code.Functions.ToInvocations().Cast<Statement>())
                        .Concat(page.Code.Events.ToInvocations().Cast<Statement>())
                        .Concat(page.Code.Documentation.CodeLines.ToInvocation().Cast<Statement>())
                )
            };

            return new Invocation(
                "New-CBreezePage",
                signature
                    .Concat(objectProperties)
                    .Concat(properties)
                    .Concat(subObjects)
            );
        }

        public static IEnumerable<Invocation> ToInvocations(this PageControls pageControls) => pageControls.Where(c => c.IndentationLevel.GetValueOrDefault(0) == 0).Select(c => c.ToInvocation());

        public static Invocation ToInvocation(this PageControlBase pageControl)
        {
            switch (pageControl)
            {
                case PageControlContainer c:
                    return new Invocation("New-CBreezePageControlContainer", c.ToParameters());

                case PageControlGroup g:
                    return new Invocation("New-CBreezePageControlGroup", g.ToParameters());

                case PageControlPart p:
                    return new Invocation("New-CBreezePageControlPart", p.ToParameters());

                case PageControl f:
                    return new Invocation("New-CBreezePageControl", f.ToParameters());

                default:
                    throw new ArgumentOutOfRangeException("pageControl");
            }
        }

        public static IEnumerable<Invocation> ToInvocations(this ActionList actionList) => actionList.Where(a => a.IndentationLevel.GetValueOrDefault(0) == 0).Select(a => a.ToInvocation());

        public static Invocation ToInvocation(this PageActionBase pageActionBase)
        {
            switch (pageActionBase)
            {
                case PageActionContainer c:
                    return new Invocation("New-CBreezePageActionContainer", c.ToParameters());

                case PageActionGroup g:
                    return new Invocation("New-CBreezePageActionGroup", g.ToParameters());

                case PageAction a:
                    return new Invocation("New-CBreezePageAction", a.ToParameters());

                case PageActionSeparator s:
                    return new Invocation("New-CBreezePageActionSeparator", s.ToParameters());

                default:
                    return null;
            }
        }
    }
}
