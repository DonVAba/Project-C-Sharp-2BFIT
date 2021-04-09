using Homepage.ucadmin;
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

namespace Homepage
{
    /// <summary>
    /// Logique d'interaction pour WindowMainAdmin.xaml
    /// </summary>
    public partial class WindowMainAdmin : Window
    {
        public WindowMainAdmin()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ApercuButton_Click(object sender, RoutedEventArgs e)
        {

            AdminContentControl.Content = new ExercicePageUCAdmin();
        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            AdminContentControl.Content = new AdminProfilUC();
        }
    }
}
