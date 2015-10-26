using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Meta
{
    public abstract class EntityTypePattern
    {
        // FIXME: Consider making these classes partial, and creating separate
        // .cs files for interface and implementation. Perhaps even for "input"
        // properties and "output" properties?

        public EntityTypePattern(Application application, IEnumerable<int> range, string name)
        {
            Application = application;
            Range = range;
            Name = name;
        }

        protected  void VerifyRequirements()
        {
            if (Application == null)
                throw new ArgumentNullException("Application");

            if (Range == null)
                throw new ArgumentNullException("Range");

            if (string.IsNullOrEmpty(Name))
                throw new ArgumentNullException("Name");
        }

        // FIXME: Override in as few patterns as possible. Try and make
        // all patterns follow the same basic process
        protected  void MakeChanges()
        {
            CreateObjects();
            AfterCreateObjects();

            CreateFields();
            AfterCreateFields();

            CreateKeys();
            CreateGlobals();
            CreateFunctions();
            CreateDropDownFieldGroup();
            CreateControls();
            CreateActions();
        }

        protected virtual void CreateObjects()
        {
        }

        protected virtual void AfterCreateObjects()
        {
        }

        protected virtual void CreateFields()
        {
        }

        protected virtual void AfterCreateFields()
        {
        }

        protected virtual void CreateKeys()
        {
        }

        protected virtual void CreateGlobals()
        {
        }

        protected virtual void CreateFunctions()
        {
        }

        protected virtual void CreateDropDownFieldGroup()
        {
        }

        protected virtual void CreateControls()
        {
        }

        protected virtual void CreateActions()
        {
        }

        protected virtual FieldPageControl CreateCardPageControl(Page page, string groupCaption, Position groupPosition, Position controlPosition, string sourceExpr)
        {
            var contentArea = page.GetPageControlContainer(Range, ContainerType.ContentArea);
            var group = contentArea.GetGroupByCaption(groupCaption, Range, groupPosition);
            return group.AddFieldPageControl(Range.GetNextPageControlID(page), controlPosition, sourceExpr);
        }

        protected virtual FieldPageControl CreateListPageControl(Page page, Position controlPosition, string sourceExpr)
        {
            var contentArea = page.GetPageControlContainer(Range, ContainerType.ContentArea);
            var repeater = contentArea.GetGroupByType(GroupType.Repeater, Range, Position.FirstWithinContainer);
            return repeater.AddFieldPageControl(Range.GetNextPageControlID(page), controlPosition, sourceExpr);
        }

        public Application Application
        {
            get;
            protected set;
        }

        public IEnumerable<int> Range
        {
            get;
            protected set;
        }

        public string Name
        {
            get;
            protected set;
        }
    }
}
