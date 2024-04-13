using Graphic3D.Models;
using Graphic3D.Utils;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace Graphic3D.Rendering
{
    public class OpenTKRenderer : IRenderer
    {
        
        
        private static readonly Dictionary<MyPrimitiveType, PrimitiveType> EnumToOpenGLMapping =
        new Dictionary<MyPrimitiveType, PrimitiveType>
        {
            { MyPrimitiveType.Points, PrimitiveType.Points },
            { MyPrimitiveType.Lines, PrimitiveType.Lines },
            { MyPrimitiveType.LineStrip, PrimitiveType.LineStrip },
            { MyPrimitiveType.Triangles, PrimitiveType.Triangles },
            { MyPrimitiveType.TriangleStrip, PrimitiveType.TriangleStrip },
            { MyPrimitiveType.TriangleFan, PrimitiveType.TriangleFan },
        };

        public void Draw(Part part)
        {
            foreach (var faceDic in part.Faces)
            {
                Face face = faceDic.Value;

                GL.Color3(face.Color);

                foreach (var point in face.Points)
                {
                    GL.Vertex3(point.X,point.Y,point.Z);
                }
                
            }
        }

        public void Draw(IObject instance)
        {
            
            foreach (var partDic in instance.Parts)
            {
                var part = partDic.Value;
                GL.PushMatrix();
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
                GL.Translate(part.Center.X,part.Center.Y,part.Center.Z);
                GL.Rotate(20f, 20f, 20f, 0);
                PrimitiveType glPrimitiveType;
                if (EnumToOpenGLMapping.TryGetValue(part.PType, out glPrimitiveType))
                {
                    GL.Begin(glPrimitiveType);
                    Draw(part);
                    GL.End();
                }
                else
                {
                    throw new ArgumentException($"Unsupported primitive type: {part.PType}");
                }
                GL.PopMatrix();
            }
            
        }
    }
}
