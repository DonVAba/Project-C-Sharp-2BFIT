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

namespace Homepage.ucWindowAjout
{
    /// <summary>
    /// Logique d'interaction pour UCProgramme.xaml
    /// </summary>
    public partial class UCProgramme : UserControl
    {

        public static Navigator Navigator { get; set; } = Navigator.GetInstance();
        public UCProgramme()
        {
            InitializeComponent();
            DataContext = Navigator;
        }

        private void ImportImageButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = @"C:\Users\Public\Pictures";
            dialog.FileName = "Images";
            dialog.DefaultExt = ".jpg | .png | .gif";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;
            }
        }

        private void NextStepButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             try
            {
                if (string.IsNullOrWhiteSpace(newNom.Nom))
                {

                }
                else
                    
                if(string.IsNullOrWhiteSpace)
                Navigator.NavigateTo("UC_AjoutExercice");  // J'aurais besoin que tu m'expliques pour le navigator, il me semblait que ça marchait mercredi pourtant 
            }
            catch (Exception)
            {
                MessageBox.Show("Mauvaises valeurs rentrées, veuillez reesayer", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            */
            Navigator.NavigateTo("UC_AjoutExercice");
        }
    }
}
