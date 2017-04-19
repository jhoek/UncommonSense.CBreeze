using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class ReportRequestPage : IPage, INode
    {
        internal ReportRequestPage(Report report)
        {
            Report = report;

            Properties = new ReportRequestPageProperties(this);
            Properties.ActionList.Page = this;

            Controls = new PageControls(this);
        }

        public ActionList Actions
        {
            get
            {
                return Properties.ActionList;
            }
        }

        public Application Application => Report.Container.Application;

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Controls;
            }
        }

        public PageControls Controls
        {
            get;
            protected set;
        }

        public int ObjectID
        {
            get
            {
                return Report.ID;
            }
        }

        public INode ParentNode => Report;

        public ReportRequestPageProperties Properties
        {
            get;
            protected set;
        }

        public Report Report
        {
            get;
            protected set;
        }
    }
}