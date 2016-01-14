using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class CodeLines : Collection<string>
    {
        internal CodeLines()
        {
        }

        public new  void Add(string text)
        {
            base.Add(text);
        }

        public void Add(string format, params object[] args)
        {
            base.Add(string.Format(format, args));
        }

        public void Insert(int index, string format, params object[] args)
        {
            Insert(index, string.Format(format, args));
        }
    }
}
