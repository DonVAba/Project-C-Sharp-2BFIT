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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Homepage.ucconnexion
{
    /// <summary>
    /// Logique d'interaction pour ucConnexion.xaml
    /// </summary>
    public partial class ucConnexion : UserControl
    {
        public Navigator Nav => (App.Current as App).Navigator;
        public Manager Manager => (App.Current as App).LeManager;
        public Listes List => (App.Current as App).LeManager.CurrentList;
        public ucConnexion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Méthode Connexion quand on clique sur le bouton "ConnexionButton"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ConnexionButton_Click(object sender, RoutedEventArgs e)
        {
            if(List.RechercherUtilisateur(idTextBlock.Text) == null)//Appel de la méthode RechercherUtilisateur de Listes, si elle renvoie null, l'utilisateur n'est pas présent dans la liste
            {
                    MessageBox.Show("Le pseudo est érroné, veuillez réessayer", "Identifiant invalide", MessageBoxButton.OK, MessageBoxImage.Error);//Affichage d'une  messageBox pour l'utilisateur
            }
            else {
                if (idTextBlock.Text.Equals("admin") & mdpTextBox.Password.Equals("admin")) //Vérification que l'identifiant+le passwd rentré dans les textblock= "admin"
                {
                    List.UtilisateurCourant = List.RechercherUtilisateur("admin");//Set l'utilisateur courant avec l'identifiant+password que RechercherUtilisateur renvoie
                    WindowMainAdmin mw = new WindowMainAdmin();//Instancie une nouvelle WindowMainAdmin
                    mw.Show();//Ouvre la WindowMainAdmin
                    WindowConnexion.GetWindow(this).Close();//Ferme la WindowConnexion après avoir ouvert la WindowMainAdmin
                }
                else {
                    if (!Manager.VerifierConnexion(idTextBlock.Text, mdpTextBox.Password))//Si VerifierConnexion renvoie false, on affiche une MessageBox
                    {
                        MessageBox.Show("Le mot de passe est érroné, veuillez réessayer", "Mot de passe invalide", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else //Sinon on set l'utilisateurCourant avec l'identifiant et le mdp que RechercherUtilisateur renvoie 
                    {
                        List.UtilisateurCourant = List.RechercherUtilisateur(idTextBlock.Text);
                        MessageBox.Show("Bienvenue sur votre application 2BFIT, vous êtes connecté", "Connexion réussie", MessageBoxButton.OK, MessageBoxImage.Information);
                        WindowConnexion.GetWindow(this).Hide();//On ferme la fenêtre WindowConnexion
                        MainWindow mw = new MainWindow();//Instancie une nouvelle MainWindow 
                       
                        mw.Show();//Ouvre la nouvelle MainWindow
                        
                    }
                }
            }

            
        }
        /// <summary>
        /// Méthode qui navigue au UserControl "UC_Inscription" via le navigator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InscriptionButton_Click(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo("UC_Inscription");
        }

        /// <summary>
        /// Méthode qui change le background du bouton lorsque sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnexionButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FFFFFFFF");
            var bru = (Brush)converter.ConvertFromString("#FF6495ED");
            b.Foreground = brush;
            b.Background = bru;
        }

       
        /// <summary>
        /// Change l'aspect du bouton quand la souris n'est plus dessus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnexionButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FFFFFFFF");
            var bru = (Brush)converter.ConvertFromString("#FF6495ED");
            b.Foreground = bru;
            b.Background = brush;
        }
    }
}
