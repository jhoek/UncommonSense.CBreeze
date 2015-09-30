using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    public static class DynamicParameterMgt
    {
        public static RuntimeDefinedParameter IntegerSubType()
        {
            var attributes = new Collection<Attribute>() { MandatoryParameter(), ValidateIDRange() };
            return new RuntimeDefinedParameter("SubType", typeof(int), attributes);
        }

        public static RuntimeDefinedParameter RecordSecurityFiltering()
        {
            var attributes = new Collection<Attribute>() { OptionalParameter() };
            return new RuntimeDefinedParameter("SecurityFiltering", typeof(RecordSecurityFiltering?), attributes);
        }

        public static RuntimeDefinedParameter StringSubType()
        {
            var attributes = new Collection<Attribute>() { MandatoryParameter() };
            return new RuntimeDefinedParameter("SubType", typeof(string), attributes);
        }

        public static RuntimeDefinedParameter Temporary()
        {
            var attributes = new Collection<Attribute>() { OptionalParameter() };
            return new RuntimeDefinedParameter("Temporary", typeof(bool?), attributes);
        }

        public static RuntimeDefinedParameter WithEvents()
        {
            var attributes = new Collection<Attribute>() { OptionalParameter() };
            return new RuntimeDefinedParameter("WithEvents", typeof(bool?), attributes);
        }

        public static ParameterAttribute OptionalParameter()
        {
            var parameterAttribute = new ParameterAttribute();
            return parameterAttribute;
        }

        public static ParameterAttribute MandatoryParameter()
        {
            var parameterAttribute = new ParameterAttribute();
            parameterAttribute.Mandatory = true;
            return parameterAttribute;
        }

        public static ValidateRangeAttribute ValidateIDRange()
        {
            var validateRangeAttribute = new ValidateRangeAttribute(1, int.MaxValue);
            return validateRangeAttribute;
        }
    }
}
