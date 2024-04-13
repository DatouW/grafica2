using Graphic3D.Models;
using Graphic3D.Rendering;
using Graphic3D.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic3D
{
    public class Speaker : IObject
    {
        public Dictionary<string, Part> Parts { get; private set; } = new Dictionary<string, Part>();
        public Vertex Center { get; private set; } = new Vertex(0f, 0f, 0f);

        public Speaker(Vertex dimension)
        {
            Init(dimension);
        }


        public Speaker(Vertex dimension, Vertex center)
        {
            Center = center;
            Init(dimension);
        }

        private void Init(Vertex dimension)
        {
            //Dictionary<int, Face> diseno = new Dictionary<int, Face>();
            //diseno.Add(1, new Face(PlanarGeometry.createCircle(dimension.X / 2 -1f, 0, 0, 0.1f),Color.Red,MyPrimitiveType.TriangleFan));

            Parts.Add("cuerpo", new Part(StandardGeometry.CreateCube(dimension.X, dimension.Y, dimension.Z), new Vertex(Center.X, Center.Y, Center.Z)));
            //Parts.Add("diseno", new Part(diseno, new Vertex(Center.X, Center.Y - dimension.Y/2 + dimension.X / 2, Center.Z + dimension.Z / 2)));
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
