using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class RecordRefParameter : Parameter
    {
        public RecordRefParameter(string name, bool var = false, int id = 0) : base(name, var, id)
        {
        }

        public RecordSecurityFiltering? SecurityFiltering
        {
            get;
            set;
        }

        public override ParameterType Type => ParameterType.RecordRef;

        public override string TypeName
        {
            get
            {
                var securityFiltering = SecurityFiltering.HasValue ? $" SECURITYFILTERING({SecurityFiltering.Value})" : "";
                return $"RecordRef{securityFiltering}";
            }
        }
    }
}