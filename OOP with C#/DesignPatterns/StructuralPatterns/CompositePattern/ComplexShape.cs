using System;
using System.Collections.Generic;

namespace CompositePattern
{
    public class ComplexShape : IDrawable
    {
        private List<IDrawable> shapes = new List<IDrawable>();
        public string Name { get; set; }

        public ComplexShape(string name)
        {
            this.Name = name;
        }
        public void Draw(int level)
        {
            Console.Write(new string(' ', level));
            Console.WriteLine(Name);
            foreach (var shape in shapes)
            {
                shape.Draw(level + 3);
            }
        }

        public void AddChild(IDrawable child)
        {
            shapes.Add(child);
        }
    }
}
