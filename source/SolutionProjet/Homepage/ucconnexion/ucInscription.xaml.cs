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
using Management;

namespace Homepage.ucconnexion
{
    /// <summary>
    /// Logique d'interaction pour ucInscription.xaml
    /// </summary>
    public partial class ucInscription : UserControl
    {
        public Listes List => (App.Current as App).LeManager.CurrentList;
        public Manager Manager => (App.Current as App).LeManager;
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

        public ucInscription()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Méthode qui change le background du bouton lorsque sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FFFFFFFF");
            var bru = (Brush)converter.ConvertFromString("#FF6495ED");
            b.Foreground = brush;
            b.Background = bru;
        }
        /// <summary>
        /// Méthode qui change l'aspect du bouton lorsqu'il n'est plus survolé par la souris 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FFFFFFFF");
            var bru = (Brush)converter.ConvertFromString("#FF6495ED");
            b.Foreground = bru;
            b.Background = brush;
        }

        /// <summary>
        /// Méthode qui permet de naviguer au UC "UC_Connexion" via la méthode NavigateTo du Navigator 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ConnexionButton_Click(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo("UC_Connexion");
        }
        /// <summary>
        /// Méthode qui vérifie que les données rentrées sont correctes quand on clique sur le bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsButton_Click(object sender, RoutedEventArgs e)
        {
            if(List.RechercherUtilisateur(idSignIn.Text) != null)//Vérification que l'utilisateur n'existe pa déjà avec la méthode RechercheUtilisateur de Liste
            {
                MessageBox.Show("Identifiant déjà utilisé", "Login invalide", MessageBoxButton.OK, MessageBoxImage.Error);//Affichage MessageBox pour l'utilisateur
            }
            else//Sinon, création d'un nouvel utilisateur 
            {
                try
                {
                    Utilisateur userTestSignIn = new Utilisateur(nomSignIn.Text, prenomSignIn.Text, naissanceSignIn.SelectedDate ?? DateTime.Now, Int16.Parse(tailleSignIn.Text), float.Parse(poidsSignIn.Text), idSignIn.Text, mdpSignIn.Password);
                    if (!CreationObjectValidator.ValidationAjoutUser(userTestSignIn))//Vérification que les données du nouvel utilsateur sont valides
                    {
                        MessageBox.Show("Paramètres rentrés invalides", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);//Affichage MessageBox
                    }
                    else//Si les données sont valides, on ajoute le nouvel utilisateur
                    {
                        
                        MessageBox.Show("Bienvenue sur votre application 2BFIT", "Inscription réussie", MessageBoxButton.OK, MessageBoxImage.Information);//Affichage MessageBox
                        Manager.AjouterUtilisateurInscription(userTestSignIn);//Appel de la méthode AjouterUtilisateur de Manager 
                        Manager.SauvegardeDonnees();//Appel de la méthode SauvegardeDonnes du Manager pour sauvegarder
                        List.UtilisateurCourant = userTestSignIn;//Set l'utilisateur courant sur le nouvel utilisateur crée
                        MainWindow mw = new MainWindow();//instancie une nouvelle MainWindow puis l'ouvre en fermant la WindowConnexion
                        mw.Show();
                        WindowConnexion.GetWindow(this).Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Paramètres rentrés invalides", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);//Affichage MessageBox
                }
                
            }
        }
    }
}
