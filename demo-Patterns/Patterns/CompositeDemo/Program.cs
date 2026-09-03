using System;
using System.Collections.Generic;
using System.Text;

namespace CompositeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new Composite("Programm Files");
            var file1 = new Leaf("user.txt");
            var file2 = new Leaf("gf.gif");
            var file3 = new Leaf("file1.txt");
            var file4 = new Leaf("file2.txt");
            var file5 = new Leaf("file3.txt");
            var file6 = new Leaf("MyProg.exe");
            var dir1 = new Composite("MyProg");
            root.Add(dir1);
            root.Add(file1);
            root.Add(file2);
            dir1.Add(file3);
            dir1.Add(file4);
            dir1.Add(file5);
            dir1.Add(file6);
            root.Display();
  
            Console.WriteLine("Hello World!");
        }
    }


    public abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }
        public abstract void Display(int level=0);
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
    }


    public class Composite : Component
    {
        List<Component> children = new List<Component>();

        public Composite(string name):base(name)
        {

        }

        public override void Add(Component component)=>children.Add(component);
 
        public override void Display(int level=0)
        {
            var s = new StringBuilder();
            s.Append(' ', level * 4);
            s.Append(name);

            Console.WriteLine(s);
            foreach (Component component in children) 
            {
                component.Display(level+1);
            }
            
        }

        public override void Remove(Component component)=>children.Remove(component);
 
    }

    public class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {

        }
        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Display(int level=0)
        {
            var s = new StringBuilder();
            s.Append(' ', level * 4);
            s.Append(name);
            Console.WriteLine(s.ToString());
        }

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }
    }

}
