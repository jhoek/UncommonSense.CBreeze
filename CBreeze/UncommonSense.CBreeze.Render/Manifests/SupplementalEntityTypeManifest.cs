using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Render
{
    public class SupplementalEntityTypeManifest : RenderingManifest
    {
        internal SupplementalEntityTypeManifest()
        {
        }

        public Table Table
        {
            get;
            internal set;
        }

        public CodeTableField CodeField
        {
            get;
            internal set;
        }

        public TextTableField DescriptionField
        {
            get;
            internal set;
        }

        public Page Page
        {
            get;
            internal set;
        }

        public ContainerPageControl ContentAreaControl
        {
            get;
            internal set;
        }

        public GroupPageControl RepeaterControl
        {
            get;
            internal set;
        }

        public FieldPageControl CodeControl
        {
            get;
            internal set;
        }

        public FieldPageControl DescriptionControl
        {
            get;
            internal set;
        }

        public ContainerPageControl FactBoxAreaControl
        {
            get;
            internal set;
        }

        public PartPageControl RecordLinksControl
        {
            get;
            internal set;
        }

        public PartPageControl NotesControl
        {
            get;
            internal set;
        }
    }
}
