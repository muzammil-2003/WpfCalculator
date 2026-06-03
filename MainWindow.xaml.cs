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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
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
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key >= Key.D0 && e.Key <= Key.D9) {
                AddDigit((e.Key - Key.D0).ToString());
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) {
                AddDigit((e.Key - Key.NumPad0).ToString());
            }
            else if (e.Key == Key.Add) {
                setOperator("+");
            }
            else if (e.Key == Key.Subtract)
            {
                setOperator("-");
            }
            else if (e.Key == Key.Multiply)
            {
                setOperator("*");
            }
            else if (e.Key == Key.Divide)
            {
                setOperator("/");
            }
            else if (e.Key == Key.Enter)
            {
                Calculate();
            }
            else if (e.Key == Key.Escape)
            {
                ClearAll();
            }
        }


        // Logic Helpers
        private void AddDigit(string digit)
        {
            if (Display.Text == "0")
                Display.Text = digit;
            else
                Display.Text += digit;
        }

        private void setOperator(string op)
        {
            firstNumber = Convert.ToDouble(Display.Text);
            operation = op;
            Display.Text = "0";
        }

        private void Calculate()
        {
            double secondNumber = Convert.ToDouble(Display.Text);
            double result = 0;

            switch (operation)
            {
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

        private void ClearAll()
        {
            Display.Text = "0";
            firstNumber = 0;
            operation = "";
        }
    }
}