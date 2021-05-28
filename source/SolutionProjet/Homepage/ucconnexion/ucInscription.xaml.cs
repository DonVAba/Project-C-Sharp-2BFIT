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
using Application;
using Persistance;
using Management;

namespace Homepage.ucconnexion
{
    /// <summary>
    /// Logique d'interaction pour ucInscription.xaml
    /// </summary>
    public partial class ucInscription : UserControl
    {
        public Listes List => (App.Current as App).List;
        public Navigator Nav => (App.Current as App).Navigator;

        /// <summary>
        /// nouveauUtilisateur
        /// </summary>
        private Utilisateur nouveauUtilisateurCourant;

        public Utilisateur NouveauUtilisateurCourant
        {
            get { return nouveauUtilisateurCourant; }
            set
            {
                nouveauUtilisateurCourant = value;
                //OnPropertyChanged();
            }
        }

        /// <summary>
        /// message est connecté qui sert à la méthode ToAffichUtilisateurCourant
        /// </summary>
        private string messageEstInscrit;

        public string MessageEstInscrit
        {
            get { return messageEstInscrit; }
            set
            {
                messageEstInscrit = value;
                // OnPropertyChanged();
            }
        }
        public ucInscription()
        {
            InitializeComponent();
        }

        private void InsButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FFFFFFFF");
            var bru = (Brush)converter.ConvertFromString("#FF6495ED");
            b.Foreground = brush;
            b.Background = bru;
        }

        private void InsButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FFFFFFFF");
            var bru = (Brush)converter.ConvertFromString("#FF6495ED");
            b.Foreground = bru;
            b.Background = brush;
        }

        public void ConnexionButton_Click(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo("UC_Connexion");
        }

        private void InsButton_Click(object sender, RoutedEventArgs e)
        {
            if(List.RechercherUtilisateur(idSignIn.Text) != null)
            {
                MessageBox.Show("Identifiant déjà utilisé", "Login invalide", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    Utilisateur userTestSignIn = new Utilisateur(nomSignIn.Text, prenomSignIn.Text, naissanceSignIn.SelectedDate ?? DateTime.Now, Int16.Parse(tailleSignIn.Text), float.Parse(poidsSignIn.Text), idSignIn.Text, mdpSignIn.Password);
                    if (!Management.CreationObjectValidator.ValidationAjoutUser(userTestSignIn))
                    {
                        MessageBox.Show("Paramètres rentrés invalides", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        
                        MessageBox.Show("Bienvenue sur votre application 2BFIT", "Inscription réussie", MessageBoxButton.OK, MessageBoxImage.Information);
                        Manager.AjouterUtilisateurInscription(userTestSignIn, List);
                        List.UtilisateurCourant = userTestSignIn;
                        MainWindow mw = new MainWindow();
                        mw.Show();
                        WindowConnexion.GetWindow(this).Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Paramètres rentrés invalides", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }
    }
}
