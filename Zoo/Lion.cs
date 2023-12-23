using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Lion : Animal
    {
        public void Roar()
        {
            Console.WriteLine("1ааакъ");
        }
        public override void Move()
        {
            Console.WriteLine($"Lion {Name} moved");
        }

        public override void MakeSound()
        {
            Console.WriteLine("LionSound");
        }

        public Lion(string name) : base(name) { }

        public Lion()
        {
        }
    }
}
