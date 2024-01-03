namespace Zoo
{
    internal abstract class Animal
    {
        #region Properties, Fields and Constructors
        internal string Name { get; private set; }
        internal decimal Age { get; set; } = 0;
        internal abstract void Move();
        internal Animal(string name)
        {
            Name = name;
        }
        #endregion
        internal void Eat()
        {
            Console.WriteLine("Ням-ням");
        }
        internal void Sleep()
        {
            Console.WriteLine("Спатья");
        }
        internal virtual void MakeSound()
        {
            Console.WriteLine("Гав бав");
        }
    }
}
