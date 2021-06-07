using Application;
using Homepage.uctextblock;
using Management;
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
using System.Drawing;
using System.IO;
using Homepage.converters;

namespace Homepage.ucWindowAjout
{
    /// <summary>
    /// Logique d'interaction pour UCExercice.xaml
    /// </summary>
    public partial class UCExercice : UserControl {
        private Listes List => (App.Current as App).LeManager.CurrentList;
        private Manager Manager => (App.Current as App).LeManager;

        private static int i = 0;
        private bool isLoadedImage;
        private string ImagesPath { get; set; }
        public UCExercice()
        {
            InitializeComponent();
            DataContext = List;
        }

        private void ImportImageButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = @"C:\Users\Public\Pictures";
            dialog.FileName = "Images";
            dialog.DefaultExt = ".jpg | .png";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                ImagesPath = dialog.FileName;
                isLoadedImage = true;
            }
            else
                isLoadedImage = false;
        }
     
        private void nextExo_Click(object sender, RoutedEventArgs e)
        {
            if (!isLoadedImage)
            {
                MessageBox.Show("Erreur : image non importé","Erreur", MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            if (i != List.NouveauProg.GetNbExercices())
            {
                try
                {
                    List.NouveauProg.LesExercices.Add(
                        new Exercice(nomNewExo.Text, ImagesPath,
                        new Valeur(seriesdeb.Valeur, repdeb.Valeur, tpsreposdeb.Valeur),
                        new Valeur(seriesint.Valeur, repint.Valeur, tpsreposint.Valeur),
                        new Valeur(seriesexp.Valeur, repexp.Valeur, tpsreposexp.Valeur)));
                    i++;

                }
                catch (Exception)
                {
                    MessageBox.Show("Erreur : valeurs incorrectes", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (i == List.NouveauProg.GetNbExercices())
            {
                i = 0;
                if (List.ProgrammeChoisi != List.NouveauProg)
                {
                    try
                    {
                        Manager.AjouterProgramme(List.NouveauProg);
                        Manager.SauvegardeDonnees();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur : Programme non valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        Window.GetWindow(this).Close();
                    }
                }
            }

            ResetTextBox();

        }

        private void ResetTextBox() 
        {

            //Alternative pour l'instant, c'est pas très propre, en dessous c'est une piste je chercherai plus la dessus
            seriesdeb.Valeur = 0;
            repdeb.Valeur = 0;
            tpsreposdeb.Valeur = 0;
            seriesint.Valeur = 0;
            repint.Valeur = 0;
            tpsreposint.Valeur = 0;
            seriesexp.Valeur = 0;
            repexp.Valeur = 0;
            tpsreposexp.Valeur = 0;

            /* for (int i=0;i< VisualTreeHelper.GetChildrenCount(this); i++)
             {
                 var tmp =VisualTreeHelper.GetChild(this,i);
                 if(tmp is textblocajoutprogramme)
                 {
                     (tmp as textblocajoutprogramme).Valeur = 0;
                 }
             }*/
        }
    }
}
