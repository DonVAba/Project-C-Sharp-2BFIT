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

namespace Homepage.ucadmin
{
    /// <summary>
    /// Logique d'interaction pour ExercicePageUCAdmin.xaml
    /// </summary>
    public partial class ExercicePageUCAdmin : UserControl
    {
        public Listes List => (App.Current as App).List;
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
           Exercice exo = List.ExerciceCourant; // J'arrive pas a récup l'exercice courant, j'ai que la valeur null 
        }

        /*private void Button_Modif_Programme(object sender, RoutedEventArgs e)
        {
            ModifierProgramme mdc = new ModifierProgramme();
            mdc.Show();
        }*/
    }
}
