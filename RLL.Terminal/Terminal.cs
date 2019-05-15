using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.ES20;
using QuickFont;
using QuickFont.Configuration;
using RLL.Terminal.Interfaces;

namespace RLL.Terminal
{
    public class Terminal : ITerminal
    {
        private GameWindow window;
        private QFontDrawing drawing;

        private QFont font;
        private Matrix4 projection;

        public Text.Font Font { set => font = new QFont(value.Filename, value.Size, new QFontBuilderConfiguration(true)); }
        public int Width { get => window.Width; set => window.Width = value; }
        public int Height { get => window.Height; set => window.Height = value; }
        public string Title { get => window.Title; set => window.Title = value; }

        public Terminal(int width = 640, int height = 480, string title = "Roguelike Library Terminal")
        {
            window = new GameWindow();
            window.Load += OnLoad;
            window.Resize += OnResize;
            window.RenderFrame += OnRenderFrame;

            drawing = new QFontDrawing();
        }

        public void Print(string text)
        {
            drawing.DrawingPrimitives.Clear();
            drawing.Print(font, text, new Vector3(256, 256, 0), QFontAlignment.Centre, Color.Black);
        }

        public void Run() => window.Run();
        public GameWindow GetOpenGLContext() => window;

        public void Dispose()
        {
            window?.Dispose();
            drawing?.Dispose();
            font?.Dispose();
        }

        protected void OnLoad(object sender, EventArgs e)
        {
            GL.ClearColor(Color.White);
        }

        protected void OnResize(object sender, EventArgs e)
        {
            GL.Viewport(
                window.ClientRectangle.X,
                window.ClientRectangle.Y,
                window.ClientRectangle.Width,
                window.ClientRectangle.Height);
            projection = Matrix4.CreateOrthographicOffCenter(
                window.ClientRectangle.X,
                window.ClientRectangle.Y,
                window.ClientRectangle.Width,
                window.ClientRectangle.Height,
                -1.0f, 1.0f);
        }

        protected void OnRenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            drawing.ProjectionMatrix = projection;
            drawing.RefreshBuffers();
            drawing.Draw();
            window.SwapBuffers();
        }
    }
}
