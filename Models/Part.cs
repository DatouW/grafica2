

using Graphic3D.Rendering;
using Graphic3D.Utils;
using System.Collections.Generic;

namespace Graphic3D.Models
{
    // La clase Part representa las partes que componen una figura
    public class Part
    {
        // Almacena las caras de una parte, el id de la cara (como un número), y el valor = Face
        public Dictionary<int, Face> Faces { get; private  set; } 
        public Vertex Center { get; set; } = new Vertex(0f, 0f, 0f);
        public MyPrimitiveType PType { get; set; } = MyPrimitiveType.Triangles;

        public Part()
        {
            Faces = new Dictionary<int, Face>();
        }

        public Part(Dictionary<int, Face> faces, MyPrimitiveType type = MyPrimitiveType.Triangles)
        {
            Faces = faces;
            PType = type;
        }

        public Part(Dictionary<int, Face> faces,Vertex center,MyPrimitiveType type = MyPrimitiveType.Triangles)
        {
            Faces = faces;
            Center = center;
            PType = type;
        }

        // Agrega o actualiza una cara
        public void AddFace(int id, Face face)
        {
            Faces[id] = face;
        }

        public void ClearFaces()
        {
            Faces.Clear();
        }

        public void Draw(Vertex objCenter)
        {
            foreach (var face in Faces)
            {
                face.Value.Draw(objCenter + Center);
            }
        }

    }

}
