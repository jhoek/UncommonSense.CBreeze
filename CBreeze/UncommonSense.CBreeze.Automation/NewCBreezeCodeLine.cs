﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeCodeLine", DefaultParameterSetName = "NewWithoutID")]
    [Alias("CodeLine", "Add-CBreezeCodeLine")]
    [OutputType(typeof(string))]
    public class NewCBreezeCodeLine : NewItemCmdlet<string, PSObject>
    {
        protected override void AddItemToInputObject(string item, PSObject inputObject)
        {
            (InputObject.BaseObject as IHasCodeLines).CodeLines.Add(item);
        }

        protected override IEnumerable<string> CreateItems()
        {
            yield return ArgumentList == null ?
                (Line ?? string.Empty) :
                string.Format((Line ?? string.Empty), ArgumentList);
        }

        [Parameter(Position = 1)]
        public object[] ArgumentList
        {
            get;
            set;
        }

        [Parameter(Position = 0)]
        public string Line
        {
            get;
            set;
        }
    }
}