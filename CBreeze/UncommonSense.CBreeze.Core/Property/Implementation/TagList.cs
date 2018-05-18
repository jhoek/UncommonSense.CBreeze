using System;
using System.Text.RegularExpressions;
using UncommonSense.CBreeze.Core.Generic;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
#if NAV2017
    public class TagList : Collection<string>
    {
        public TagList()
        {
        }

        public TagList(params string[] tags)
        {
            AddRange(tags);
        }

        public void Set(string[] values)
        {
            Clear();

            if (values != null)
                AddRange(values);
        }

        public string ValidTagPattern => @"^#[A-Za-z0-9]+$";

        public bool IsValidTag(string tag) => Regex.IsMatch(tag, ValidTagPattern);

        public override string ToString() => string.Join(",", this);

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
#endif
}