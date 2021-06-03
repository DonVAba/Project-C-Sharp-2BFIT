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
using Management;

namespace Homepage.ucWindowAjout
{
    /// <summary>
    /// Logique d'interaction pour UCProgramme.xaml
    /// </summary>
    public partial class UCProgramme : UserControl
    {
        public Navigator Nav => (App.Current as App).Navigator;
        public Listes List => (App.Current as App).LeManager.CurrentList;
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
            dialog.DefaultExt = ".jpg | .png | .gif";

            string filename = "";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                
                string strRegex = @"/?([a-Z]*[0-9]*)*/{1}";
                Regex regEx = new Regex(strRegex);
                if (regEx.IsMatch(dialog.FileName))
                {
                    regEx.Split(dialog.FileName);
                    filename = "/img/imgprogramme/" + dialog.FileName;
                }
                var bitmap = new BitmapImage(new Uri(filename));
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                encoder.QualityLevel = 100;
                using (var stream = new FileStream("", FileMode.Create))
                {
                    encoder.Save(stream);
                }
            }
            
        }

        private void NextStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nomProg.Text) || string.IsNullOrWhiteSpace(descProg.Text) || string.IsNullOrWhiteSpace(nbExos.Text))
            {
                MessageBox.Show("Mauvaises valeurs rentrées, veuillez réessayer", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                List.NouveauProg = new Programme(nomProg.Text.ToUpper(), descProg.Text, "/Image;Component/img/imgfond/background_ciel.jpg");
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
