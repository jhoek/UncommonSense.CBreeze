using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Codeunit;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.MenuSuite;
using UncommonSense.CBreeze.Core.Page;
using UncommonSense.CBreeze.Core.Query;
using UncommonSense.CBreeze.Core.Report;
using UncommonSense.CBreeze.Core.Table;
using UncommonSense.CBreeze.Core.XmlPort;
using Object = UncommonSense.CBreeze.Core.Code.Variable.Object;

namespace UncommonSense.CBreeze.Core.Base
{
    public class Application : INode
    {
        public Application(params Object[] objects)
        {
            Tables = new Tables(this, objects.OfType<Table.Table>());
            Pages = new Pages(this, objects.OfType<Page.Page>());
            Reports = new Reports(this, objects.OfType<Report.Report>());
            XmlPorts = new XmlPorts(this, objects.OfType<XmlPort.XmlPort>());
            Codeunits = new Codeunits(this, objects.OfType<Codeunit.Codeunit>());
            Queries = new Queries(this, objects.OfType<Query.Query>());
            MenuSuites = new MenuSuites(this, objects.OfType<MenuSuite.MenuSuite>());
        }

        IEnumerable<INode> INode.ChildNodes
        {
            get
            {
                yield return Tables;
                yield return Pages;
                yield return Reports;
                yield return XmlPorts;
                yield return Codeunits;
                yield return Queries;
                yield return MenuSuites;
            }
        }

        public Codeunits Codeunits
        {
            get;
            protected set;
        }

        public MenuSuites MenuSuites
        {
            get;
            protected set;
        }

        public IEnumerable<Object> Objects
        {
            get
            {
                return
                    Tables
                    .AsEnumerable<Object>()
                    .Concat(Pages.AsEnumerable<Object>())
                    .Concat(Reports.AsEnumerable<Object>())
                    .Concat(XmlPorts.AsEnumerable<Object>())
                    .Concat(Codeunits.AsEnumerable<Object>())
                    .Concat(Queries.AsEnumerable<Object>())
                    .Concat(MenuSuites.AsEnumerable<Object>());
            }
        }

        public Pages Pages
        {
            get;
            protected set;
        }

        public INode ParentNode => null;

        public Queries Queries
        {
            get;
            protected set;
        }

        public Reports Reports
        {
            get;
            protected set;
        }

        public Tables Tables
        {
            get;
            protected set;
        }

        public XmlPorts XmlPorts
        {
            get;
            protected set;
        }

        public void Clear()
        {
            Tables.Clear();
            Pages.Clear();
            Reports.Clear();
            XmlPorts.Clear();
            Codeunits.Clear();
            Queries.Clear();
            MenuSuites.Clear();
        }
    }
}