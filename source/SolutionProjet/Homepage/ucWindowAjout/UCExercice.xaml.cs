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
        /// <summary>
        /// Méthode qui ouvre un explorateur de fichier pour selectionner une image finissant par .jpg ou.png
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportImageButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();//Initialise la variable dialog pour ouvrir un explorateur
            dialog.InitialDirectory = @"C:\Users\Public\Pictures";//Initialise le repertoire initial affiché 
            dialog.FileName = "Images";
            dialog.DefaultExt = ".jpg | .png";//Définit l'extension de fichier par défaut

            bool? result = dialog.ShowDialog();//Set une variable result de type nullable bool 

            if (result == true)
            {
                ImagesPath = dialog.FileName;//Set à ImagePath le nom du fichier de l'image selectionné
                isLoadedImage = true;
            }
            else
                isLoadedImage = false;
        }
        /// <summary>
        /// Méthode qui passe à la fenêtre suivante quand on clique sur le boutton après avoir fait les vérifications nécessaires
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextExo_Click(object sender, RoutedEventArgs e)
        {
            if (!isLoadedImage)//Si isLoadedImage est false, on affiche une messageBox
            {
                MessageBox.Show("Erreur : image non importé","Erreur", MessageBoxButton.OK,MessageBoxImage.Error);
                
            }
            
            if (i != List.NouveauProg.NbExercices || List.NouveauProg.NbExercices==0)//Si i est différent du nombre d'exercice ou si le nombre d'exericice est égale à 0, on ajoute les valeurs rentrées. 
            {
                try
                {
                    //Si une des valeurs ajouté est autre qu'un int, on aura une exception qui va dans le catch
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

            if (i == List.NouveauProg.NbExercices)// Lorsque i est égale au nombre d'exercice, on ajoute le programme a la liste dans Manager
            {
                i = 0; // reset de la valeur de i
                if (List.ProgrammeChoisi != List.NouveauProg) // Pour diffénrecier l'ajout d'exercice quand on ajout un nouveau programme de l'ajout d'exercice simple sur un programme
                {
                    try // ajout du programme et sauvegarde des données
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
                                                
            ResetTextBox(); // Remise à zéro des text box v

        }
        /// <summary>
        /// Méthode qui reset toute les textbox de l'UC 
        /// </summary>
        private void ResetTextBox() 
        {
            seriesdeb.Valeur = 0;
            repdeb.Valeur = 0;
            tpsreposdeb.Valeur = 0;
            seriesint.Valeur = 0;
            repint.Valeur = 0;
            tpsreposint.Valeur = 0;
            seriesexp.Valeur = 0;
            repexp.Valeur = 0;
            tpsreposexp.Valeur = 0;
        }

        private void FermerFenetre_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

    }
}
