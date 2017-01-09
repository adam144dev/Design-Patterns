﻿using System;
using System.Collections.Generic;

namespace adam144.GangOfFour.Composite
{
    /// <summary>
    /// The 'Composite' interface & base class
    /// </summary>

    public interface IGraphicComposite : IGraphicComponent
    {
        void Add(IGraphicComponent d);
        void Remove(IGraphicComponent d);
    }

    public abstract class GraphicComposite : GraphicComponent, IGraphicComposite
    {
        private readonly List<IGraphicComponent> elements = new List<IGraphicComponent>();

        protected GraphicComposite(string name)
            : base(name)
        {
        }


        /// <summary>
        /// IGraphicComponent
        /// </summary>

        public virtual void Add(IGraphicComponent d)
            => elements.Add(d);

        public virtual void Remove(IGraphicComponent d)
            => elements.Remove(d);


        /// <summary>
        /// IGraphicComposite
        /// </summary>

        public override IGraphicComposite GetComposite() => (IGraphicComposite)this;

        public override void Draw(int indent)
        {
            Console.WriteLine(new string('C', indent) + " " + Name);

            // Display each child element on this node
            foreach (var d in elements)
            {
                d.Draw(indent + 1);
            }
        }
    }
}
