using System;

namespace CompositePattern
{
    public class SimpleShape : IDrawable
    {
        public string Name { get; set; }

        public SimpleShape(string name)
        {
            this.Name = name;
        }
        public void AddChild(IDrawable child)
        {
            throw new ArgumentException("Simple shapes don't have children.");
        }

        public void Draw(int level)
        {
            Console.Write(new string(' ', level));
            Console.WriteLine(Name);
        }
    }
}
