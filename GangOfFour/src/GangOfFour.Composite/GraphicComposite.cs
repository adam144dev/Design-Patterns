using System;
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
        protected List<IGraphicComponent> Elements { get; } = new List<IGraphicComponent>();

        /// <summary>
        /// IGraphicComposite
        /// </summary>

        public virtual void Add(IGraphicComponent d)
            => Elements.Add(d);

        public virtual void Remove(IGraphicComponent d)
            => Elements.Remove(d);


        /// <summary>
        /// IGraphicComponent
        /// </summary>

        public override IGraphicComposite GetComposite() => (IGraphicComposite) this;

    }
}
