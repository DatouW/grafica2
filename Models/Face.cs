using Graphic3D.Utils;

using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Graphic3D.Models
{
    public class Face
    {
        // Almacena los vértices de una cara, key=índice del vértice,valor=Vertex
        public List<Vertex> Points { get; private set; }
        public Color Color { get; set; } = Color.White;
        public MyPrimitiveType PType { get; set; } = MyPrimitiveType.Triangles;
        public Face()
        {
            Points = new List<Vertex>();
            
        }

        public Face(List<Vertex> points)
        {
            Points = points;
        }

        public Face(List<Vertex> points,Color color, MyPrimitiveType type = MyPrimitiveType.Triangles)
        {
            Points = points;
            Color = color;
            PType = type;
        }

        public Face(List<Vertex> points,MyPrimitiveType type = MyPrimitiveType.Triangles)
        {
            Points = points;
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
            return Points[index];
        }

        // Borra los datos de los vértices
        public void ClearPoints()
        {
            Points.Clear();
        }

    }

}
