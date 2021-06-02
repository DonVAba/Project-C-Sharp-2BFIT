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
        public Navigator Nav => (App.Current as App).Navigator;
        public ExercicePageUCAdmin()
        {
            InitializeComponent();
            DataContext = List;
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (List.ProgrammeChoisi.LesExercices.Count == 0)
            {
                MessageBox.Show("Programme sans exercices !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string diff = "";
            int index = LevelComboBox.SelectedIndex;
            switch (index)
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
            Manager.LancementProgramme(List.ProgrammeChoisi, diff);
            ExerciceWindow ew = new ExerciceWindow();
            MainWindow.GetWindow(this).Close();
            ew.Show();
        }

        private void Delete_Click_Programme(object sender, RoutedEventArgs e)
        {
            Programme prog = List.ProgrammeChoisi;
            Manager.SupprimerProgramme(prog);
            MessageBox.Show("Programme supprimé avec succés", "Validation", MessageBoxButton.OK, MessageBoxImage.Information);
            if (List.ListProgrammes.Count() == 0)
            {
                WindowMainAdmin aw = Window.GetWindow(this) as WindowMainAdmin;
                aw.MainWindowContentControl.Content = aw.InitUserControlProfil();
                
                return;
            }
            
            List.ProgrammeChoisi = List.ListProgrammes.First();
        }

        private void Delete_Click_Exercice(object sender, RoutedEventArgs e)
        {
            List.ProgrammeChoisi.SupprimerExercices(List.ExerciceCourant);
        }

        private void Button_Modif_Programme(object sender, RoutedEventArgs e)
        {
            ModifWindow mdc = new ModifWindow(ucmp);
            mdc.ShowDialog();
        }

        private void ExerciceListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List.ExerciceCourant = (sender as ListBox).SelectedItem as Exercice;
        }

        private void AjouterExercice(object sender, RoutedEventArgs e)
        {
            AjouterExercice ex = new AjouterExercice();
            
        }

    }
}
