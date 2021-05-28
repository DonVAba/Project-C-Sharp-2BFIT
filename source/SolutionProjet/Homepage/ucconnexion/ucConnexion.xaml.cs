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
    public partial class ucConnexion : UserControl
    {
        public Navigator Nav => (App.Current as App).Navigator;
        public Listes List => (App.Current as App).List;
        public ucConnexion()
        {
            InitializeComponent();
        }
        public void ConnexionButton_Click(object sender, RoutedEventArgs e)
        {
            if(List.RechercherUtilisateur(idTextBlock.Text) == null)
            {
                    MessageBox.Show("Le pseudo est érroné, veuillez réessayer", "Identifiant invalide", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
                
            }
            else {
                if (idTextBlock.Text.Equals("admin") & mdpTextBox.Password.Equals("admin"))
                {
                    List.UtilisateurCourant = List.RechercherUtilisateur("admin");
                    WindowMainAdmin mw = new WindowMainAdmin();
                    mw.Show();
                    WindowConnexion.GetWindow(this).Close();
                }
                else {
                    if (!Manager.VerifierConnexion(idTextBlock.Text, mdpTextBox.Password, List))
                    {
                        MessageBox.Show("Le mot de passe est érroné, veuillez réessayer", "Mot de passe invalide", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        List.UtilisateurCourant = List.RechercherUtilisateur(idTextBlock.Text);
                        MessageBox.Show("Bienvenue sur votre application 2BFIT, vous êtes connecté", "Connexion réussie", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWindow mw = new MainWindow();
                        mw.Show();
                        WindowConnexion.GetWindow(this).Close();
                    }
                }
            }

            
        }

        private void InscriptionButton_Click(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo("UC_Inscription");
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
