using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SE_ATM_Prototype
{
	/// <summary>
	/// Interaction logic for SelectionWindow.xaml
	/// </summary>
	public partial class SelectionWindow : Window
	{
        Bank bank;
		public SelectionWindow(Bank b)
		{
            bank = b;
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void DepButton_Click(object sender, RoutedEventArgs e)
        {
            String amt = DepAmt.GetLineText(0);
            try
            {
                double amount = Convert.ToDouble(amt);
                bank.CurrentUser.Balance += amount;
                MessageBox.Show("$" + String.Format("{0:N2}", amount) + " deposited into account.");
            }
            catch
            {
                MessageBox.Show("Enter a valid amount.");
            }
        }

        private void BalButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(String.Format("{0:N2}", bank.currentBalance()));
        }

        private void WithButton_Click(object sender, RoutedEventArgs e)
        {
            String amt = WithAmt.GetLineText(0);
            try
            {
                double amount = Convert.ToDouble(amt);
                if(bank.withdraw(amount))
                {
                    MessageBox.Show("$" + String.Format("{0:N2}", amount) + " withdrawn from account.");
                }
            }
            catch
            {
                MessageBox.Show("Enter a valid amount.");
            }
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            bank.endSession();
            WelcomeScreen ws = new WelcomeScreen(bank);
            ws.Show();
            this.Close();
        }
	}
}