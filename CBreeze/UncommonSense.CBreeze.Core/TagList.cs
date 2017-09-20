using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UncommonSense.CBreeze.Core
{
    public class TagList : Collection<string>
    {
        public TagList() 
        {
        }

        public TagList(params string[] tags) 
        {
            AddRange(tags);
        }

        protected override void InsertItem(int index, string item)
        {
            TestTag(item);
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, string item)
        {
            TestTag(item);
            base.SetItem(index, item);
        }

        public override string ToString() => string.Join(",", this);

        protected void TestTag(string tag)
        {
            if (!IsValidTag(tag))
                throw new ArgumentOutOfRangeException("tag", $"Invalid tag '{tag}'. Valid tags match pattern '{ValidTagPattern}'.");
        }

        public bool IsValidTag(string tag) => Regex.IsMatch(tag, ValidTagPattern);
        public string ValidTagPattern => @"^#[A-Za-z0-9]+$";
    }
}
