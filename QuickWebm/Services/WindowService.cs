using System.Windows;

namespace QuickWebm.Services
{
    public class WindowService : IWindowService
    {
        public void ShowWindow(object viewModel)
        {
            var window = new Window
            {
                Content = viewModel
            };

            window.Show();
        }
    }
}
