using System;

namespace adam144.GangOfFour.Composite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var c = new CompositeElement("CompositeElement");
            ForCompositeOnly(c);
            //var p = new PrimitiveElement("PrimitiveElement");
            //ForCompositeOnly(p);

            // Create a tree structure 
            GraphicComponent CE1 = new CompositeElement("Picture");
            var root = CE1.GetComposite();
            root.Add(new PrimitiveElement("Red Line"));
            root.Add(new PrimitiveElement("Blue Circle"));
            root.Add(new PrimitiveElement("Green Box"));

            // Create a branch
            GraphicComponent CE2 = new CompositeElement2("Two Circles");
            var comp = CE2.GetComposite();
            comp.Add(new PrimitiveElement2("Black Circle"));
            comp.Add(new PrimitiveElement2("White Circle"));
            root.Add(comp);

            // Add and remove a PrimitiveElement
            PrimitiveElement pe = new PrimitiveElement("Yellow Line");
            root.Add(pe);
            root.Remove(pe);

            // Recursively display nodes
            Console.WriteLine("root(1):");
            root.Draw(1);
            Console.WriteLine("comp(1):");
            comp.Draw(1);

            // Wait for user
            Console.ReadKey();
        }

        private static void ForCompositeOnly(IGraphicComponent igc)
        {
            var i = igc as IGraphicComposite;   // ok for all
            var i2 = igc.GetComposite();        // ok for all
            var i3 = (IGraphicComposite)igc;    // ok for GraphicComposite, otherwise throws exception
        }
    }

  

    /// <summary>
    /// The 'Composite' class
    /// </summary>
    class CompositeElement : GraphicComposite
    {
        private string Name { get; }

        // Constructor
        public CompositeElement(string name)
        {
            Name = name;
        }        // Constructor

        public override void Draw(int indent)
        {
            Console.WriteLine(new string('C', indent) + " " + Name);

            // Display each child element on this node
            foreach (var d in Elements)
            {
                d.Draw(indent + 1);
            }
        }
    }
    class CompositeElement2 : CompositeElement
    {
        // Constructor
        public CompositeElement2(string name)
            : base(name)
        {
        }

        public override void Draw(int indent)
        {
            Console.Write(nameof(CompositeElement2) + " ");
            base.Draw(indent);
        }
    }


    /// <summary>
    /// The 'Leaf' class
    /// </summary>
    class PrimitiveElement : GraphicComponent
    {
        private string Name { get; }

        // Constructor
        public PrimitiveElement(string name)
        {
            Name = name;
        }

        public override void Draw(int indent)
            => Console.WriteLine(new string('P', indent) + " " + Name);
    }

    class PrimitiveElement2 : PrimitiveElement
    {
        // Constructor
        public PrimitiveElement2(string name)
            : base(name)
        {
        }

        public override void Draw(int indent)
        {
            Console.Write(nameof(PrimitiveElement2) + " ");
            base.Draw(indent);
        }
    }

}
