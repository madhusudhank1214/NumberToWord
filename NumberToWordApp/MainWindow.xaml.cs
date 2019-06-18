using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NumberToWordApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private string _resultText;
        public string ResultText
        {
            get { return _resultText; }
            set
            {
                _resultText = value;
                OnPropertyChanged("ResultText");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                var e = new PropertyChangedEventArgs("prop");
                handler(this, e);
            }
        }
        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int _givenNumber = 0;
                lblResult.Content = string.Empty;
                lblResult.Foreground = Brushes.Black;
                if (!string.IsNullOrEmpty(txtNumberValue.Text))
                {
                    _givenNumber = Convert.ToInt32(txtNumberValue.Text);
                    var resultWord = NumberToWords(_givenNumber);
                    ResultText = resultWord;
                    lblResult.Content = resultWord;
                }
                else
                {
                    lblResult.Content = "Please Enter NumericValue:";
                    lblResult.Foreground= Brushes.Red;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        public static string NumberToWords(int number)
        {
            string words = "";

            try
            {
                if (number == 0)
                    return "zero";

                if (number < 0)
                    return "minus " + NumberToWords(Math.Abs(number));


                if ((number / 1000000) > 0)
                {
                    words += NumberToWords(number / 1000000) + " million ";
                    number %= 1000000;
                }

                if ((number / 1000) > 0)
                {
                    words += NumberToWords(number / 1000) + " thousand ";
                    number %= 1000;
                }

                if ((number / 100) > 0)
                {
                    words += NumberToWords(number / 100) + " hundred ";
                    number %= 100;
                }

                if (number > 0)
                {
                    if (words != "")
                        words += "and ";

                    var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                    var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                    if (number < 20)
                        words += unitsMap[number];
                    else
                    {
                        words += tensMap[number / 10];
                        if ((number % 10) > 0)
                            words += "-" + unitsMap[number % 10];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return words;
            }
            return words;
        }
    }
}
