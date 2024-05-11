/*
using Graphic3D.Models;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Windows.Forms;

namespace Graphic3D
{
    partial class Form1 : Form
    {
        private GLControl glControl1;
        private float yaw = -90f;
        private float pitch = 0f;
        private float angle = 0.0f;
        private Scene scene;

        public Form1()
        { 

            InitializeGLControl();
            InitializeScene();
        }

        private void InitializeGLControl()
        {
            glControl1 = new GLControl();
            glControl1.Dock = DockStyle.Fill;
            this.Controls.Add(glControl1);
            glControl1.Resize += GlControl1_Resize;
            glControl1.Paint += GlControl1_Paint;
            glControl1.KeyboardDown += GlControl1_KeyDown;
        }

        private void InitializeScene()
        {
            // 这里可以调用你的initObjects()方法来初始化场景
            // initObjects();
            // 为了简洁，这里省略了具体的初始化逻辑
        }

        private void GlControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.ClearColor(0.3f, 0.4f, 0.5f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.LoadIdentity();
            GL.Translate(0.0f, 0.0f, -75.0f);

            // 更新和绘制你的场景
            // scene.Draw();

            // 根据需要旋转或更新其他状态
            angle += 1.0f;
            if (angle > 90)
                angle -= 90.0f;

            glControl1.SwapBuffers();
        }

        private void GlControl1_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45), (float)glControl1.Width / glControl1.Height, 0.1f, 1000f);
            GL.LoadMatrix(ref projectionMatrix);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void GlControl1_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Control && e.Key == Key.S) // Ctrl + S
            {
                // Save logic here
            }
            else if (e.Control && e.Key == Key.O) // Ctrl + O
            {
                // Load logic here
            }
            else if (e.Key == Key.Left)
            {
                yaw -= 1f; // Girar a la izquierda
            }
            else if (e.Key == Key.Right)
            {
                yaw += 1f; // Girar a la derecha
            }
            else if (e.Key == Key.Up)
            {
                pitch += 1f; // Inclinar hacia arriba
            }
            else if (e.Key == Key.Down)
            {
                pitch -= 1f; // Inclinar hacia abajo
            }
        }
    }

}

*/