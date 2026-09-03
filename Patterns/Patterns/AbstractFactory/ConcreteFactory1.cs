using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return (AbstractProductB)Activator.CreateInstance(typeof(ProductB1));
        }
  
        public static Type[] productTypes = new Type[]{typeof(ProductA1),};
    }
}
