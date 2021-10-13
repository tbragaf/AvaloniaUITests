using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaUITests
{
    public class TestWindow : Window
    {
        private readonly TaskCompletionSource<bool> getResultTaskCompletionSource = new TaskCompletionSource<bool>();

        public TestWindow() : this(0) { }

        public TestWindow(int testId)
        {
            AvaloniaXamlLoader.Load(this);
            
            // Simulate async work
            Task.Delay(testId * 1000).ContinueWith(_ => getResultTaskCompletionSource.SetResult(true));
        }
        
        public Task<bool> GetResult() => getResultTaskCompletionSource.Task;
    }
}