using System.Globalization;
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

namespace Zadanie2
{
    public partial class MainWindow : Window
    {
        private string currentOperation = string.Empty;
        private double result = 0;
        private bool isOperationPerformed = false;

        public MainWindow()
        {
            InitializeComponent();
            CurrentOperationLabel.Text = "0";
        }

        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentOperationLabel.Text == "0" || isOperationPerformed)
                CurrentOperationLabel.Text = string.Empty;

            isOperationPerformed = false;
            Button button = (Button)sender;
            CurrentOperationLabel.Text += button.Content.ToString();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperationLabel.Text = "0";
            PreviousOperationLabel.Text = "";
            result = 0;
            currentOperation = string.Empty;
        }

        private void ClearEntry_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperationLabel.Text = "0";
            result = 0;
            currentOperation = string.Empty;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string newOperation = button.Content.ToString();

            if (isOperationPerformed)
            {
                CurrentOperationLabel.Text = result.ToString(CultureInfo.InvariantCulture);
                isOperationPerformed = false;
            }

            if (!string.IsNullOrEmpty(currentOperation))
            {
                Equals_Click(sender, e);
                CurrentOperationLabel.Text = result.ToString(CultureInfo.InvariantCulture);
            }

            if (!string.IsNullOrEmpty(CurrentOperationLabel.Text))
            {
                result = double.Parse(CurrentOperationLabel.Text, CultureInfo.InvariantCulture);
                currentOperation = newOperation;
                CurrentOperationLabel.Text += " " + currentOperation + " ";
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] tokens = CurrentOperationLabel.Text.Split(' ');
                if (tokens.Length < 3)
                    return;

                double operand1 = double.Parse(tokens[0], CultureInfo.InvariantCulture);
                string operation = tokens[1];
                double operand2 = double.Parse(tokens[2], CultureInfo.InvariantCulture);

                switch (operation)
                {
                    case "+":
                        result = operand1 + operand2;
                        break;
                    case "-":
                        result = operand1 - operand2;
                        break;
                    case "*":
                        result = operand1 * operand2;
                        break;
                    case "/":
                        result = operand1 / operand2;
                        break;
                    case "%":
                        result = operand1 * (operand2 / 100.0);
                        break;
                    case "^":
                        result = Math.Pow(operand1, operand2);
                        break;
                }
                PreviousOperationLabel.Text = $"{operand1} {operation} {operand2} = {result.ToString(CultureInfo.InvariantCulture)}";
                CurrentOperationLabel.Text = result.ToString(CultureInfo.InvariantCulture);
                currentOperation = string.Empty;
                isOperationPerformed = true;
            }
            catch (FormatException)
            {
                CurrentOperationLabel.Text = "Error";
            }
        }

        private void UnaryOperator_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Content.ToString();
            if (double.TryParse(CurrentOperationLabel.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
            {
                switch (operation)
                {
                    case "√":
                        result = Math.Sqrt(value);
                        PreviousOperationLabel.Text = $"{operation}{value} = {result.ToString(CultureInfo.InvariantCulture)}";
                        break;
                    case "1/x":
                        result = (1 / value);
                        PreviousOperationLabel.Text = $"1/{value} = {result.ToString(CultureInfo.InvariantCulture)}";
                        break;
                    case "log":
                        result = Math.Log10(value);
                        PreviousOperationLabel.Text = $"log({value}) = {result.ToString(CultureInfo.InvariantCulture)}";
                        break;
                    case "⌊⌋":
                        result = Math.Floor(value);
                        PreviousOperationLabel.Text = $"⌊{value}⌋ = {result.ToString(CultureInfo.InvariantCulture)}";
                        break;
                    case "⌈⌉":
                        result = Math.Ceiling(value);
                        PreviousOperationLabel.Text = $"⌈{value}⌉ = {result.ToString(CultureInfo.InvariantCulture)}";
                        break;
                    case "!":
                        result = Factorial(value);
                        PreviousOperationLabel.Text = $"{value}! = {result.ToString(CultureInfo.InvariantCulture)}";
                        break;
                }
                CurrentOperationLabel.Text = result.ToString(CultureInfo.InvariantCulture);
                isOperationPerformed = true;
            }
            else
            {
                CurrentOperationLabel.Text = "Error";
            }
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!CurrentOperationLabel.Text.Contains("."))
                CurrentOperationLabel.Text += ".";
        }

        private double Factorial(double value)
        {
            if (value == 0)
                return 1;
            double result = 1;
            for (int i = 1; i <= value; i++)
            {
                result *= i;
            }
            return result;
        }

        private void ChangeSign_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentOperationLabel.Text == "0" || CurrentOperationLabel.Text == "")
                return;

            if (double.TryParse(CurrentOperationLabel.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
            {
                value *= -1;
                CurrentOperationLabel.Text = value.ToString(CultureInfo.InvariantCulture);
                result = value;
                isOperationPerformed = true;
            }
        }
    }
}