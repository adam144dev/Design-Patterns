using System;

namespace adam144.GangOfFour.Composite
{
    /// <summary>
    /// The 'Component' interface & base class
    /// </summary>

    public interface IGraphicComponent
    {
        IGraphicComposite GetComposite();
        void Draw(int indent);
    }

    public abstract class GraphicComponent : IGraphicComponent
    {
        public virtual IGraphicComposite GetComposite() => null;

        protected string Name { get; }

        protected GraphicComponent(string name)
        {
            Name = name;
        }

        public virtual void Draw(int indent)
            => Console.WriteLine(new string('P', indent) + " " + Name);
    }
}
