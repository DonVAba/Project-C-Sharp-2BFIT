using Application;
using Management;
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

namespace Homepage.ucmodification
{
    /// <summary>
    /// Logique d'interaction pour UCModifCorpulence.xaml
    /// </summary>
    public partial class UCModifCorpulence : UserControl
    {
        public Listes List => (App.Current as App).LeManager.CurrentList;
        public Manager Manager => (App.Current as App).LeManager;
        public UCModifCorpulence()
        {
            InitializeComponent();
            DataContext = List.UtilisateurCourant;
        }
        /// <summary>
        /// Méthode qui ferme UCModifCorpulence quand on clique sur le bouton annuler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();

        }
        /// <summary>
        /// Méthode qui sauvegarde les nouvelles données rentrées quand on clique sur le bouton sauvegarder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(newTaille.Text))//Vérification que la taille n'est pas nulle 
                {
                    List.UtilisateurCourant.Taille = Int16.Parse(newTaille.Text);//Set la taille de l'utilisateur courant 
                }
                if (!string.IsNullOrWhiteSpace(newPoids.Text))//Vérification que le poids n'est pas nul
                {
                    List.UtilisateurCourant.Poids = float.Parse(newPoids.Text);//Set le poids de l'utilisateur courant 
                }
                Manager.SauvegardeDonnees();
                Window.GetWindow(this).Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Mauvaises valeurs rentrées, veuillez réessayer", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
