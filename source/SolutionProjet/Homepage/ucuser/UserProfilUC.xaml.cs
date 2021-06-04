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
using Management;

namespace Homepage.ucuser
{
    /// <summary>
    /// Logique d'interaction pour UserProfilUC.xaml
    /// </summary>
    public partial class UserProfilUC : UserControl
    {
        public Listes List => (App.Current as App).LeManager.CurrentList;
        public Manager Manager => (App.Current as App).LeManager;
        private UCModifCorpulence ucm = new UCModifCorpulence();
        
        public UserProfilUC()
        {
            InitializeComponent();
            DataContext = List.UtilisateurCourant;

        }
        /// <summary>
        /// Méthode qui ouvre une nouvelle ModifWindow après l'avoir instancié 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonModifierCorpulence_Click(object sender, RoutedEventArgs e)
        {
            ModifWindow mw = new ModifWindow(ucm);
            mw.ShowDialog();
        }
    }
}
