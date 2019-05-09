using RLL.Terminal;
using System;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var term = new Terminal())
            {
                term.SetFont("Fonts/courier.ttf");
                term.Print("Hello World!");
                term.Run();
            }
        }
    }
}
