using System;


using OpenTK.Graphics.OpenGL;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using System.Collections.Generic;

using Graphic3D.Utils;
using Graphic3D.Models;
using Graphic3D.Rendering;
using System.Drawing;

namespace Graphic3D
{
    public class Window : GameWindow
    {
        /*private Vector3 cameraPosition = new Vector3(-5, 5, 20);
        private Vector3 cameraFront = Vector3.UnitZ;
        private Vector3 cameraUp = Vector3.UnitY;
        private float cameraSpeed = 0.1f;
         */
        private float yaw = -90f; // Ángulo de rotación en yaw
        private float pitch = 0f; // Ángulo de rotación en pitch

        private float angle = 0.0f;
        private Scene scene;
        private Scene scene2;


        public Window(int width = 800, int height = 500, string title = "Objecto 3D")
            : base(width, height, GraphicsMode.Default, title)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.3f, 0.4f, 0.5f, 1f);
            GL.Enable(EnableCap.DepthTest);
            
            Dictionary<int, Face> cuello = new Dictionary<int, Face>();
            cuello.Add(1, new Face(PlanarGeometry.createCurvedSurface(4f, 2f),Color.BlueViolet ,MyPrimitiveType.TriangleStrip));

            Dictionary<string, Part> vaseParts = new Dictionary<string, Part>();
            vaseParts.Add("cuello", new Part(cuello, new Vertex(0f, 0f, 0f)));
            vaseParts.Add("cuerpo", new Part(StandardGeometry.CreateSphere(4f, 36), new Vertex(0f, -3f, 0f)));

            Dictionary<string, Part> tvParts = new Dictionary<string, Part>();
            tvParts.Add("pantalla", new Part(StandardGeometry.CreateCube(32f, 18f, 4f,Color.Black)));
            tvParts.Add("soporte", new Part(StandardGeometry.CreateCube(4f, 8f, 4f,Color.Brown), new Vertex(0f, -13f, 0f)));

            Dictionary<int, Face> diseno = new Dictionary<int, Face>();
            diseno.Add(1, new Face(PlanarGeometry.createCircle(3f,new Vertex(0f,0f,0f)), Color.Red, MyPrimitiveType.TriangleFan));
            Dictionary<string, Part> speakerParts = new Dictionary<string, Part>();
            speakerParts.Add("cuerpo", new Part(StandardGeometry.CreateCube(8f, 10f, 6f,Color.DarkBlue)));
            speakerParts.Add("diseno", new Part(diseno,new Vertex(0f,-1f,3.25f)));


            Dictionary<string, IObject> objs = new Dictionary<string, IObject>();
            
            
            objs.Add("televisor", new IObject(tvParts, new Vertex(0f, 0, 0)));
            objs.Add("florero",new IObject(vaseParts,new Vertex(12f,16f,0) ));
            objs.Add("parlanteIzq", new IObject(speakerParts,new Vertex(-20f,-12f,0)));
            objs.Add("parlanteDer", new IObject(speakerParts, new Vertex(20f, -12f, 0)));

            //scene = new Scene(objs,new OpenTKRenderer(),new Vertex(20f,15f,-10f));
            scene = JsonHelper.LoadObjectFromJsonFile<Scene>(JsonHelper.GetCurrentDirectory() + "\\scene.json");
            scene.Renderer = new OpenTKRenderer();
            scene2 = new Scene(objs, new OpenTKRenderer(), new Vertex(-20f, 0, 10f));

            
            //JsonHelper.SaveObjectToJsonFile(scene, JsonHelper.GetCurrentDirectory() + "\\scene.json"); 
            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.LoadIdentity();
            
            GL.Translate(0.0f, 0.0f, -75.0f);

            //GL.Rotate(angle, 1.0, 0.0, 0.0);

            scene.Render();
            scene2.Render();
            angle += 1.0f;
            if (angle > 90)
                angle -= 90.0f;

            Context.SwapBuffers();
            base.OnRenderFrame(e);


            // Actualizar la dirección de la cámara
            /* cameraFront = new Vector3(
                 (float)(Math.Cos(MathHelper.DegreesToRadians(yaw)) * Math.Cos(MathHelper.DegreesToRadians(pitch))),
                 (float)Math.Sin(MathHelper.DegreesToRadians(pitch)),
                 (float)(Math.Sin(MathHelper.DegreesToRadians(yaw)) * Math.Cos(MathHelper.DegreesToRadians(pitch)))
             );

             // Configurar la matriz de vista para el movimiento de la cámara
             Matrix4 viewMatrix = Matrix4.LookAt(cameraPosition, cameraPosition + cameraFront, cameraUp);
             GL.MatrixMode(MatrixMode.Modelview);
             GL.LoadMatrix(ref viewMatrix);*/

            /*Dictionary<int, Face> faceTop = new Dictionary<int, Face>();
            Dictionary<int, Face> faceBottom = new Dictionary<int, Face>();
            Dictionary<int, Face> faceSide = new Dictionary<int, Face>();
            faceTop.Add(1,new Face(PlanarGeometry.createCircle(10f,0f,0f,20f)));
            faceBottom.Add(2, new Face(PlanarGeometry.createCircle(10f, 0f, 0f, 20f)));
            faceSide.Add(3, new Face(PlanarGeometry.createCurvedSurface(20f, 10f)));
            Dictionary<string, Part> parts = new Dictionary<string, Part>();
            
            parts.Add("pantalla", new Part(faceSide,new Vertex(-20f,0f,0f),MyPrimitiveType.TriangleStrip));
            parts.Add("bottom", new Part(faceBottom, new Vertex(-20f, 0f, 0f), MyPrimitiveType.TriangleFan));
            parts.Add("top", new Part(faceTop, new Vertex(-20f, 0f, 0f), MyPrimitiveType.TriangleFan));*/

            //parts.Add("soporte", new Part(DrawCube(4f, 9f, 2f), new Vertex(0f, -13.5f, 0f)));
            //Televisor tv = new Televisor(new Vertex(0f, 0f, 0f),parts);
            //tv.Render(new OpenTKRenderer());

            //Televisor tv = new Televisor(new Vertex(32f, 18f, 2f), new Vertex(4f, 8f, 2f), new Vertex(20f, 0f, 0f));

            //Speaker tv = new Speaker(new Vertex(10f,20f,15f));
            //tv.Render(new OpenTKRenderer());


        }

        protected override void OnResize(EventArgs e)
        {
            //float d = 50;

            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            Matrix4 projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45), (float)Width / Height, 0.1f, 1000f);
            GL.LoadMatrix(ref projectionMatrix);
            //GL.Ortho(0.0f, 50.0f, 0.0f, 50.0f, -1.0f, 1.0f);
            //GL.Ortho(-d, d, -d, d, -d, d);

            GL.MatrixMode(MatrixMode.Modelview);

            //Console.WriteLine($"e: {Width}  {Height}");

            base.OnResize(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // Capturar entrada del usuario para rotar la cámara
            if (Keyboard.GetState().IsKeyDown(Key.Left))
            {
                yaw -= 1f; // Girar a la izquierda
            }
            if (Keyboard.GetState().IsKeyDown(Key.Right))
            {
                yaw += 1f; // Girar a la derecha
            }
            if (Keyboard.GetState().IsKeyDown(Key.Up))
            {
                pitch += 1f; // Inclinar hacia arriba
            }
            if (Keyboard.GetState().IsKeyDown(Key.Down))
            {
                pitch -= 1f; // Inclinar hacia abajo
            }

            base.OnUpdateFrame(e);
        }

        

    }
}




