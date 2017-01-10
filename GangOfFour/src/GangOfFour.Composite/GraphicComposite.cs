using System.Collections.Generic;

namespace adam144.GangOfFour.Composite
{
    /// <summary>
    /// The 'Composite' base class 
    /// but still can implement IGraphicComposite without these base
    /// ie. using GraphicComponent.Composite and GraphicComposite as an example
    /// </summary>
    public abstract class GraphicComposite : GraphicComponent, IGraphicComposite
    {
        private readonly GraphicComponent.Composite _composite;

        protected GraphicComposite()
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

        //public abstract override void Draw(int indent);
        public override void Draw(int indent)
        {
            // Display each child element on this node
            foreach (var child in GetChilds())
            {
                child.Draw(indent + 1);
            }
        }
    }
}
