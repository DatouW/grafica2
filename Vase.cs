using Graphic3D.Models;
using Graphic3D.Rendering;
using Graphic3D.Utils;
using System;
using System.Collections.Generic;

namespace Graphic3D
{
    public class Vase : IObject
    {
        public Dictionary<string, Part> Parts { get; private set; } = new Dictionary<string, Part>();
        public Vertex Center { get; private set; } = new Vertex(0f, 0f, 0f);

        public Vase(float radiusN, float heightN, float radiusB)
        {
            Init(radiusN, heightN,radiusB);
        }


        public Vase(float radiusN,float heightN, float radiusB,Vertex center )
        {
            Center = center;
            Init(radiusN, heightN, radiusB);
        }

        private void Init(float radiusN, float heightN, float radiusB)
        {
            Dictionary<int, Face> cuello = new Dictionary<int, Face>();
            cuello.Add(1, new Face(PlanarGeometry.createCurvedSurface(heightN,radiusN)));

            Parts.Add("cuello", new Part(cuello, new Vertex(Center.X, Center.Y, Center.Z),MyPrimitiveType.TriangleStrip));
            Parts.Add("cuerpo", new Part(StandardGeometry.CreateSphere(radiusB, 30), new Vertex(Center.X, Center.Y - radiusB + 2f, Center.Z),MyPrimitiveType.TriangleFan));
        }

        public Part getPart(string key)
        {
            return Parts[key];
        }

        
        public void Render(IRenderer renderer)
        {
            renderer.Draw(this);
        }
    }
}
