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
using Persistance;
using Homepage.ucmodification;

namespace Homepage.ucadmin
{
    /// <summary>
    /// Logique d'interaction pour ExercicePageUCAdmin.xaml
    /// </summary>
    public partial class ExercicePageUCAdmin : UserControl
    {
        public Listes List => (App.Current as App).List;
        private UCModifProg ucmp = new UCModifProg();
        public static Navigator Navigator { get; set; } = Navigator.GetInstance();
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
            Management.Manager.LancementProgramme(List.ProgrammeChoisi, diff, List);
            ExerciceWindow ew = new ExerciceWindow();
            MainWindow.GetWindow(this).Close();
            ew.Show();
        }

        private void Delete_Click_Programme(object sender, RoutedEventArgs e)
        {
            Programme prog = List.ProgrammeChoisi;
            List.ListProgrammes.Remove(prog);
            if (List.ListProgrammes.Count() == 0)
            {
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

        private void exerciceListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List.ExerciceCourant = (sender as ListBox).SelectedItem as Exercice;
        }

    }
}
