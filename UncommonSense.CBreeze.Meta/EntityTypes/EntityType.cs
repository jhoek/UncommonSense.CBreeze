using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Meta.PageDefinitions;
using ObjectModel = System.Collections.ObjectModel;

namespace UncommonSense.CBreeze.Meta.EntityTypes
{
    public abstract class EntityType
    {
        private string pluralName;

        public EntityType(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public string PluralName
        {
            get => this.pluralName ?? Name.PluralizeENU();
            set => this.pluralName = value;
        }

        public abstract IEnumerable<Core.Object> Render();
        public IEnumerable<PageDefinition> Pages => CustomPages ?? DefaultPages;
        public ObjectModel.Collection<PageDefinition> CustomPages { get; set; }
        public abstract IEnumerable<PageDefinition> DefaultPages { get; }
    }
}
