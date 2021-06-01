using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Homepage.ucuser
{
    /// <summary>
    /// Logique d'interaction pour UserProfilUC.xaml
    /// </summary>
    public partial class UserProfilUC : UserControl
    {
        public Listes List => (App.Current as App).List;
        private UCModifCorpulence ucm = new UCModifCorpulence();
        
        public UserProfilUC()
        {
            InitializeComponent();
            //List.UtilisateurCourant.DernierProgramme = List.ListProgrammes.First();
            //List.UtilisateurCourant.DiffDernierProg = Difficulte.DEBUTANT;
            DataContext = List.UtilisateurCourant;

        }

        private void ButtonModifierCorpulence_Click(object sender, RoutedEventArgs e)
        {
            ModifWindow mw = new ModifWindow(ucm);
            mw.ShowDialog();
        }
    }
}
