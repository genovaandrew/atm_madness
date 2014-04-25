﻿using System;
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
		public WelcomeScreen(Bank b)
		{
            bank = b;
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}
		
		private void ok_click(object sender, RoutedEventArgs e)
		{
			SelectionWindow sw = new SelectionWindow(bank);
            bank.startSession("Alice");
			sw.Show();
			this.Close();
		}

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            pinBox.Text = string.Empty;
        }

        private void pinBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            pinBox.Text = string.Empty;
        }
	}
}