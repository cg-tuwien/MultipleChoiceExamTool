using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McExamTool.ViewModel
{
    class SetupData : BindableBase
    {
        private string _StudentFirstName;
        private string _StudentLastName;
        private string _StudentMatriculationNumber;
        private string _PathToCsvFile;
        private int _NumQuestionsToAsk;

        public string StudentFirstName
        {
            get => _StudentFirstName;
            set => SetProperty(ref _StudentFirstName, value);
        }
        public string StudentLastName
        {
            get => _StudentLastName;
            set => SetProperty(ref _StudentLastName, value);
        }
        public string StudentMatriculationNumber
        {
            get => _StudentMatriculationNumber;
            set => SetProperty(ref _StudentMatriculationNumber, value);
        }
        public string PathToCsvFile
        {
            get => _PathToCsvFile;
            set => SetProperty(ref _PathToCsvFile, value);
        }
        public int NumQuestionsToAsk
        {
            get => _NumQuestionsToAsk;
            set => SetProperty(ref _NumQuestionsToAsk, value);
        }
    }
}
