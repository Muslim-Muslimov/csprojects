using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Lion : Animal
    {
        internal void Roar()
        {
            Console.WriteLine("1ааакъ");
        }
        internal override void Move()
        {
            Console.WriteLine($"Lion {Name} moved");
        }

        internal override void MakeSound()
        {
            Console.WriteLine("LionSound");
        }

        internal Lion(string name) : base(name) { }


    }
}
