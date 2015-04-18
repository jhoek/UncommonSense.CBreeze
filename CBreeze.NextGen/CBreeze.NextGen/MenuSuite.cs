using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class MenuSuite : Object, IEquatable<MenuSuite>
    {
        public MenuSuite(int id, string name)
            : base(id, name)
        {

        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.MenuSuite;
            }
        }
    }
}
