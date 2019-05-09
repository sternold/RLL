using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES20;
using QuickFont;
using QuickFont.Configuration;

namespace RLL.Terminal
{
    public class Terminal : GameWindow
    {
        private QFontDrawing drawing;
        private QFont font;
        private Matrix4 projection;

        public Terminal(int width = 640, int height = 480, string title = "Roguelike Library Terminal")
            : base(width, height, OpenTK.Graphics.GraphicsMode.Default, title)
        {
            drawing = new QFontDrawing();
        }

        public void SetFont(string filename)
        {
            font = new QFont(filename, 10.0f, new QFontBuilderConfiguration(true));
        }

        public void Print(string text)
        {
            drawing.DrawingPrimitives.Clear();
            drawing.Print(font, text, new Vector3(256, 256, 0), QFontAlignment.Centre, Color.Black);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.White);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            projection = Matrix4.CreateOrthographicOffCenter(ClientRectangle.X, ClientRectangle.Width, ClientRectangle.Y, ClientRectangle.Height, -1.0f, 1.0f);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            drawing.ProjectionMatrix = projection;
            Print("Hello World!");
            drawing.RefreshBuffers();
            drawing.Draw();
            SwapBuffers();
        }

        protected override void Dispose(bool manual)
        {
            base.Dispose(manual);
            drawing?.Dispose();
            font?.Dispose();
        }
    }
}
