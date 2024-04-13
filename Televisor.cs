using Graphic3D.Models;
using Graphic3D.Rendering;
using Graphic3D.Utils;

using System.Collections.Generic;


namespace Graphic3D
{
    public class Televisor : IObject
    {
        public Dictionary<string, Part> Parts { get; private set; } = new Dictionary<string, Part>();
        public Vertex Center { get; private set; } = new Vertex(0f, 0f, 0f);

        public Televisor(Vertex pantalla, Vertex soporte)
        {
            Init(pantalla, soporte);
        }


        public Televisor(Vertex pantalla, Vertex soporte,Vertex center)
        {
            Center = center;
            Init(pantalla, soporte);   
        }

        private void Init(Vertex pantalla, Vertex soporte)
        {
            Parts.Add("pantalla", new Part(StandardGeometry.CreateCube(pantalla.X, pantalla.Y, pantalla.Z), new Vertex(Center.X, Center.Y,Center.Z)));
            Parts.Add("soporte", new Part(StandardGeometry.CreateCube(soporte.X, soporte.Y, soporte.Z), new Vertex(Center.X, Center.Y - (pantalla.Y/2 + soporte.Y / 2), Center.Z)));
        }


        public void Render(IRenderer renderer)
        {
            renderer.Draw(this);
        }

        public Part getPart(string key)
        {
            return Parts[key];
        }
    }
}
