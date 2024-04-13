using Graphic3D.Rendering;
using System;
using System.Collections.Generic;

namespace Graphic3D.Models
{
    public class Stage
    {
        public Dictionary<string, IObject> Objects { get; set; } = new Dictionary<string, IObject>();
        private readonly IRenderer Renderer;
        public Stage(Dictionary<string, IObject> objects, IRenderer renderer)
        {
            Objects = objects ?? throw new ArgumentNullException(nameof(objects));
            Renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
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
            foreach(var o in Objects)
            {
                Renderer.Draw(o.Value);
            }
        }
    }
}
