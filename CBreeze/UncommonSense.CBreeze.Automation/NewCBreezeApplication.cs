using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Base;
using Object = UncommonSense.CBreeze.Core.Code.Variable.Object;

namespace UncommonSense.CBreeze.Automation
{
    /// <summary>
    /// <para type="description">Creates a new C/Breeze application object.</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CBreezeApplication")]
    [OutputType(typeof(Application))]
    [Alias("Application")]
    public class NewCBreezeApplication : Cmdlet
    {
        protected override void EndProcessing()
        {
            var application = new Application();

            if (Objects != null)
            {
                application.Add(Objects.Invoke().Select(o => o.BaseObject).Cast<Object>());
            }

            WriteObject(application);
        }

        [Parameter(Position = 0)]
        public ScriptBlock Objects
        {
            get;
            set;
        }
    }
}