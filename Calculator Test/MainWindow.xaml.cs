
using System.Windows;

namespace Calculator_Test;

/// Interaction logic for MainWindow.xaml
public partial class MainWindow : Window
{
    private double _currentValue = 0;
    private double _previousValue = 0;
    private string _currentOperator = string.Empty;
    private bool _operatorPressed = false;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Zero_Click(object sender, RoutedEventArgs e)
    {
        AppendToInput("0");
    }

    private void One_Click(object sender, RoutedEventArgs e)
    {
        AppendToInput("1");
    }

    private void Two_Click(object sender, RoutedEventArgs e)
    {
        AppendToInput("2");
    }

    private void Three_Click(object sender, RoutedEventArgs e)
    {
        AppendToInput("3");
    }

    private void Four_Click(object sender, RoutedEventArgs e)
    {
        AppendToInput("4");
    }

    private void Five_Click(object sender, RoutedEventArgs e)
    {
        AppendToInput("5");
    }

    private void Six_Click(object sender, RoutedEventArgs e)
    {
        AppendToInput("6");
    }

    private void Seven_Click(object sender, RoutedEventArgs e)
    {
        AppendToInput("7");
    }

    private void Eight_Click(object sender, RoutedEventArgs e)
    {
        AppendToInput("8");
    }

    private void Nine_Click(object sender, RoutedEventArgs e)
    {
        AppendToInput("9");
    }

    private void Decimal_Click(object sender, RoutedEventArgs e)
    {
        // Ensure only one decimal point is allowed
        if (!Input.Text.Contains("."))
        {
            AppendToInput(".");
        }
    }

    private void AppendToInput(string value)
    {
        // If an operator was pressed before, start a new number input
        if (_operatorPressed)
        {
            Input.Clear();
            _operatorPressed = false;
        }
        Input.Text += value;
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        // Clear the display and reset values
        _currentValue = 0;
        _previousValue = 0;
        _currentOperator = string.Empty;
        Input.Clear();
    }

    private void Divide_Click(object sender, RoutedEventArgs e)
    {
        SetOperator("/");
    }

    private void Multiply_Click(object sender, RoutedEventArgs e)
    {
        SetOperator("*");
    }

    private void Subtract_Click(object sender, RoutedEventArgs e)
    {
        SetOperator("-");
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        SetOperator("+");
    }

    private void Equal_Click(object sender, RoutedEventArgs e)
    {
        if (_currentOperator != string.Empty)
        {
            Calculate();
            _currentOperator = string.Empty;
        }
    }

    private void SetOperator(string operatorSymbol)
    {
        // If an operator was already pressed, calculate the result before setting a new operator
        if (_currentOperator != string.Empty)
        {
            Calculate();
        }

        _previousValue = double.Parse(Input.Text);
        _currentOperator = operatorSymbol;
        _operatorPressed = true;
    }

    private void Calculate()
    {
        // Try to parse the current value from the input
        double currentValue;
        if (double.TryParse(Input.Text, out currentValue))
        {
            switch (_currentOperator)
            {
                case "+":
                    currentValue = _previousValue + currentValue;
                    break;
                case "-":
                    currentValue = _previousValue - currentValue;
                    break;
                case "*":
                    currentValue = _previousValue * currentValue;
                    break;
                case "/":
                    if (currentValue != 0)
                    {
                        currentValue = _previousValue / currentValue;
                    }
                    else
                    {
                        // Division by zero error
                        Input.Text = "Error";
                        return;
                    }
                    break;
            }
            Input.Text = currentValue.ToString();
            _previousValue = currentValue;
        }
    }
}