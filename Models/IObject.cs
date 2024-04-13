using Graphic3D.Rendering;
using Graphic3D.Utils;
using System.Collections.Generic;


namespace Graphic3D.Models
{
    public interface IObject
    {
        Dictionary<string, Part> Parts { get; }
        Vertex Center { get; }

        Part getPart(string key);

        // Dibuja el objeto utilizando un renderer específico
        void Render(IRenderer renderer);
    }
}
