using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePatternDemo
{
    class Composite : IComponent
    {
        private List<IComponent> children = new List<IComponent>();

        public void Add(IComponent component)
        {
            children.Add(component);
        }

        public void Operation()
        {
            foreach (var component in children)
            {
                component.Operation();
            }
        }
    }
}
