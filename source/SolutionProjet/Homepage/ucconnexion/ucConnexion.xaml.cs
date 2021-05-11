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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Homepage.ucconnexion
{
    /// <summary>
    /// Logique d'interaction pour ucConnexion.xaml
    /// </summary>
    public partial class ucConnexion : UserControl , INotifyPropertyChanged
    {

        public Listes List => (App.Current as App).List;

        public static Navigator Navigator => Navigator.GetInstance();

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
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// message est connecté qui sert à la méthode ToAffichUtilisateurCourant
        /// </summary>
        private string messageEstConnecté;

        public event PropertyChangedEventHandler PropertyChanged;

        public string MessageEstConnecté
        {
            get { return messageEstConnecté; }
            set
            {
                messageEstConnecté = value;
                OnPropertyChanged();
            }
        }
        public ucConnexion()
        {
            InitializeComponent();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ConnexionButton_Click(object sender, RoutedEventArgs e)
        {
            if(List.RechercherUtilisateur(idTextBlock.Text) == null)
            {
                    MessageBox.Show("Le pseudo est érroné, veuillez réessayer", "Identifiant invalide", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            else {
                if (!Manager.VerifierConnexion(idTextBlock.Text, mdpTextBox.Password, List)) //Si les infos entrées dans l'UC ne correspondent pas à un utilisateur de la ListeUtilisateur de GameLib
                {
                    MessageBox.Show("Le mot de passe est érroné, veuillez réessayer", "Mot de passe invalide", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    List.UtilisateurCourant = List.RechercherUtilisateur(idTextBlock.Text);
                    Window.GetWindow(this).Close();
                    MessageBoxResult result = MessageBox.Show("Bienvenue sur votre application 2BFIT, vous êtes connecté", "Connexion réussie", MessageBoxButton.OK, MessageBoxImage.Information);
                    if(List.UtilisateurCourant is Admin)
                    {
                        WindowMainAdmin mw = new WindowMainAdmin();
                        mw.Show();
                    }
                    else
                    {
                        MainWindow mw = new MainWindow();
                        mw.Show();
                    }
                }
            }

            
        }

        /// <summary>
        /// Event pour le navigateur permettant de renvoyer sur l'UC CreationCompte
        /// </summary>
        public event RoutedEventHandler PremièreConnexionClick
        {
            add
            {
                ConnexionButton.Click += value;
            }
            remove
            {
                ConnexionButton.Click -= value;
            }
        }


        private void ConnexionButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FFFFFFFF");
            var bru = (Brush)converter.ConvertFromString("#FF6495ED");
            b.Foreground = brush;
            b.Background = bru;
        }

        private void InscriptionButton_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo("UC_Inscription");
        }
    }
}
