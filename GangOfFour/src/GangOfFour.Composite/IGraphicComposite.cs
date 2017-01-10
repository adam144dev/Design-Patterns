using System.Collections.Generic;

namespace adam144.GangOfFour.Composite
{
    public interface IGraphicComposite
    {
        void Add(GraphicComponent component);
        void Remove(GraphicComponent component);
        IEnumerable<GraphicComponent> GetChilds();
    }
}
