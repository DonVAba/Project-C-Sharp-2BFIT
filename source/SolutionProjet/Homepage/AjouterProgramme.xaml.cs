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
    /// Logique d'interaction pour AjouterProgramme.xaml
    /// </summary>
    public partial class AjouterProgramme : Window
    {
        private Navigator Nav => (App.Current as App).Navigator;
        private Listes List => (App.Current as App).List;

        public AjouterProgramme()
        {
            InitializeComponent();
            DataContext = Nav;
            Nav.NavigateTo("UC_AjoutProg");
        }

    }
}
