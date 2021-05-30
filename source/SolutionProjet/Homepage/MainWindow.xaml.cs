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

        private Listes List => (App.Current as App).List;

        

        private UserControl selectedUserControl = new UserControl();
        private UserProgrammeUC ucProg;
        private UserProfilUC ucProfil;


        public MainWindow()
        {
            InitializeComponent();
            selectedUserControl = InitUserControlProfil();
            MainWindowContentControl.Content = selectedUserControl;
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

        private UserProfilUC InitUserControlProfil()
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


        private void listBoxProg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindowContentControl.Content = InitUserControlProg();
            List.ProgrammeChoisi = (sender as ListBox).SelectedItem as Programme;
        }

        private void UserProfilUC_Loaded(object sender, RoutedEventArgs e)
        {
            if (selectedUserControl is UserProfilUC)
            {
                selectedUserControl = InitUserControlProg();
            }
            else
                selectedUserControl = ucProfil;
        }
    }
}
