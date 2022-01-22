using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickWebm
{
    internal class QuickWebmConverterViewModel : ViewModelBase
    {
        #region Properties
        private string inputFilePath;
        private string outputFilePath;

        public string InputFilePath
        {
            get { return inputFilePath; }
            set
            {
                if (inputFilePath != value)
                {
                    inputFilePath = value;
                    OnPropertyChanged(nameof(InputFilePath));
                }

            }
        }

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
        #endregion
    }
}
