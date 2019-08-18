using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McExamTool.ViewModel
{
    class ResultData : BindableBase
    {
        private string _StudentFirstName;
        private string _StudentLastName;
        private string _StudentMatriculationNumber;
        private int _NumQuestionsAsked;
        private int _NumCorrectAnswers;
        private double _NumCorrectPercent;
        private string _ResultsSavePath;

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
        public int NumQuestionsAsked
        {
            get => _NumQuestionsAsked;
            set => SetProperty(ref _NumQuestionsAsked, value);
        }
        public int NumCorrectAnswers
        {
            get => _NumCorrectAnswers;
            set => SetProperty(ref _NumCorrectAnswers, value);
        }
        public double NumCorrectPercent
        {
            get => _NumCorrectPercent;
            set => SetProperty(ref _NumCorrectPercent, value);
        }
        public string ResultsSavePath
        {
            get => _ResultsSavePath;
            set => SetProperty(ref _ResultsSavePath, value);
        }
    }
}
