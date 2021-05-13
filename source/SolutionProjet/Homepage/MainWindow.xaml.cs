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
        private UserProgrammeUC ucProg;
        private UserProfilUC ucProfil;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = List;
        }

        private UserProgrammeUC InitUserControlProg()
        {
            if(ucProg == null)
            {
                ucProg = new UserProgrammeUC();
            }
            return ucProg;
        }

        public UserProfilUC InitUserControlProfil()
        {
            if(ucProfil == null)
            {
                ucProfil = new UserProfilUC();
            }
            return ucProfil;
        }

        private void MWButtonProfile_Click(object sender, RoutedEventArgs e)
        {
            MainWindowContentControl.Content = InitUserControlProfil();
        }

        private void MWProgramButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowContentControl.Content = InitUserControlProg();
        }

        private void listBoxProg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindowContentControl.Content = InitUserControlProg();
            //List.ProgrammeChoisi = listBoxProg.SelectedItem as Programme;
            List.ProgrammeChoisi = e.AddedItems[0] as Programme;
        }
    }
}
