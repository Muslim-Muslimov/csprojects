using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Elephant : Animal
    {
        internal Elephant(string name) : base(name) {}

        internal override void Move()
        {
            Console.WriteLine("Elephant moves");
        }
    }
}
