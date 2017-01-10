using System.Collections.Generic;

namespace adam144.GangOfFour.Composite
{
    /// <summary>
    /// The 'Component' base class
    /// </summary>

    public abstract class GraphicComponent
    {
        protected GraphicComponent Parent { get; private set; } = null;


        /// <summary>
        /// IGraphicComposite
        /// </summary>
        protected sealed class Composite : IGraphicComposite
        {
            private readonly GraphicComponent _component;

            private List<GraphicComponent> Childs { get; } = new List<GraphicComponent>();

            public Composite(GraphicComponent component)
            {
                _component = component;
            }


            /// <summary>
            /// IGraphicComposite
            /// </summary>
            
            public void Add(GraphicComponent child)
            {
                child.Parent = _component;
                Childs.Add(child);
            }

            public void Remove(GraphicComponent child)
            {
                Childs.Remove(child);
                child.Parent = null;
            }

            public IEnumerable<GraphicComponent> GetChilds() => Childs;
        }


        /// <summary>
        /// Methods:
        /// </summary>

        public abstract void Draw(int indent);
    }
}
