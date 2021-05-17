using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homepage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ModifierCorpulence : Window
    {
        public Listes List => (App.Current as App).List;
        public ModifierCorpulence()
        {
            InitializeComponent();
            DataContext = List;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
           
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List.UtilisateurCourant.Taille = Int16.Parse(newTaille.Text);
                List.UtilisateurCourant.Poids = float.Parse(newPoids.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Mauvaises valeurs rentrées, veuillez réessayer", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
