using Graphic3D.Rendering;
using Graphic3D.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Graphic3D.Models
{
    public class Scene
    {
        public Dictionary<string, IObject> Objects { get; set; } = new Dictionary<string, IObject>();
        public Vertex Center { get; set; } = new Vertex(0f,0f,0f);
        
        [JsonIgnore] // Ignora la propiedad Renderer durante la serialización
        public IRenderer Renderer { get; set; }

        public Scene()
        {

        }

        

        public Scene(Dictionary<string, IObject> objects, IRenderer renderer)
        {
            Objects = objects ?? throw new ArgumentNullException(nameof(objects));
            Renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
        }

        public Scene(Dictionary<string, IObject> objects, IRenderer renderer,Vertex center)
        {
            Objects = objects ?? throw new ArgumentNullException(nameof(objects));
            Renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
            Center = center;
        }

        public void AddObject(string key, IObject o)
        {
            Objects.Add(key, o);
        }

        public IObject GetOject(string key)
        {
            return Objects[key];
        }
    

        public void Render()
        {
            foreach (var o in Objects)
            {
                Renderer.Draw(o.Value,o.Value.Center + Center);
            }
        }

        public override string ToString()
        {
            return $"{Objects}";
        }
    }
}
