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
        public ExercicePageUCAdmin()
        {
            InitializeComponent();
            DataContext = List;
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
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
            ew.ShowDialog();
        }

        private void Delete_Click_Programme(object sender, RoutedEventArgs e)
        {
            Programme prog = List.ProgrammeChoisi;
            List.ListProgrammes.Remove(prog);
            List.ProgrammeChoisi = List.ListProgrammes.First();
        }

        private void Delete_Click_Exercice(object sender, RoutedEventArgs e)
        {
            List.ExerciceCourant = (sender as ListBox).SelectedItem as Exercice; //à voir si le changement d'élément s'effectue avant le delete ou après
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
