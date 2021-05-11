using Homepage.ucuser;
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
using Application;
using Persistance;

namespace Homepage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Listes List => (App.Current as App).List;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = List;
        }

        private void MWButtonProfile_Click(object sender, RoutedEventArgs e)
        {
            MainWindowContentControl.Content = new UserProfilUC();
        }

        private void MWProgramButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowContentControl.Content = new UserProgrammeUC();
        }
    }
}
