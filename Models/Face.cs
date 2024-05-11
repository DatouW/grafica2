using Graphic3D.Utils;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace Graphic3D.Models
{
    public class Face
    {
        // Almacena los vértices de una cara, key=índice del vértice,valor=Vertex
        public List<Vertex> Points { get; private set; }
        public Color Color { get; set; } = Color.White;
        public MyPrimitiveType PType { get; set; } = MyPrimitiveType.Triangles;

        private Matrix4 _trans;
        private Matrix4 _scaleMatrix;
        private Matrix4 _translationMatrix;
        private Matrix4 _rotationMatrix;

        public Face()
        {
            Points = new List<Vertex>();
            _trans = Matrix4.Identity;
            _scaleMatrix = Matrix4.Identity;
            _translationMatrix = Matrix4.Identity;
            _rotationMatrix = Matrix4.Identity;
        }


        public Face(List<Vertex> points, MyPrimitiveType type = MyPrimitiveType.Triangles)
        {
            Points = points ?? throw new ArgumentNullException(nameof(points));
            PType = type;
        }

        public Face(List<Vertex> points,Color color, MyPrimitiveType type = MyPrimitiveType.Triangles)
        {
            Points = points ?? throw new ArgumentNullException(nameof(points)); 
            Color = color;
            PType = type;
            
        }

        // Agrega o actualiza un vértice
        public void InsertPoint(int index, Vertex point)
        {
            if (index >= Points.Count)
                return;
            Points.Insert(index, point);
        }

        public void updatePoint(int index, Vertex point)
        {
            if (index >= Points.Count)
                return;
            Points[index] = point;
        }

        public void AddPoint(Vertex point)
        {
            Points.Add(point);
        }

        public Vertex GetPoint(int index)
        {
            if (index < 0 || index >= Points.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            return Points[index];
        }


        public void ClearPoints()
        {
            Points.Clear();
        }

        public void Translate(Vertex center,float x = 0, float y = 0, float z = 0)
        {

            _translationMatrix = Matrix4.CreateTranslation(x+center.X, y+center.Y, z+center.Z);
            //Console.WriteLine("translation: " + _translationMatrix);
            ApplyTransformationMatrix();

        }

        public void Scale(float x, float y, float z)
        {
            _scaleMatrix = Matrix4.CreateScale(x, y, z);
            ApplyTransformationMatrix();
        }

        public void Rotate(float x, float y, float z)
        {
            float radiansX = MathHelper.DegreesToRadians(x);
            float radiansY = MathHelper.DegreesToRadians(y);
            float radiansZ = MathHelper.DegreesToRadians(z);
            _rotationMatrix = Matrix4.CreateRotationZ(radiansZ) * Matrix4.CreateRotationY(radiansY)* Matrix4.CreateRotationX(radiansX) ;
            
            ApplyTransformationMatrix();
        }

        public void Rotate(Vertex center, float x, float y, float z)
        {
            float radiansX = MathHelper.DegreesToRadians(x);
            float radiansY = MathHelper.DegreesToRadians(y);
            float radiansZ = MathHelper.DegreesToRadians(z);
            Matrix4 trans1 = Matrix4.CreateTranslation(-center.X,-center.Y,-center.Z);
            Matrix4 rot = Matrix4.CreateRotationZ(radiansZ) * Matrix4.CreateRotationY(radiansY) * Matrix4.CreateRotationX(radiansX);
            Matrix4 trans2 = Matrix4.CreateTranslation(center.X,center.Y,center.Z);
            _rotationMatrix = trans1 * rot * trans2;
            ApplyTransformationMatrix();
        }

        private void ApplyTransformationMatrix()
        {
            _trans = _translationMatrix * _rotationMatrix * _scaleMatrix;
        }

        float angle = 0f;
        
        public void Draw()
        {
            Console.WriteLine("angle: " + angle);

            GL.PushMatrix();
            GL.MultMatrix(ref _trans);
            //GL.Scale(2f, 2f, 2f);
            //GL.Translate(4f, 0, 0);
            //GL.Rotate(angle, 1, 0, 0);
            //GL.Translate(-4f, 0, 0);
            //GL.Translate(2f, 4f, 0);
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(Color);

            foreach (var point in Points)
            {
                GL.Vertex3(point.X, point.Y, point.Z);
            }
            GL.End();
            

            GL.PopMatrix();
            angle += 1.0f;
            if (angle > 360)
                angle -= 360.0f;
        }
    }

}
