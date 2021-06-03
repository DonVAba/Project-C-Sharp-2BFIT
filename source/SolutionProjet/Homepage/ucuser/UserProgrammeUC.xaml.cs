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

        private void start_Click(object sender, RoutedEventArgs e)
        {
            if(List.ProgrammeChoisi.LesExercices.Count == 0)
            {
                MessageBox.Show("Programme sans exercices !","Erreur",MessageBoxButton.OK,MessageBoxImage.Error);
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
            Manager.SauvegardeDonnees();
            ExerciceWindow ew = new ExerciceWindow();
            MainWindow.GetWindow(this).Close();
            ew.Show();
            
        }
    }
}
