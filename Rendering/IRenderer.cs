using Graphic3D.Models;
using Graphic3D.Utils;

namespace Graphic3D.Rendering
{
    public interface IRenderer
    {
        void Draw(Part part);
        void Draw(IObject objectInstance);
        void Draw(IObject objectInstance,Vertex center);
        //void Draw(Scene scene);
    }
}
