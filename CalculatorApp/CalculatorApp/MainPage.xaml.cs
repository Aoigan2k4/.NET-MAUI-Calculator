using System.Diagnostics;
using System.Data;

namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {
        string currentInput = string.Empty;
        string equation = string.Empty;
        float value;
        public MainPage()
        {
            InitializeComponent();
            Output.Text = string.Empty;
            Equation.Text = string.Empty;
        }

        //Works
        private void Clear_Clicked(object sender, EventArgs e)
        {
            Output.Text = string.Empty;
            Equation.Text = string.Empty;
            currentInput = string.Empty;
            equation = string.Empty;
        }

        //Error
        private void Fraction_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                value = 1 / float.Parse(currentInput);
                currentInput = Convert.ToString(value);
                equation += currentInput;
                Equation.Text = currentInput;
                Output.Text = currentInput;
            }
        }

        //Error
        private void Percent_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                value = float.Parse(currentInput) / 100;
                currentInput = Convert.ToString(value);
                equation += currentInput;

                Equation.Text = currentInput;
                Output.Text = currentInput;
            }
        }

        //works
        private void Negative_Clicked(object sender, EventArgs e)
        {
            value = 0;
        
            if (!currentInput.Contains("-") && !string.IsNullOrEmpty(equation))
            {
                //value -= value * 2;
                value = float.Parse("-" + currentInput);
                currentInput = Convert.ToString(value);
            }
            else
            {
                currentInput = Convert.ToString(Math.Abs(value));
            }
            equation += currentInput;
            Equation.Text = currentInput;
            Output.Text = currentInput;
        }

        //Works
        private void Decimal_Clicked(object sender, EventArgs e)
        {
           
            currentInput += ".";
            
            equation += currentInput;
            Equation.Text = currentInput;
            Output.Text = currentInput;
        }

        //Works
        private void Numbers_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                currentInput += button.Text;
                equation = currentInput;
                Equation.Text = equation;
                Output.Text = equation;
            }
        }

        //Works
        private void Operators_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (!string.IsNullOrEmpty(equation))
                {
                    currentInput += button.Text;
                    equation = currentInput;
                    Equation.Text = equation;
                    Output.Text = equation;
                }
            }
        }

        //Works
        private void Equals_Clicked(object sender, EventArgs e)
        {  
            if (string.IsNullOrEmpty(equation))
                return;

            equation = Output.Text;
            var result = new DataTable().Compute(equation, null); ;

            Output.Text = result.ToString();
            Equation.Text = equation + " = ";
            currentInput = string.Empty;
        }
    }
}
