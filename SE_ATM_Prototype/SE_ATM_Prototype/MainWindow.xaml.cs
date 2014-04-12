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
	/// Interaction logic for mainWindow.xaml
	/// </summary>
	public partial class mainWindow : Window
	{
		public mainWindow()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}
		
		private void test_Method(object sender, RoutedEventArgs e)
		{
			WelcomeScreen ws = new WelcomeScreen();
			ws.Show();
			this.Close();
		}
	}
}