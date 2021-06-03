using Application;
using Management;
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

namespace Homepage.ucmodification
{
    /// <summary>
    /// Logique d'interaction pour UCModifProg.xaml
    /// </summary>
    public partial class UCModifProg : UserControl
    {
        public Listes List => (App.Current as App).LeManager.CurrentList;
        public Manager Manager => (App.Current as App).LeManager;
        public UCModifProg()
        {
            InitializeComponent();
            DataContext = List;
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e) //pb : même si valeur fausse, update dans la window 
        {
          if (!string.IsNullOrWhiteSpace(newName.Text))
          {
                List.ProgrammeChoisi.Nom = newName.Text;
          }
                    
          if (!string.IsNullOrWhiteSpace(newDesc.Text))
          {
             List.ProgrammeChoisi.Description = newDesc.Text;
          }
            Manager.SauvegardeDonnees();
            Window.GetWindow(this).Close();
        }
     }
 }
    

