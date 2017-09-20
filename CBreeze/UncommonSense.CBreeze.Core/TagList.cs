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

        public string ValidTagPattern => @"^#[A-Za-z0-9]+$";

        public bool IsValidTag(string tag) => Regex.IsMatch(tag, ValidTagPattern);

        public override string ToString() => string.Join(", ", this);

        protected override void InsertItem(int index, string item)
        {
            item = item.Trim();
            TestTag(item);
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, string item)
        {
            item = item.Trim();
            TestTag(item);
            base.SetItem(index, item);
        }

        protected void TestTag(string tag)
        {
            if (!IsValidTag(tag))
                throw new ArgumentOutOfRangeException("tag", $"Invalid tag '{tag}'. Valid tags match pattern '{ValidTagPattern}'.");
        }
    }
}