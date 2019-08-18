using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using McExamTool.ViewModel;

namespace McExamTool.Converter
{
    class ExamStateToCollapsedConverter : IValueConverter
    {
        public ExamState VisibleState { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ExamState state = (ExamState) value;
            if (state == VisibleState)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
