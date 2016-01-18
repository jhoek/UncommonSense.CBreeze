using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UncommonSense.CBreeze.Core
{
        public class ControlList : Collection<string>
    {
        // Ctor made public to allow ControlListProperty to new up an instance
        public ControlList()
        {
        }

        public void AddRange(params string[] controlNames)
        {
            foreach(var item in controlNames)
            {
               Add(item);
             }
        }
    }
}
