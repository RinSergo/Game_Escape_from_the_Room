using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Game_Escape_from_the_Room
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        } 

        private static string userName = "Пьер";
        public static string Name { 
            get { return userName; }
            set { userName = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Name = userN.Text;
            GameWindow window = new GameWindow();
            window.Show();
            this.Close();
        }

    }
}
