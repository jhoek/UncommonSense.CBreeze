using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Meta
{
    public partial class DocumentEntityTypePattern : EntityTypePattern
    {
        public DocumentEntityTypePattern(Application application, IEnumerable<int> range, string name)
            : base(application, range, name)
        {
        }

        protected override void CreateObjects()
        {
            HeaderTable = Application.Tables.Add(new Table(Range.GetNextTableID(Application), HeaderName).AutoCaption());
            LineTable = Application.Tables.Add(new Table(Range.GetNextTableID(Application), LineName).AutoCaption());

            
        }


    }
}
