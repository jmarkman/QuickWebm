using QuickWebm.Commands;
using QuickWebm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickWebm.ViewModels
{
    public class VideoEffectsViewModel : ViewModelBase
    {
        private readonly IWindowService windowService;

        public VideoResolutionViewModel VideoResolution { get; private set; }

        public RelayCommand ShowResolutionPopupCommand { get; set; }

        public VideoEffectsViewModel(IWindowService windowService)
        {
            this.windowService = windowService;
            ShowResolutionPopupCommand = new RelayCommand(ShowVideoDimensionsPopup);
            VideoResolution = new VideoResolutionViewModel();
        }

        public void ShowVideoDimensionsPopup()
        {
            windowService.ShowWindow(VideoResolution);
        }
    }
}
