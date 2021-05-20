using System;
using System.Collections.Generic;
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
        public Listes List => (App.Current as App).List;

        public LinkedList<Exercice>.Enumerator exenum = new LinkedList<Exercice>.Enumerator();

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
                MainWindow.GetWindow(new MainWindow()).Show();
                ExerciceWindow.GetWindow(this).Close();
                
            }

            
        }
    }
}
