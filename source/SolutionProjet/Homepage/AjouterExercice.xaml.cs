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
using System.Windows.Shapes;
using Homepage.ucWindowAjout;

namespace Homepage
{
    /// <summary>
    /// Logique d'interaction pour AjouterExercice.xaml
    /// </summary>
    public partial class AjouterExercice : Window
    {
        private Navigator Nav => (App.Current as App).Navigator;
        private Listes List => (App.Current as App).LeManager.CurrentList;

        public AjouterExercice()
        {
            InitializeComponent();
            DataContext = Nav;
            Nav.NavigateTo("UC_AjoutExercice");
        }
    }
}
