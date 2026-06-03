using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double firstNumber = 0;
        private string operation = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (Display.Text == "0") {
                Display.Text = btn.Content.ToString();
            }
            else {
                Display.Text += btn.Content.ToString();
            }
        }
        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            firstNumber = Convert.ToDouble(Display.Text);
            operation = btn.Content.ToString();
            Display.Text = "0";
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            double secondNumber = Convert.ToDouble(Display.Text);
            double result = 0;

            switch (operation) {
                case "+":
                    result = firstNumber + secondNumber; 
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                    {
                        result = firstNumber / secondNumber;
                    }
                    else
                    {
                        MessageBox.Show("Cannot divide by zero");
                        return;
                    }
                    break;
            }

            Display.Text = result.ToString();
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            firstNumber = 0;
            operation = "";
        }
    }
}