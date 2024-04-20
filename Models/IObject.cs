using Graphic3D.Rendering;
using Graphic3D.Utils;
using System;
using System.Collections.Generic;


namespace Graphic3D.Models
{
    public class IObject
    {
        public Dictionary<string, Part> Parts { get; private set; }
        public Vertex Center { get; set; } = new Vertex(0f, 0f, 0f);

        public IObject() {
            Parts = new Dictionary<string, Part>();
        }
        public IObject(Dictionary<string, Part> parts)
        {
            Parts = parts ?? throw new ArgumentNullException(nameof(parts));
        }
       
        public IObject(Dictionary<string, Part> parts, Vertex center)
        {

            Parts = parts ?? throw new ArgumentNullException(nameof(parts));
            Center = center;
        }

        public void addPart(string name, Part part)
        {
            Parts.Add(name, part);
        }
        public Part getPart(string key)
        {
            return Parts[key];
        }

        public void Draw(Vertex sceneCenter)
        {
            foreach (var part in Parts)
            {
                part.Value.Draw(sceneCenter + Center);
            }
        }

    }
}
