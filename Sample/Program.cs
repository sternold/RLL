using RLL.Terminal;
using RLL.Terminal.Text;

namespace Sample
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            using (var term = new Terminal())
            {
                term.Font = new Font { Filename = "Fonts/courier.ttf", Size = 10.0f };
                term.Print("Hello World!");
                term.Run();
            }
        }
    }
}
