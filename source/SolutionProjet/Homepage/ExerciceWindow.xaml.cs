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
    public partial class ExerciceWindow : Window, INotifyPropertyChanged
    {
        public Listes List => (App.Current as App).List;
        public Exercice ExerciceCourant { get; set; }

        public LinkedList<Exercice>.Enumerator Enum { get; set; }

        public ExerciceWindow()
        {
            InitializeComponent();
            ExerciceCourant = List.ProgrammeChoisi.LesExercices.First();
            DataContext = ExerciceCourant;
            Enum = List.ProgrammeChoisi.LesExercices.GetEnumerator();
            Enum.MoveNext();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void nextExButton_Click(object sender, RoutedEventArgs e)
        {
            if (Enum.MoveNext())
            {
                ExerciceCourant = Enum.Current;
                DataContext = ExerciceCourant;
                OnPropertyChanged("ExerciceCourant");
            }
            else
            {
                MessageBox.Show("Bravo ! Vous avez terminé le programmes !", "Programme terminé", MessageBoxButton.OK, MessageBoxImage.Information);
                ExerciceWindow.GetWindow(this).Close();
            }

            
        }
    }
}
