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
using System.Windows.Shapes;

namespace SmartApp
{
    /// <summary>
    /// Logique d'interaction pour PurshaseWindow.xaml
    /// </summary>
    public partial class PurshaseWindow : Window
    {
        public string price { get; set; }
        public PurshaseWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Event function when purshase windiw is loaded
        /// </summary>
        private void PurshaseWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PriceLabel.Content = $"PRICE : {price}";
            CreditCardNumberTextBox1.Focus();
        }
        /// <summary>
        /// Event function clicking on submit button
        /// </summary>
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            //check textboxes for length
            if( false == CheckTextBoxLength(CreditCardNumberTextBox1) ||
                false == CheckTextBoxLength(CreditCardNumberTextBox2) ||
                false == CheckTextBoxLength(CreditCardNumberTextBox3) ||
                false == CheckTextBoxLength(CreditCardNumberTextBox4) ||
                false == CheckTextBoxLength(CreditCardMonthTextBox)   ||
                false == CheckTextBoxLength(CreditCardYearTextBox)    ||
                false == CheckTextBoxLength(CreditCardCVVTextBox)  )
            {
                return;
            }
            // check Name TextBox
            if(CreditCardNameTextBox.Text.Trim().Trim('\t').Length == 0)
            {
                MessageBox.Show("Length error.", "Error", MessageBoxButton.OK, MessageBoxImage.Error); 
                CreditCardNameTextBox.Focus();
                return;
            }
            // check the date
            DateTime dateTime = DateTime.Now;
            String str = $"{dateTime.Year}{dateTime.Month}";
            if(CreditCardMonthTextBox.Text.CompareTo("12") > 0  ||
                CreditCardMonthTextBox.Text == "00" ||
                str.CompareTo(CreditCardYearTextBox.Text + 
                CreditCardMonthTextBox.Text) > 0 ||
                CreditCardYearTextBox.Text.CompareTo("2100") > 0)
            {
                MessageBox.Show("Date error.", "Error", MessageBoxButton.OK, MessageBoxImage.Error); 
                CreditCardMonthTextBox.Focus();
                return;
            }
            //Confirm paiment
            MessageBox.Show($"Your payment has been accepted, thank you for your purshase. Your credit car will be charged the sum of {price}", "Confirmtion", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
        /// <summary>
        /// Event function on preview text imput to forbide digits insert in textbox
        /// </summary>
        private void NoDigitsTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (ContainsDigit(e.Text))
            {
                e.Handled = true; // Prevent digit input
            }
        }
        private bool ContainsDigit(string text)
        {
            // Use regular expression to check if the input text contains digits
            return System.Text.RegularExpressions.Regex.IsMatch(text, @"\d");
        }
        /// <summary>
        /// check if a textbox has the max number of characters
        /// </summary>
        private bool CheckTextBoxLength(TextBox textBox)
        {
            if(textBox.Text.Length != textBox.MaxLength)
            {
                MessageBox.Show("Length error.", "Error", MessageBoxButton.OK, MessageBoxImage.Error); 
                textBox.Focus();
                return false; 
            }

            return true;
        }
        /// <summary>
        /// Event function on textbox text changed
        /// this function will manage automatic tabulation between fields
        /// </summary>
        private void CreditCardNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Get the TextBox control that raised the TextChanged event.
            TextBox textBox = (TextBox)sender;

            // Get the text in the TextBox control.
            string text = textBox.Text;

            // If the fourth digit has been entered, move the focus to the next TextBox control.
            if (text.Length == 4)
            {
                if(textBox.Name == "CreditCardNumberTextBox1")
                {
                    CreditCardNumberTextBox2.Focus();
                }
                else if (textBox.Name == "CreditCardNumberTextBox2")
                {
                    CreditCardNumberTextBox3.Focus();
                }
                else if (textBox.Name == "CreditCardNumberTextBox3")
                {
                    CreditCardNumberTextBox4.Focus();
                }
                else if (textBox.Name == "CreditCardNumberTextBox4")
                {
                    CreditCardMonthTextBox.Focus();
                }
                else if (textBox.Name == "CreditCardYearTextBox")
                {
                    CreditCardCVVTextBox.Focus();
                }
                
            }
            if (text.Length == 2) 
            {
                if (textBox.Name == "CreditCardMonthTextBox")
                {
                    CreditCardYearTextBox.Focus();
                }
            }
            if (text.Length == 3)
            {
                if (textBox.Name == "CreditCardCVVTextBox")
                {
                    CreditCardNameTextBox.Focus();
                }
            }

        }
        /// <summary>
        /// Event function on textbox text changed
        /// this function will prevent inserting numbers
        /// </summary>
        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!IsTextNumeric(e.Text))
            {
                e.Handled = true; // Prevent non-numeric input
            }
        }

        private bool IsTextNumeric(string text)
        {
            // Use regular expressions to validate if the text is numeric
            return System.Text.RegularExpressions.Regex.IsMatch(text, "^[0-9]+$");
        }
    }
}
