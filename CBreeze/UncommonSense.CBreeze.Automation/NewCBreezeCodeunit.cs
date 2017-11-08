using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeCodeunit", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(Codeunit))]
    [Alias("Codeunit")]
    public class NewCBreezeCodeunit : NewCBreezeObject<Codeunit>
    {
#if !NAV2016
        [Parameter()] public SwitchParameter CFrontMayUsePermissions { get; set; } 
#endif

#if NAV2016
        [Parameter()] public EventSubscriberInstance? EventSubscriberInstance { get; set; }
#endif

        [Parameter()] public ScriptBlock OnRun { get; set; }
        [Parameter()] public Permission[] Permissions { get; set; }
        [Parameter()] public SwitchParameter SingleInstance { get; set; }
        [Parameter()] public CodeunitSubType? SubType { get; set; }
        [Parameter()] [ValidateRange(1, int.MaxValue)] public int? TableNo { get; set; }
        [Parameter()] public TestIsolation? TestIsolation { get; set; }

        protected override void AddItemToInputObject(Codeunit item, Application inputObject)
        {
            inputObject.Codeunits.Add(item);
        }

        protected override IEnumerable<Codeunit> CreateItems()
        {
            var codeunit = new Codeunit(ID, Name);
            SetObjectProperties(codeunit);

#if !NAV2016
            codeunit.Properties.CFRONTMayUsePermissions = InterpretSwitch(nameof(CFrontMayUsePermissions));
#endif
#if NAV2016
            codeunit.Properties.EventSubscriberInstance = EventSubscriberInstance;
#endif
            codeunit.Properties.Permissions.Set(Permissions);
            codeunit.Properties.SingleInstance = InterpretSwitch(nameof(SingleInstance));
            codeunit.Properties.Subtype = SubType;
            codeunit.Properties.TableNo = TableNo;
            codeunit.Properties.TestIsolation = TestIsolation;

            if (OnRun != null)
            {
                var subObjects = OnRun.Invoke().Select(o => o.BaseObject);
                codeunit.Properties.OnRun.CodeLines.AddRange(subObjects.OfType<string>());
                codeunit.Properties.OnRun.Variables.AddRange(subObjects.OfType<Variable>());
            }

            if (SubObjects != null)
            {
                var subObjects = SubObjects.Invoke().Select(o => o.BaseObject);
                codeunit.Code.Documentation.CodeLines.AddRange(subObjects.OfType<string>());
                codeunit.Code.Functions.AddRange(subObjects.OfType<Function>());
                codeunit.Code.Variables.AddRange(subObjects.OfType<Variable>());
                codeunit.Code.Events.AddRange(subObjects.OfType<Event>());
            }

            yield return codeunit;
        }
    }
}