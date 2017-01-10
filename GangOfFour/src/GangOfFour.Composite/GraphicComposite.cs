using System.Collections.Generic;

namespace adam144.GangOfFour.Composite
{
    /// <summary>
    /// The 'Composite' base class
    /// </summary>

    public abstract class GraphicComposite : GraphicComponent
    {
        protected List<GraphicComponent> Elements { get; } = new List<GraphicComponent>();


        public override GraphicComposite GetComposite() => (GraphicComposite)this;


        public virtual void Add(GraphicComponent child)
        {
            SetParent(child, this);
            Elements.Add(child);
        }

        public virtual void Remove(GraphicComponent child)
        {
            Elements.Remove(child);
            SetParent(child, null);
        }
    }
}
