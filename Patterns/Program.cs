using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Patterns patterns = new Patterns();
            patterns.StateExample();
        }
    }
    class Patterns
    {
        public void StateExample()
        {
            StateExample stateExample = new StateExample();
        }
    }
}
