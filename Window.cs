﻿using System;

using OpenTK.Graphics.OpenGL;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using System.Collections.Generic;

using Graphic3D.Utils;
using Graphic3D.Models;
using Graphic3D.Rendering;
using System.Drawing;
using System.Windows.Forms;

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

        //private Button saveButton, loadButton;

        public Window(int width = 800, int height = 500, string title = "Objecto 3D")
            : base(width, height, GraphicsMode.Default, title)
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.3f, 0.4f, 0.5f, 1f);
            GL.Enable(EnableCap.DepthTest);

            initObjects();
            
            base.OnLoad(e);
        }

        private void initObjects()
        {
            Dictionary<int, Face> cuello = new Dictionary<int, Face>();
            cuello.Add(1, new Face(PlanarGeometry.createCurvedSurface(4f, 2f), Color.BlueViolet, MyPrimitiveType.TriangleStrip));

            Dictionary<string, Part> vaseParts = new Dictionary<string, Part>();
            vaseParts.Add("cuello", new Part(cuello, new Vertex(0f, 0f, 0f)));
            vaseParts.Add("cuerpo", new Part(StandardGeometry.CreateSphere(4f, 36), new Vertex(0f, -3f, 0f)));

            Dictionary<string, Part> tvParts = new Dictionary<string, Part>();
            tvParts.Add("pantalla", new Part(StandardGeometry.CreateCube(32f, 18f, 4f, Color.Black)));
            tvParts.Add("soporte", new Part(StandardGeometry.CreateCube(4f, 8f, 4f, Color.Brown), new Vertex(0f, -13f, 0f)));

            Dictionary<int, Face> diseno = new Dictionary<int, Face>();
            diseno.Add(1, new Face(PlanarGeometry.createCircle(3f, new Vertex(0f, 0f, 0f)), Color.AntiqueWhite, MyPrimitiveType.TriangleFan));
            
            Dictionary<string, Part> speakerParts = new Dictionary<string, Part>();
            speakerParts.Add("cuerpo", new Part(StandardGeometry.CreateCube(8f, 10f, 6f, Color.Chocolate)));
            //speakerParts.Add("diseno", new Part(diseno, new Vertex(0f, -1f, 3.25f)));


            Dictionary<string, IObject> objs = new Dictionary<string, IObject>();


            //objs.Add("televisor", new IObject(tvParts, new Vertex(0f, 0, 0)));
            //objs.Add("florero", new IObject(vaseParts, new Vertex(12f, 16f, 0)));
            objs.Add("parlanteIzq", new IObject(speakerParts, new Vertex(10f, 20.0f, -10.0f)));
            
            //objs.Add("parlanteDer", new IObject(speakerParts, new Vertex(20f, -12f, 0)));

            scene = new Scene(objs, new Vertex(0f, 0f, 0f));
            //scene = JsonHelper.LoadObjectFromJsonFile<Scene>(JsonHelper.GetCurrentDirectory() + "\\scene.json");
            //scene.Renderer = new OpenTKRenderer();
            //JsonHelper.SaveObjectToJsonFile(scene, JsonHelper.GetCurrentDirectory() + "\\scene.json"); 
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.LoadIdentity();
            //GL.MatrixMode(MatrixMode.Modelview);

            //GL.Translate(10.0f, 0.0f, -75.0f);
            //GL.Rotate(angle, 1.0, 0.0, 0.0);


            //DrawCube();

            //Part cir = new Part(StandardGeometry.CreateSphere(4f,36));

            //cir.Draw(cir.Center);
            //scene.Rotate(angle,45,0);

            //scene.Translate();
            //scene.Rotate(angle,45,0);
           
            //scene.Scale(2.0f, 2.0f, 2.0f);
            scene.Draw();

            angle += 1.0f;
            if (angle > 360)
                angle -= 360.0f;

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
  
        }

        private void DrawCube()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(1.0, 1.0, 0.0);
            GL.Vertex3(-10.0, 10.0, 10.0);
            GL.Vertex3(-10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);

            GL.Color3(1.0, 0.0, 1.0);
            GL.Vertex3(10.0, 10.0, 10.0);
            GL.Vertex3(10.0, 10.0, -10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(10.0, -10.0, 10.0);

            GL.Color3(0.0, 1.0, 1.0);
            GL.Vertex3(10.0, -10.0, 10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);

            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex3(10.0, 10.0, 10.0);
            GL.Vertex3(10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, 10.0);

            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex3(10.0, 10.0, -10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, -10.0);

            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex3(10.0, 10.0, 10.0);
            GL.Vertex3(10.0, -10.0, 10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);
            GL.Vertex3(-10.0, 10.0, 10.0);

            GL.End();
        }
        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Control && e.Key == Key.S) // Ctrl + S
            {
                SaveFile();
            }
            else if (e.Control && e.Key == Key.O) // Ctrl + O
            {
                LoadFile();
            }
        }

        private void SaveFile()
        {

            string filePath = null;

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                }
            }
            Console.WriteLine(filePath);
            if (!string.IsNullOrEmpty(filePath))
            {
                JsonHelper.SaveObjectToJsonFile<Scene>(scene, filePath);
                Console.WriteLine("JSON data saved successfully.");
            }
        }

        private void LoadFile()
        {
            // Console.WriteLine("load button click");
            string filePath = null;

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }
            Console.WriteLine(filePath);
            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    scene = JsonHelper.LoadObjectFromJsonFile<Scene>(filePath);
                    //scene.Renderer = new OpenTKRenderer();
                    Console.WriteLine("JSON data loaded successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading JSON: {ex.Message}");
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            float aspectRatio = (float)Width / Height;
            float d = 50;

            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            //Matrix4 projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45), (float)Width / Height, 0.1f, 100f);
            //GL.LoadMatrix(ref projectionMatrix);
            //GL.Ortho(-d, d, -d, d, -d, d);
            if (aspectRatio >= 1.0f)
            {
                GL.Ortho(-d * aspectRatio, d * aspectRatio, -d, d, -d, d);
            }
            else
            {
                GL.Ortho(-d, d, -d / aspectRatio, d / aspectRatio, -d, d);
            }

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




