using System;
using System.Collections.Generic;

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
            var root = new CompositeElement("Picture");
            root.Add(new PrimitiveElement("Red Line"));
            root.Add(new PrimitiveElement("Blue Circle"));
            root.Add(new PrimitiveElement("Green Box"));

            // Create a branch
            var comp = new CompositeElement2("Two Circles");
            comp.Add(new PrimitiveElement2("Black Circle"));
            comp.Add(new PrimitiveElement2("White Circle"));
            root.Add(comp);

            var compOnPrimitive = new CompositeOnPrimitiveElement("CompositeOnPrimitiveElement");
            compOnPrimitive.Add(new PrimitiveElement("PrimitiveElement1"));
            var compOnPrimitiveComposite = new CompositeElement("CompositeElement");
            compOnPrimitive.Add(compOnPrimitiveComposite);
            root.Add(compOnPrimitive);
            compOnPrimitiveComposite.Add(new PrimitiveElement("PrimitiveElement-compOnPrimitiveComposite"));

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

        private static void ForCompositeOnly(GraphicComponent igc)
        {
            var i2 = igc as IGraphicComposite;  // ok for all
            var i3 = (IGraphicComposite)igc;    // ok for GraphicComposite, otherwise throws exception
        }
    }


    /// <summary>
    /// The 'Composite' class based on GraphicComposite
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
            foreach (var child in GetChilds())
            {
                child.Draw(indent + 1);
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
            Console.Write($"{nameof(CompositeElement2)}: ");
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
            Console.Write($"{nameof(PrimitiveElement2)}: ");
            base.Draw(indent);
        }
    }

    /// <summary>
    /// The 'Composite' class based on Component derived class
    /// </summary>
    class CompositeOnPrimitiveElement : PrimitiveElement2, IGraphicComposite
    {
        private readonly GraphicComponent.Composite _composite;

        public CompositeOnPrimitiveElement(string name)
            : base(name)
        {
            _composite = new GraphicComponent.Composite(this);
        }

        /// <summary>
        /// IGraphicComposite
        /// </summary>

        public virtual void Add(GraphicComponent child)
            => _composite.Add(child);

        public virtual void Remove(GraphicComponent child)
            => _composite.Remove(child);

        public virtual IEnumerable<GraphicComponent> GetChilds()
            => _composite.GetChilds();

        /// <summary>
        /// Methods:
        /// </summary>

        public override void Draw(int indent)
        {
            // Display each child element on this node
            foreach (var child in GetChilds())
            {
                Console.Write($"{nameof(CompositeOnPrimitiveElement)} on {nameof(PrimitiveElement2)}: ");
                child.Draw(indent + 1);
            }
        }
    }
}
