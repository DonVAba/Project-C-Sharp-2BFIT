using Application;
using Management;
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

namespace Homepage.ucmodification
{
    /// <summary>
    /// Logique d'interaction pour UCModifProg.xaml
    /// </summary>
    public partial class UCModifProg : UserControl
    {
        public Listes List => (App.Current as App).LeManager.CurrentList;
        public Manager Manager => (App.Current as App).LeManager;
        public UCModifProg()
        {
            InitializeComponent();
            DataContext = List;
        }
        /// <summary>
        /// Méthode qui ferme UCModifProg quand on clique sur le bouton annuler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        /// <summary>
        /// Méthode qui sauvegarde les nouvelles données rentrées après avoir cliquer sur le bouton sauvegarder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, RoutedEventArgs e) 
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(newName.Text))//Vérification que le nom n'est pas nul
                {
                    List.ProgrammeChoisi.Nom = newName.Text;//Set le nom
                }

                if (!string.IsNullOrWhiteSpace(newDesc.Text))//Vérification que la description n'est pas nulle 
                {
                    List.ProgrammeChoisi.Description = newDesc.Text;//Set la description 
                }
                Manager.SauvegardeDonnees();//Appel de la méthode SauvegardeDonnes du Manager
                Window.GetWindow(this).Close();//Ferme la window 
            }
            catch (Exception)
            {
                MessageBox.Show("Mauvaises valeurs rentrées, veuillez réessayer", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }
     }
 }
    

