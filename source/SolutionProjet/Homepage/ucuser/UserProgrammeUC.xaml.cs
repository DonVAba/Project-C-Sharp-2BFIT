using Application;
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

namespace Homepage.ucuser
{
    /// <summary>
    /// Logique d'interaction pour UserProgrammeUC.xaml
    /// </summary>
    public partial class UserProgrammeUC : UserControl
    {
        public Listes List => (App.Current as App).LeManager.CurrentList;
        public Manager Manager => (App.Current as App).LeManager;
        public UserProgrammeUC()
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
            if(List.ProgrammeChoisi.LesExercices.Count == 0)//Vérification que le programme Choisi n'est pas 0 exercice
            {
                MessageBox.Show("Programme sans exercices !","Erreur",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            string diff = "";//Instancie une variable diff de type string (diff= difficulté)
            int index = LevelComboBox.SelectedIndex;// Instancie une variable index selon l'item Selectionné dans la comboBox
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
            ExerciceWindow ew = new ExerciceWindow();//Instancie une nouvelle fenêtre ExerciceWindow, ferme UserProgrammeUC et ouvre l'exerciceWindow
            MainWindow.GetWindow(this).Close();
            ew.Show();
            
        }
    }
}
