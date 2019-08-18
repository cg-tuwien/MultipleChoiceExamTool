using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McExamTool.ViewModel
{
    class QuestionAndAnswers : BindableBase
    {
        private string _Question;
        private bool _IsAnswer1Selected;
        private string _Answer1;
        private bool _IsAnswer2Selected;
        private string _Answer2;
        private bool _IsAnswer3Selected;
        private string _Answer3;
        private bool _IsAnswer4Selected;
        private string _Answer4;
        private bool _IsAnswer5Selected;
        private string _Answer5;
        private string _PathToImage;
        private string _CorrectAnswer;

        public string Question
        {
            get => _Question;
            set => SetProperty(ref _Question, value);
        }

        public bool IsAnswer1Selected
        {
            get => _IsAnswer1Selected;
            set => SetProperty(ref _IsAnswer1Selected, value);
        }
        public string Answer1
        {
            get => _Answer1;
            set => SetProperty(ref _Answer1, value);
        }

        public bool IsAnswer2Selected
        {
            get => _IsAnswer2Selected;
            set => SetProperty(ref _IsAnswer2Selected, value);
        }
        public string Answer2
        {
            get => _Answer2;
            set => SetProperty(ref _Answer2, value);
        }

        public bool IsAnswer3Selected
        {
            get => _IsAnswer3Selected;
            set => SetProperty(ref _IsAnswer3Selected, value);
        }
        public string Answer3
        {
            get => _Answer3;
            set => SetProperty(ref _Answer3, value);
        }

        public bool IsAnswer4Selected
        {
            get => _IsAnswer4Selected;
            set => SetProperty(ref _IsAnswer4Selected, value);
        }
        public string Answer4
        {
            get => _Answer4;
            set => SetProperty(ref _Answer4, value);
        }

        public bool IsAnswer5Selected
        {
            get => _IsAnswer5Selected;
            set => SetProperty(ref _IsAnswer5Selected, value);
        }
        public string Answer5
        {
            get => _Answer5;
            set => SetProperty(ref _Answer5, value);
        }

        public string PathToImage
        {
            get => _PathToImage;
            set => SetProperty(ref _PathToImage, value);
        }

        public string CorrectAnswer
        {
            get => _CorrectAnswer;
            set => SetProperty(ref _CorrectAnswer, value);
        }

        public string StudentsAnswer
        {
            get => (IsAnswer1Selected ? "1" : "") 
                 + (IsAnswer2Selected ? "2" : "")
                 + (IsAnswer3Selected ? "3" : "")
                 + (IsAnswer4Selected ? "4" : "")
                 + (IsAnswer5Selected ? "5" : "");
        }
    }
}
