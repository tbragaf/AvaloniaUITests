using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

namespace AvaloniaUITests
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            AvaloniaXamlLoader.Load(this);

            Height = 500;
            Width = 500;
            
            var runTestsButton = this.FindControl<Button>("runTests");
            runTestsButton.Click += OnRunTests;
        }

        private async void OnRunTests(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Tests started");
            await RunMultipleTests();
            Debug.WriteLine("Tests finished");
        }

        private async Task<bool> RunMultipleTests()
        {
            var success = true;
            for (var i = 1; i < 5; i++)
            {
                Debug.WriteLine("Running test " + i);
                var testResult = await RunTest(i);
                Debug.WriteLine("Test finished " + i);
                success = testResult && success;
            }

            return success;
        }

        private Task<bool> RunTest(int testId)
        {
            var testWindow = new TestWindow(testId);
            var getResult = testWindow.GetResult();
            
            var success = false;
            getResult.ContinueWith(t =>
            {
                success = t.Result;
                Dispatcher.UIThread.InvokeAsync(() => testWindow.Close(success));
            });
            
            
            Application.Current.Run(testWindow);
            Debug.WriteLine("Run stops after closing the test window");
            return Task.FromResult(success);
        }
    }
}