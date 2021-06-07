using Application;
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
using Homepage.ucmodification;
using Homepage.ucadmin;
using Homepage.ucuser;
using Management;

namespace Homepage.ucadmin
{
    /// <summary>
    /// Logique d'interaction pour ExercicePageUCAdmin.xaml
    /// </summary>
    public partial class ExercicePageUCAdmin : UserControl
    {
        public Listes List => (App.Current as App).LeManager.CurrentList;
        public Manager Manager => (App.Current as App).LeManager;
        private UCModifProg ucmp = new UCModifProg();
        
        public ExercicePageUCAdmin()
        {
            InitializeComponent();
            DataContext = List;
        }
        /// <summary>
        /// Méthode qui ouvre une nouvelle fenêtre ExerciceWindow après avoir sélectionné une difficulté 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (List.ProgrammeChoisi.LesExercices.Count == 0)//Vérification que le programme Choisi n'ai pas 0 exercice 
            {
                MessageBox.Show("Programme sans exercices !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error); //Affichage d'une messageBox pour l'utilisateur 
                return; 
            }
            string diff = ""; //Instancie une variable diff de type string (diff= difficulté)
            int index = LevelComboBox.SelectedIndex; // Instancie une variable index selon l'item Selectionné dans la comboBox 
            switch (index)//Selon la valeur de l'index, diff va prendre une valeur différentes
            {
                case 0:
                    diff = "DEBUTANT";  
                    break;
                case 1:
                    diff = "INTERMEDIAIRE";
                    break;
                case 2:
                    diff = "EXPERT";
                    break;
            }
            Manager.LancementProgramme(List.ProgrammeChoisi, diff);//Appel de la methode LancementProgramme de Manager avec paramètre le programmeChoisi et la diff
            Manager.SauvegardeDonnees();
            ExerciceWindow ew = new ExerciceWindow(); //Instancie une nouvelle fenêtre ExerciceWindow
            MainWindow.GetWindow(this).Close();//Ferme la window ExercicePageUCAdmin.xaml.cs
            ew.Show();//Ouvre notre window ExerciceWindow 
        }
        /// <summary>
        /// Méthode qui supprime le programmeChoisi après avoir cliqué sur le bouton "SUPPRIMER" en appelant la méthode SupprimerProgramme du manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click_Programme(object sender, RoutedEventArgs e)
        {
            Programme prog = List.ProgrammeChoisi; //Instancie une variable prog qui est égale au ProgrammeChoisi
            Manager.SupprimerProgramme(prog);//Appel de la methode SupprimerProgramme avec en paramètre prog qui est égale au ProgrammeChoisi
            MessageBox.Show("Programme supprimé avec succés", "Validation", MessageBoxButton.OK, MessageBoxImage.Information);
            if (List.ListProgrammes.Count() == 0)//Si la liste de programme =0, on retourne sur la WindowMainAdmin 
            {
                WindowMainAdmin aw = Window.GetWindow(this) as WindowMainAdmin;
                aw.MainWindowContentControl.Content = aw.InitUserControlProfil();
            }
            Manager.SauvegardeDonnees();
            List.ProgrammeChoisi = List.ListProgrammes.First(); //Si la liste de programme != 0, le programme choisit = au premier programme dans la ListProgramme
        }
        /// <summary>
        /// Méthode qui appelle la methode SupprimerExercices de Listes après avoir cliqué sur le bouton "ButtonModifProg"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click_Exercice(object sender, RoutedEventArgs e)
        {
            List.ProgrammeChoisi.SupprimerExercices(List.ExerciceCourant);//Appel de la méthode SupprimerExerices de Programme avec en paramètre l'exerciceCourant
            Manager.SauvegardeDonnees();
        }
        /// <summary>
        /// Méthode qui ouvre une nouvelle fenêtre ModifWindow après l'avoir instancié
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Modif_Programme(object sender, RoutedEventArgs e)
        {
            ModifWindow mdc = new ModifWindow(ucmp);
            mdc.ShowDialog();
        }
        /// <summary>
        /// Méthode qui change la valeur de l'exerciceCourant quand on clique sur la ListBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExerciceListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List.ExerciceCourant = (sender as ListBox).SelectedItem as Exercice;//Cast du SelectedItem de la ListBox en Exercice
        }

        private void AjouterExercices(object sender, RoutedEventArgs e)
        {
            List.NouveauProg = List.ProgrammeChoisi;
            List.NouveauProg.NbExercices = 1;
            AjouterExercice w = new AjouterExercice();
            w.ShowDialog();
        }

    }
}
