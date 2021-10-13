using Avalonia;
using Avalonia.Controls;

namespace AvaloniaUITests
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var appBuilder = AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .SetupWithoutStarting();
            
            appBuilder.Instance.RunWithMainWindow<MainWindow>();
        }
    }
}