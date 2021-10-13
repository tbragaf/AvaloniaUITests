using Avalonia;
using Avalonia.Markup.Xaml;

namespace AvaloniaUITests
{
    public class App : Application
    {
        public override void Initialize() {
            AvaloniaXamlLoader.Load(this);
        }
    }
}