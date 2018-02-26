using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Meta
{
    public static class ExtensionMethods
    {
        public static string PluralizeENU(this string text)
        {
            switch (text)
            {
                case string t when t.EndsWith("s"):
                    return $"{t}es";

                // FIXME: More exceptional cases

                default:
                    return $"{text}s";
            }
        }

        public static Collection<T> ToEnumerable<T>(this ScriptBlock scriptBlock)
        {
            if (scriptBlock == null)
                return null;

            return new Collection<T>(scriptBlock.Invoke(null).Select(o => o.BaseObject).Cast<T>().ToList());
        }
    }
}
