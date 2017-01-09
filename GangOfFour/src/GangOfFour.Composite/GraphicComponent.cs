using System;

namespace adam144.GangOfFour.Composite
{
    /// <summary>
    /// The 'Component' interface & base class
    /// </summary>

    public interface IGraphicComponent
    {
        /// <summary>
        /// As IGraphicComposite if Composite
        /// </summary>

        IGraphicComposite GetComposite();


        /// <summary>
        /// Methods
        /// </summary>
         
        void Draw(int indent);
    }


    public abstract class GraphicComponent : IGraphicComponent
    {
        public virtual IGraphicComposite GetComposite() => null;

        public abstract void Draw(int indent);
    }
}
