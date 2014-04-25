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
	/// Interaction logic for WelcomeScreen.xaml
	/// </summary>
	public partial class WelcomeScreen : Window
	{
        Bank bank;
        int lockCount; //variable used to count incorrect PIN entries. Card will be swallowed after 3 attempts

		public WelcomeScreen(Bank b)
		{
            bank = b;
            lockCount = 0;
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}
		
		private void ok_click(object sender, RoutedEventArgs e)
		{
			SelectionWindow sw = new SelectionWindow(bank);
            String name = User.GetLineText(0);
            String pinno = Pin.GetLineText(0);

            try
            {
                int pin = Convert.ToInt32(pinno);
                if (bank.startSession(name, pin))
                {
                    sw.Show();
                    this.Close();
                }
                else
                {
                    lockCount++;
                    if(lockCount<4)
                    {
                        MessageBox.Show("Invalid PIN.");
                    }
                    else
                    {
                        MessageBox.Show("Too many invalid PINs. Machine will now eat card.");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Enter a valid pin number.");
            }
		}

        private void exit_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
	}
}