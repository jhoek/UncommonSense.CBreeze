using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezePage")]
    public class AddCBreezePage : AddCBreezeObject
    {
        [Parameter()]
        public bool? AutoSplitKey
        {
            get;
            set;
        }

        [Parameter()]
        public string CardPageID
        {
            get;
            set;
        }

        [Parameter()]
        public string DataCaptionExpr
        {
            get;
            set;
        }

        [Parameter()]
        public string[] DataCaptionFields
        {
            get;
            set;
        }

        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                var page = Application.Pages.Add(ID, Name);

                page.ObjectProperties.DateTime = DateTime;
                page.ObjectProperties.Modified = Modified;
                page.ObjectProperties.VersionList = VersionList;

                page.Properties.AutoSplitKey = AutoSplitKey;
                page.Properties.CardPageID = CardPageID;
                page.Properties.DataCaptionExpr = DataCaptionExpr;
                page.Properties.DataCaptionFields.AddRange(DataCaptionFields);

                page.AutoCaptionIf(AutoCaption);

                yield return page;
            }
        }
    }
}
