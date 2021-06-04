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

        private int i = 0;
        private bool isLoadedImage;


        private string ImagesPath { get; set; }  = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\2bfit_bin/img//imgExercice");
        private string Nomimage { get; set; }
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
                FileInfo fi = new FileInfo(dialog.FileName);
                string file = fi.Name;
                int index = 0;
                while(!Directory.Exists(ImagesPath))
                {
                    Directory.CreateDirectory(ImagesPath);
                }
                while (File.Exists(System.IO.Path.Combine(ImagesPath, file)))
                {
                    file = $"{file.Remove(file.LastIndexOf('.'))}_{index}.{fi.Extension}";
                    index++;
                }
                File.Copy(dialog.FileName, System.IO.Path.Combine(ImagesPath, file));
                Nomimage = file;
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
                        MessageBox.Show("Erreur : image non importé", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        Window.GetWindow(this).Close();
                    }
                }
            }
            else 
            {
                try
                {
                    List.NouveauProg.LesExercices.Add(
                        new Exercice(nomNewExo.Text, System.IO.Path.Combine(ImagesPath, Nomimage),
                        new Valeur(seriesdeb.Valeur, repdeb.Valeur, tpsreposdeb.Valeur),
                        new Valeur(seriesint.Valeur, repint.Valeur, tpsreposint.Valeur),
                        new Valeur(seriesexp.Valeur, repexp.Valeur, tpsreposexp.Valeur))); 
                }
                catch (Exception)
                {
                    MessageBox.Show("Erreur : image non importé", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
            
            i++;
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
