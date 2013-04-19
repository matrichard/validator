using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestValidation
{
    using System.Linq.Expressions;

    public class Entity
    {
        public string StringProperty { get; set; }
        public int IntProperty { get; set; }
        public object ObjectProperty { get; set; }

        public double DoubleProperty { get; set; }

        public Entity2 Entity2 { get; set; }
    }

    public class Entity2
    {
        public string StringProperty2 { get; set; }
        public int IntProperty2 { get; set; }
        public object ObjectProperty2 { get; set; }

        public double DoubleProperty2 { get; set; }
    }
}
