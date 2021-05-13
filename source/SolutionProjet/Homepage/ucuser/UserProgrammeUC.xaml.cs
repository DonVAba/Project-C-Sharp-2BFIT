using Application;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homepage.ucuser
{
    /// <summary>
    /// Logique d'interaction pour UserProgrammeUC.xaml
    /// </summary>
    public partial class UserProgrammeUC : UserControl
    {
        public Listes List => (App.Current as App).List;
        public UserProgrammeUC()
        {
            InitializeComponent();
            DataContext = List.ProgrammeChoisi;
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            ExerciceWindow ew = new ExerciceWindow();
            ew.Show();
        }
    }
}
