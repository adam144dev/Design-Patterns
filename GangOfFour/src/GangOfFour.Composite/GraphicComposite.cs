using System.Collections.Generic;

namespace adam144.GangOfFour.Composite
{
    /// <summary>
    /// The 'Composite' interface & base class
    /// </summary>

    public interface IGraphicComposite : IGraphicComponent
    {
        void Add(IGraphicComponent component);
        void Remove(IGraphicComponent component);
    }

    public abstract class GraphicComposite : GraphicComponent, IGraphicComposite
    {
        protected List<IGraphicComponent> Elements { get; } = new List<IGraphicComponent>();

        /// <summary>
        /// IGraphicComposite
        /// </summary>

        public virtual void Add(IGraphicComponent component)
        {
            component.Parent = this;
            Elements.Add(component);
        }

        public virtual void Remove(IGraphicComponent component)
        {
            Elements.Remove(component);
            component.Parent = null;
        }


        /// <summary>
        /// IGraphicComponent
        /// </summary>

        public override IGraphicComposite GetComposite() => (IGraphicComposite) this;

    }
}
