namespace RLL.Terminal.Interfaces
{
    public interface IWindow
    {
        int Width { get; set; }
        int Height { get; set; }
        string Title { get; set; }
    }
}
