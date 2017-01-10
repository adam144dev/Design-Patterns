namespace adam144.GangOfFour.Composite
{
    /// <summary>
    /// The 'Component' base class
    /// </summary>

  public abstract class GraphicComponent
    {
        protected GraphicComponent Parent { get; private set; } = null;

        protected static void SetParent(GraphicComponent child, GraphicComponent parent)
            => child.Parent = parent;


        // As GraphicComposite if Composite
        public virtual GraphicComposite GetComposite() => null;


        /// <summary>
        /// Methods:
        /// </summary>

        public abstract void Draw(int indent);
    }
}
