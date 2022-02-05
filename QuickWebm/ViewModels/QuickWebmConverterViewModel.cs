using FFmpeg.NET;
using FFmpeg.NET.Events;
using QuickWebm.Commands;
using QuickWebm.Services;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace QuickWebm.ViewModels
{
    public class QuickWebmConverterViewModel : ViewModelBase
    {
        #region Properties
        private string inputFilePath;
        private string outputFilePath;
        private bool browseOutputEnabled;
        private bool busyConverting;
        private readonly string ffmpegPath;

        /// <summary>
        /// The path to the file the user wants to convert.
        /// </summary>
        public string InputFilePath
        {
            get { return inputFilePath; }
            set
            {
                if (inputFilePath != value)
                {
                    inputFilePath = value;
                    OutputFilePath = GenerateOutputFilePath(value); 
                    ConvertCommand.RaiseCanExecuteChanged();
                    BrowseOutputEnabled = true;
                    OnPropertyChanged(nameof(InputFilePath));
                }

                static string GenerateOutputFilePath(string value)
                {
                    var fileExtensionDot = value.LastIndexOf('.');
                    var pathMinusExtension = value.Substring(0, fileExtensionDot);
                    return $"{pathMinusExtension}.webm";
                }
            }
        }

        /// <summary>
        /// The destination path of the converted file.
        /// </summary>
        public string OutputFilePath
        {
            get { return outputFilePath; }
            set
            {
                if (outputFilePath != value)
                {
                    outputFilePath = value;
                    OnPropertyChanged(nameof(OutputFilePath));
                }
            }
        }

        /// <summary>
        /// If there's no input, the user shouldn't be able to browse for an output path.
        /// </summary>
        public bool BrowseOutputEnabled
        {
            get { return browseOutputEnabled; }
            set 
            { 
                browseOutputEnabled = value;
                OnPropertyChanged(nameof(BrowseOutputEnabled));
            }
        }

        /// <summary>
        /// Status indicator for whether or not the applicaiton is performing a video conversion.
        /// </summary>
        public bool BusyConverting 
        { 
            get { return busyConverting; }
            set
            {
                busyConverting = value;
                OnPropertyChanged(nameof(BusyConverting));
            }
        }

        public WebmEncodingViewModel Encoding { get; set; }

        public AdvancedOptionsViewModel AdvancedOptions { get; set; }

        public AsyncCommand ConvertCommand { get; private set; }

        #endregion

        public QuickWebmConverterViewModel(IDialogService dialogService)
        {
            ffmpegPath = Path.Combine(Environment.CurrentDirectory, "Binaries", "ffmpeg.exe");
            ConvertCommand = new AsyncCommand(ConvertToWebm, ConvertEnabled);

            Encoding = new WebmEncodingViewModel();
            AdvancedOptions = new AdvancedOptionsViewModel();
        }

        public async Task ConvertToWebm()
        {
            var inputFile = new InputFile(InputFilePath);
            var outputFile = new OutputFile(OutputFilePath);
            var cancelToken = new CancellationTokenSource().Token;

            var conversionOptions = new ConversionOptions()
            {
                AudioBitRate = Encoding.AudioBitrate,
                RemoveAudio = Encoding.EnableAudio,
                VideoBitRate = Encoding.VideoBitrate,
                VideoFormat = FFmpeg.NET.Enums.VideoFormat.webm
            };

            var ffmpeg = new Engine(ffmpegPath);
            BusyConverting = true;

            ffmpeg.Progress += OnProgress;
            ffmpeg.Complete += OnComplete;

            await ffmpeg.ConvertAsync(inputFile, outputFile, conversionOptions, cancelToken);
        }

        private void OnComplete(object? sender, ConversionCompleteEventArgs e)
        {
            BusyConverting = false;
        }

        private void OnProgress(object? sender, ConversionProgressEventArgs e)
        {
            
        }

        private bool ConvertEnabled()
        {
            if (string.IsNullOrEmpty(InputFilePath) || string.IsNullOrEmpty(OutputFilePath))
            {
                return false;
            }

            return true;
        }
    }
}
