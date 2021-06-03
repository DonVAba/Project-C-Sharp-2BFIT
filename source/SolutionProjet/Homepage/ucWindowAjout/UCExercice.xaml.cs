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
using System.Windows.Media.Imaging;

namespace Homepage.ucWindowAjout
{
    /// <summary>
    /// Logique d'interaction pour UCExercice.xaml
    /// </summary>
    public partial class UCExercice : UserControl {
        private Listes List => (App.Current as App).LeManager.CurrentList;
        private Manager Manager => (App.Current as App).LeManager;
        private static int i = 0;
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
                string filename = dialog.FileName;
                BitmapImage bw = new BitmapImage();
                bw.UriSource = new Uri(filename);
                
            }
        }

        private void nextExo_Click(object sender, RoutedEventArgs e)
        {
            //Faut trouver un moyen de recuperer toutes les textbox de notre UC 

            if (i == List.NouveauProg.GetNbExercices())
            {
                i = 0;
                List.ListProgrammes.Add(List.NouveauProg);
                Manager.SauvegardeDonnees();
                Window.GetWindow(this).Close();
            }
            else 
            {
                List.NouveauProg.LesExercices.Add(
                new Exercice(nomNewExo.Text, "/ Image; Component / img / imgfond / background_ciel.jpg",
                    new Valeur(seriesdeb.Valeur, repdeb.Valeur, tpsreposdeb.Valeur),
                    new Valeur(seriesint.Valeur, repint.Valeur, tpsreposint.Valeur),
                    new Valeur(seriesexp.Valeur, repexp.Valeur, tpsreposexp.Valeur)));
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
                     (tmp as textblocajoutprogramme).Message = string.Empty;
                 }
             }*/
        }
    }
}
