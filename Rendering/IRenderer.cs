using Graphic3D.Models;


namespace Graphic3D.Rendering
{
    public interface IRenderer
    {
        void Draw(Part part);
        void Draw(IObject objectInstance);
    }
}
