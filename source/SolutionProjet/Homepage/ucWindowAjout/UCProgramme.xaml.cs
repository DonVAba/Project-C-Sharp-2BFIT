using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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
using Homepage.converters;
using Management;

namespace Homepage.ucWindowAjout
{
    /// <summary>
    /// Logique d'interaction pour UCProgramme.xaml
    /// </summary>
    public partial class UCProgramme : UserControl
    {
        private Navigator Nav => (App.Current as App).Navigator;
        private Listes List => (App.Current as App).LeManager.CurrentList;
        private bool isLoadedImage;
        private string imagesPath = System.IO.Path.Combine(StringToImage.FilePath, "/imgprogramme/");
        private string nomimage;
        public UCProgramme()
        {
            InitializeComponent();
            DataContext = List;
        }

        private void ImportImageButton_Click(object sender, RoutedEventArgs e) // A Modifier
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = @"C:\Users\Public\Pictures";
            dialog.FileName = "Images";
            dialog.DefaultExt = ".jpg | .png";

            bool? result = dialog.ShowDialog();
            if (result == true)
            {

                FileInfo fi = new FileInfo(dialog.FileName);
                string file = fi.Name;
                int i = 0;
                while (File.Exists(System.IO.Path.Combine(imagesPath, file)))
                {
                    file = $"{fi.Name.Remove(fi.Name.LastIndexOf('.'))}_{i}.{fi.Extension}";
                }
                nomimage = file;
                File.Copy(dialog.FileName, System.IO.Path.Combine(imagesPath, file));
                isLoadedImage = true;
            }
            else
                isLoadedImage = false;
            
        }

        private void NextStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isLoadedImage)
            {
                MessageBox.Show("Erreur : image pas chargée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(nomProg.Text) || string.IsNullOrWhiteSpace(descProg.Text) || string.IsNullOrWhiteSpace(nbExos.Text))
            {
                MessageBox.Show("Mauvaises valeurs rentrées, veuillez réessayer", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                List.NouveauProg = new Programme(nomProg.Text.ToUpper(), descProg.Text, System.IO.Path.Combine(imagesPath,nomimage));
                if(Int32.TryParse(nbExos.Text, out int value)) 
                {
                    List.NouveauProg.SetNbExercices(value);
                    Nav.NavigateTo("UC_AjoutExercice");
                }
                else
                    MessageBox.Show("Nombre d'exercice rentrés incorrect", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);


            }



        }
    }
}
