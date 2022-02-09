using QuickWebm.Commands;
using QuickWebm.Services;

namespace QuickWebm.ViewModels
{
    public class VideoEffectsViewModel : ViewModelBase
    {
        public RelayCommand ShowVideoResolutionCommand { get; private set; }
        public IDialogService DialogService { get; set; }

        public VideoEffectsViewModel(IDialogService dialogService)
        {
            DialogService = dialogService;
            ShowVideoResolutionCommand = new RelayCommand(ShowVideoResolutionWindow);
        }

        private void ShowVideoResolutionWindow()
        {
            DialogService.ShowDialog<VideoResolutionViewModel>();
        }
    }
}
