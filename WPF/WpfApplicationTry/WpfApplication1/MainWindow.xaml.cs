using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          //  MessageBox.Show("You clicked me " );
        }

        private void Mouse_Ennter(object sender, MouseEventArgs e)
        {
          //  MessageBox.Show("You entered me at " + e.GetPosition(this).ToString());
        }

        private void a(object sender, MouseButtonEventArgs e)
        {
            throw new Exception("Global error Handling!");
            MessageBox.Show("You doubleclicked me at " + e.GetPosition(this).ToString());
        }

        private void Button_Click_TextBox(object sender, RoutedEventArgs e)
        {
            TextBoxSample tb = new TextBoxSample();
            tb.Show();
        }
    }
}
