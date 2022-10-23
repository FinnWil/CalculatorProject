using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
 
namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private decimal firstNumber;
        private string operatorName;
        private bool isOperatorClicked;

        private void Common_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (lblResult.Text == "0"||isOperatorClicked)
            {
                isOperatorClicked = false;
                lblResult.Text = button.Text;
            }
            else
            {
                lblResult.Text += button.Text;
            }

        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            lblResult.Text = "0";
        }

        private void Backspace_Clicked(object sender, EventArgs e)
        {
            string number =lblResult.Text;
            if(number != "0")
            {
                number = number.Remove(number.Length-1, 1);
                if(string.IsNullOrEmpty(number))
                {
                    lblResult.Text = "0";
                }
                else
                {
                    lblResult.Text=number;
                }
            }
        }

        private void CommonOperation_Clicked(Object sender, EventArgs e)
        {
            var button=sender as Button;
            isOperatorClicked = true;
            operatorName = button.Text;
            firstNumber = Convert.ToDecimal(lblResult.Text);
        }

        private async void Percentage_Clicked(object sender, EventArgs e)
        {
            try
            {
                string number= lblResult.Text;
                if (number != "0")
                {
                    decimal percentValue = Convert.ToDecimal(number);
                    string result = (percentValue / 100).ToString("0.##");
                    lblResult.Text = result;    
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            } 
        }

        private void Equals_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal secondNumber =Convert.ToDecimal(lblResult.Text);
                string finalResult = Calculate(firstNumber, secondNumber).ToString("0.##");
                lblResult.Text = finalResult;
            }
            catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public decimal Calculate(decimal firstNumber, decimal secondNumber)
        {
            decimal result = 0;
            if (operatorName == "+")
            {
                result = firstNumber + secondNumber;
            }
            if (operatorName == "-")
            {
                result = firstNumber - secondNumber;
            }
            if (operatorName == "*")
            {
                result = firstNumber * secondNumber;
            }
            if (operatorName == "/")
            {
                result = firstNumber / secondNumber;
            }
            return result;
        }
    }
}
