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
using Application;
using Homepage.ucmodification;

namespace Homepage.ucadmin
{
    /// <summary>
    /// Logique d'interaction pour AdminProfilUC.xaml
    /// </summary>
    public partial class AdminProfilUC : UserControl
    {
        public Listes List => (App.Current as App).List;
        private UCModifCorpulence ucm = new UCModifCorpulence();
        public AdminProfilUC()
        {
            InitializeComponent();
            //List.UtilisateurCourant.DernierProgramme = List.ListProgrammes.First();
            //List.UtilisateurCourant.DiffDernierProg = Difficulte.DEBUTANT;
            DataContext = List.UtilisateurCourant;
        }

        private void ButtonModifierCorpulence_Click(object sender, RoutedEventArgs e)
        {
            ModifWindow mdc = new ModifWindow(ucm);
            mdc.ShowDialog();
        }
    }
}
