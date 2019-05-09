using OpenGL.CoreUI;

namespace RLL.Terminal
{
    public class Terminal
    {
        public void Run()
        {
            using (NativeWindow nativeWindow = NativeWindow.Create())
            {
                nativeWindow.Create(0, 0, 640, 480, NativeWindowStyle.Overlapped);
                nativeWindow.Show();
                nativeWindow.Run();
            }
        }
    }
}
