using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Application;

namespace Homepage
{
    /// <summary>
    /// Logique d'interaction pour ExerciceWindow.xaml
    /// </summary>
    /// 
    public partial class ExerciceWindow : Window
    {
        private Listes List => (App.Current as App).List;

        private IEnumerator<Exercice> exenum;

        public ExerciceWindow()
        {
            InitializeComponent();
            DataContext = List;
            exenum = List.ProgrammeChoisi.LesExercices.GetEnumerator();
            exenum.MoveNext();
            List.ExerciceCourant = exenum.Current;

        }

        private void nextExButton_Click(object sender, RoutedEventArgs e)
        {
            if (exenum.MoveNext())
            {
                List.ExerciceCourant = exenum.Current;
            }
            else
            {
                MessageBox.Show("Bravo ! Vous avez terminé le programme !", "Programme terminé", MessageBoxButton.OK, MessageBoxImage.Information);
                if (List.UtilisateurCourant.Identifiant.Equals("admin"))
                {
                    WindowMainAdmin.GetWindow(new WindowMainAdmin()).Show();
                    ExerciceWindow.GetWindow(this).Close();
                }
                else 
                {
                    MainWindow.GetWindow(new MainWindow()).Show();
                    ExerciceWindow.GetWindow(this).Close();
                }
                
                
            }

            
        }
    }
}
