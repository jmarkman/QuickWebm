namespace QuickWebm.ViewModels
{
    public class WebmEncodingViewModel : ViewModelBase
    {
        #region Properties
        private string description;
        private bool twoPassEncoding;
        private bool enableAudio;
        private bool? useConstantBitRate;
        private int? sizeLimit;
        private int? videoBitrate;
        private int? audioBitrate;

        public string Description
        {
            get { return description; }
            set 
            { 
                description = value; 
                OnPropertyChanged(nameof(Description));
            }
        }

        public bool? UseConstantBitRate
        {
            get { return useConstantBitRate; }
            set 
            { 
                useConstantBitRate = value; 
                OnPropertyChanged(nameof(UseConstantBitRate));
            }
        }

        public bool TwoPassEncoding
        {
            get { return twoPassEncoding; }
            set 
            { 
                twoPassEncoding = value; 
                OnPropertyChanged(nameof(TwoPassEncoding));
            }
        }

        public int? SizeLimit
        {
            get { return sizeLimit; }
            set 
            { 
                sizeLimit = value;
                OnPropertyChanged(nameof(SizeLimit));
            }
        }

        public int? VideoBitrate
        {
            get { return videoBitrate; }
            set 
            { 
                videoBitrate = value; 
                OnPropertyChanged(nameof(VideoBitrate));
            }
        }

        public bool EnableAudio
        {
            get { return enableAudio; }
            set 
            { 
                enableAudio = value;
                OnPropertyChanged(nameof(EnableAudio));
            }
        }

        public int? AudioBitrate
        {
            get { return audioBitrate; }
            set 
            { 
                audioBitrate = value; 
                OnPropertyChanged(nameof(AudioBitrate));
            }
        }
        #endregion
    }
}
