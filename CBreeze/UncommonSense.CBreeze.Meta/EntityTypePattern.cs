using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Patterns;

namespace UncommonSense.CBreeze.Meta    
{
    public abstract class EntityTypePattern : Pattern
    {
        public EntityTypePattern(Application application, IEnumerable<int> range)
        {
            Application = application;
            Range = range;
        }

        protected override void VerifyRequirements()
        {
            if (Application == null)
                throw new ArgumentNullException("Application");

            if (Range == null)
                throw new ArgumentNullException("Range");
        }

        public Application Application
        {
            get;
            set;
        }

        public IEnumerable<int> Range
        {
            get;
            set;
        }
    }
}
