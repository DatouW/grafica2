using System;
using System.Collections.Generic;


namespace Graphic3D.Utils
{
    public static class PlanarGeometry
    {
        //trianglefan
        public static List<Vertex> createCircle(float radius, float centerX, float centerY, float z)
        {
            int NUM_SEGMENTS = 36;
            float angleIncrement = (float)(2 * Math.PI) / NUM_SEGMENTS;
            var points = new List<Vertex>();

            points.Add(new Vertex(centerX, centerY, z));
            for (int i = 0; i <= NUM_SEGMENTS; i++)
            {
                float angle = i * angleIncrement;
                float x = centerX + radius * (float)Math.Cos(angle);
                float y = centerY + radius * (float)Math.Sin(angle);
                points.Add(new Vertex(x, y, z));
            }
            return points;
        }

        //trianglestrip
        public static List<Vertex> createCurvedSurface(float height, float radius)
        {
            int NUM_SEGMENTS = 36;
            float angleIncrement = (float)(2 * Math.PI) / NUM_SEGMENTS;
            var points = new List<Vertex>();

            for (int i = 0; i <= NUM_SEGMENTS; i++)
            {
                float angle = i * angleIncrement;
                float x = radius * (float)Math.Cos(angle);
                float y = radius * (float)Math.Sin(angle);

                //bottom vertex
                points.Add(new Vertex(x, 0, y));

                // top vertex
                points.Add(new Vertex(x, height, y));
            }

            return points;
        }

    }
}
