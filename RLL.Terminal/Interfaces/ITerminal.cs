using OpenTK;
using RLL.Terminal.Text;
using System;

namespace RLL.Terminal.Interfaces
{
    public interface ITerminal : IWindow, IDisposable
    {
        Font Font { set; }

        void Print(string text);
        void Run();

        GameWindow GetOpenGLContext();
    }
}
