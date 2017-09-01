using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Set, "CBreezeDefaultRanges", DefaultParameterSetName = "ID")]
    [Alias("DefaultRange")]
    public class SetCBreezeDefaultRanges : Cmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = "ID")]
        [Parameter(Mandatory = true, ParameterSetName = "Both")]
        public PSObject ID { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "UID")]
        [Parameter(Mandatory = true, ParameterSetName = "Both")]
        public PSObject UID { get; set; }

        protected IEnumerable<int> Convert(object @object)
        {
            var range = new Regex(@"^(\d+)\.\.(\d+)$", RegexOptions.Compiled);

            switch (@object)
            {
                case null:
                    return null;

                case IEnumerable<int> enumerable:
                    return enumerable;

                case string @string when range.IsMatch(@string):
                    var match = range.Match(@string);
                    var from = int.Parse(match.Groups[1].Value);
                    var to = int.Parse(match.Groups[2].Value);
                    return from.To(to);

                case int integer:
                    return integer.To(integer);

                case object[] objects:
                    return objects.Cast<int>();

                default:
                    throw new ArgumentOutOfRangeException($"Don't know how to convert {@object} to a range of integers.");
            }
        }

        protected override void EndProcessing()
        {
            DefaultRanges.ID = Convert(ID?.BaseObject) ?? DefaultRanges.ID;
            DefaultRanges.UID = Convert(UID?.BaseObject) ?? DefaultRanges.UID;
        }
    }
}