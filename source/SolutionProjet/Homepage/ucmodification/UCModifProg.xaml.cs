using Application;
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

namespace Homepage.ucmodification
{
    /// <summary>
    /// Logique d'interaction pour UCModifProg.xaml
    /// </summary>
    public partial class UCModifProg : UserControl
    {
        public Listes List => (App.Current as App).List;
        public UCModifProg()
        {
            InitializeComponent();
            DataContext = List;
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
           if (string.IsNullOrWhiteSpace(newName.Text))
           {

           }
           else
                List.ProgrammeChoisi.Nom = newName.Text;
           if (string.IsNullOrWhiteSpace(newDesc.Text))
           {

           }
           else
                List.ProgrammeChoisi.Description = newDesc.Text;
           Window.GetWindow(this).Close();
            
        }
    }
    
}
