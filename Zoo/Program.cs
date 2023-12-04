﻿namespace Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lionSymba = new Lion("Symba");
            var lionGeorge = new Lion("George");
            var lionShram = new Lion("Shram");
            var elephantSveta = new Elephant("Sveta");

            var lion3 = new Lion();
            lion3.Move();
        }

        private static void MoveAnimal(Animal animal)
        {
            animal.Move();

            if (typeof(Lion) == animal.GetType())
            {
                Lion lion = (Lion)animal;
                lion.Roar();
            }
        }
    }
}
