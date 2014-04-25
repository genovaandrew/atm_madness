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

        }

        private void BalButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(String.Format("{0:N2}", bank.currentBalance()));
        }

        private void WithButton_Click(object sender, RoutedEventArgs e)
        {
            bank.withdraw(80.0);
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            bank.endSession();
            this.Close();
        }
	}
}