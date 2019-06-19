using NumberToText;
using NumberToWordTest;
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
        #region private Variables
        private NumberToWord objnumberToWord;
        #endregion
        public MainWindow()
        {

            InitializeComponent();
            objnumberToWord = new NumberToWord();
            DataContext = this;
        }
        
        #region Properties
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
        #endregion
        
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        
        #region private Methods
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
                    var resultWord = objnumberToWord.NumberToWords(_givenNumber);
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
        #endregion
    }
}
