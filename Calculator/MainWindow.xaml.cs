using System;
using System.Collections.Generic;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        double num1 = double.NaN;
        double num2 = double.NaN;
        Func<double, double, double> OperandOperation;
        char decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

        private void NumberInput_Click(object sender, RoutedEventArgs e)
        {
            string bntCOntent = ((Button)sender).Content.ToString();
            if (tbInput.Text == "0")
            {
                tbInput.Text = bntCOntent;
            }
            else
            {
                tbInput.Text += bntCOntent;
            }
        }

        private void Operand_Click(object sender, RoutedEventArgs e)
        {
            string bntCOntent = ((Button)sender).Content.ToString();
            switch (bntCOntent)
            {
                case "+":
                    OperandOperation = (item1, item2) => item1 + item2;
                    break;

                case "-":
                    OperandOperation = (item1, item2) => item1 - item2;
                    break;

                case "*":
                    OperandOperation = (item1, item2) => item1 * item2;
                    break;

                case "/":
                    OperandOperation = (item1, item2) => item1 / item2;
                    break;
            }

            if (double.IsNaN(num1))
            {
                num1 = double.Parse(tbInput.Text);
            }
            else
            {
                num2 = double.Parse(tbInput.Text);
            }

            tbInput.Text = "0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (double.IsNaN(num2))
            {
                num2 = double.Parse(tbInput.Text);
            }

            tbInput.Text = OperandOperation(num1, num2).ToString();

            num1 = double.NaN;
            num2 = double.NaN;
            OperandOperation = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(tbInput.Text.Contains(decSep))
            {
                e.Handled = true;
                return;
            }

            tbInput.Text += decSep;
        }
    }
}
