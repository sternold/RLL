using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLL.Terminal.Interfaces
{
    public interface IWindow
    {
        int Width { get; set; }
        int Height { get; set; }
        string Title { get; set; }
    }
}
