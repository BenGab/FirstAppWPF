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

namespace FirstAPPWPF
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

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            Stack<char> AmpersandStack = new Stack<char>();
            string s = "({[";
            string s2 = ")]}";

            foreach(char item in tbInput.Text)
            {
                if(s.Contains(item))
                {
                    AmpersandStack.Push(item);
                    continue;
                }

                if(s2.Contains(item))
                {
                    char lastItem = AmpersandStack.Pop();
                    if(!ValidAmpersand(item, lastItem))
                    {
                        MessageBox.Show("Invalid string");
                        e.Handled = true;
                        return;
                    }
                }
            }

            MessageBox.Show(AmpersandStack.Count == 0 ? "Valid" : "Invalid");
        }

        private bool ValidAmpersand(char item, char item2)
        {
            if(item == ')' && item2 == '(')
            {
                return true;
            }

            if (item == ']' && item2 == '[')
            {
                return true;
            }

            if (item == '}' && item2 == '{')
            {
                return true;
            }

            return false;
        }
    }
}
