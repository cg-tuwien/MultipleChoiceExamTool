using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FileHelpers;
using McExamTool.Commands;
using McExamTool.Model;
using McExamTool.Utils;

namespace McExamTool.ViewModel
{
    enum ExamState
    {
        Start,
        Questions,
        Finished
    }

    class MainViewModel : BindableBase
    {
        private ExamState _examState = ExamState.Start;
        public ExamState ExamState
        {
            get => _examState;
            set => SetProperty(ref _examState, value);
        } 

        public SetupData SetupData { get; } = new SetupData();

        private ResultData _resultData;

        public ResultData ResultData
        {
            get => _resultData;
            set => SetProperty(ref _resultData, value);
        }

        private QuestionAndAnswers _currentQuestion;

        public QuestionAndAnswers CurrentQuestion
        {
            get => _currentQuestion;
            set => SetProperty(ref _currentQuestion, value);
        }

        private string _csvDirectory;
        private QuestionFromCsv[] _allQuestions;
        private int _curQuestionIndex;
        private List<QuestionAndAnswers> _selectedQuestions;

        public ICommand StartCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand NextCommand { get; }
        public ICommand StoreResultsCommand { get; }

        public MainViewModel()
        {
            StartCommand = new DelegateCommand(_ =>
            {
                try
                {
                    // Get the directory info for image loading
                    var finfo = new FileInfo(SetupData.PathToCsvFile);
                    _csvDirectory = finfo.DirectoryName;

                    // load the csv
                    var engine = new FileHelperEngine<QuestionFromCsv>();
                    _allQuestions = engine.ReadFile(SetupData.PathToCsvFile);

                    // select a bunch of questions (first row in csv contains headers)
                    var allIndices = Combinatorics.CreateIntSequence(1, _allQuestions.Length - 1);
                    allIndices.ShuffleInPlace();
                    _selectedQuestions = new List<QuestionAndAnswers>();
                    for (int i = 0; i < SetupData.NumQuestionsToAsk; ++i)
                    {
                        var inp = _allQuestions[allIndices[i]];
                        _selectedQuestions.Add(new QuestionAndAnswers
                        {
                            Question = inp.Question,
                            IsAnswer1Selected = false,
                            Answer1 = inp.Answer1,
                            IsAnswer2Selected = false,
                            Answer2 = inp.Answer2,
                            IsAnswer3Selected = false,
                            Answer3 = inp.Answer3,
                            IsAnswer4Selected = false,
                            Answer4 = inp.Answer4,
                            IsAnswer5Selected = false,
                            Answer5 = inp.Answer5,
                            PathToImage = Path.Combine(_csvDirectory, inp.Image),
                            CorrectAnswer = inp.CorrectAnswers
                        });
                    }

                    _curQuestionIndex = 0;
                    CurrentQuestion = _selectedQuestions[_curQuestionIndex];
                    ExamState = ExamState.Questions;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                FireAllCanExecuteChanged();
            }, _ => _examState == ExamState.Start);

            BackCommand = new DelegateCommand(_ =>
            {
                if (_curQuestionIndex == 0)
                {
                    ExamState = ExamState.Start;
                }
                else
                {
                    _curQuestionIndex--;
                    CurrentQuestion = _selectedQuestions[_curQuestionIndex];
                }
                FireAllCanExecuteChanged();
            }, _ => _examState == ExamState.Questions);

            NextCommand = new DelegateCommand(_ =>
            {
                if (_curQuestionIndex == _selectedQuestions.Count - 1)
                {
                    ResultData = new ResultData
                    {
                        StudentFirstName = SetupData.StudentFirstName,
                        StudentLastName = SetupData.StudentLastName,
                        StudentMatriculationNumber = SetupData.StudentMatriculationNumber,
                        NumQuestionsAsked = _selectedQuestions.Count,
                        NumCorrectAnswers = _selectedQuestions.Count(x => x.CorrectAnswer == x.StudentsAnswer)
                    };
                    ResultData.NumCorrectPercent = ResultData.NumCorrectAnswers / (double)ResultData.NumQuestionsAsked;
                    ExamState = ExamState.Finished;
                }
                else
                {
                    _curQuestionIndex++;
                    CurrentQuestion = _selectedQuestions[_curQuestionIndex];
                }
                FireAllCanExecuteChanged();
            }, _ => _examState == ExamState.Questions);

            StoreResultsCommand = new DelegateCommand(_ =>
            {
                try
                {
                    if (File.Exists(ResultData.ResultsSavePath))
                    {
                        var choice = MessageBox.Show("The file already exists. Overwrite?", "Overwrite?", MessageBoxButton.YesNo);
                        if (choice == MessageBoxResult.No)
                        {
                            return;
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(ResultData.ResultsSavePath))
                    {
                        writer.WriteLine($"Multiple-Choice Exam held at {DateTime.Now}");
                        writer.WriteLine($"Student: {ResultData.StudentFirstName} {ResultData.StudentLastName}");
                        writer.WriteLine($"Matriculation number: {ResultData.StudentMatriculationNumber}");
                        writer.WriteLine("");
                        writer.WriteLine("");

                        writer.WriteLine("----------------- Asked Questions:");
                        writer.WriteLine("");
                        foreach (var qa in _selectedQuestions)
                        {
                            writer.WriteLine($"Question: {qa.Question}");
                            writer.WriteLine($"Answer 1: {qa.Answer1}");
                            writer.WriteLine($"Answer 2: {qa.Answer2}");
                            writer.WriteLine($"Answer 3: {qa.Answer3}");
                            writer.WriteLine($"Answer 4: {qa.Answer4}");
                            writer.WriteLine($"Answer 5: {qa.Answer5}");
                            writer.WriteLine($"Correct Answer:   {qa.CorrectAnswer}");
                            writer.WriteLine($"Student's Answer: {qa.StudentsAnswer}");
                            writer.WriteLine($"Is Correct:       {qa.CorrectAnswer == qa.StudentsAnswer}");
                            writer.WriteLine("");
                        }
                        writer.WriteLine("");

                        writer.WriteLine("----------------- Result:");
                        writer.WriteLine("");
                        writer.WriteLine($"Number of questions asked:   {ResultData.NumQuestionsAsked}");
                        writer.WriteLine($"Thereof correctly answered:  {ResultData.NumCorrectAnswers}");
                        writer.WriteLine($"Correct answers in per-cent: {ResultData.NumCorrectPercent:P0}");
                        writer.WriteLine("");
                    }

                    MessageBox.Show($"Results saved to {ResultData.ResultsSavePath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                FireAllCanExecuteChanged();
            }, _ => _examState == ExamState.Finished);
        }
    }
}
