using RLL.Terminal;
using System;
using RLL.Terminal.Text;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
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
