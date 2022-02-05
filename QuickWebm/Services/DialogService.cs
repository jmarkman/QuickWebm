using QuickWebm.ViewModels;
using QuickWebm.Views;
using System;
using System.Collections.Generic;

namespace QuickWebm.Services
{
    public class DialogService : IDialogService
    {
        static readonly Dictionary<Type, Type> dialogViewModelMap = new()
        {
            { typeof(VideoResolutionViewModel), typeof(VideoResolutionView) }
        };

        public void ShowDialog<TViewModel>()
        {
            var viewModelType = dialogViewModelMap[typeof(TViewModel)];
            var dialog = new DialogWindow
            {
                Content = Activator.CreateInstance(viewModelType)
            };

            dialog.ShowDialog();
        }
    }
}
