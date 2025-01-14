﻿using Homepage.ucadmin;
using Homepage.ucuser;
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
using System.Windows.Shapes;
using Application;
using System.Collections.ObjectModel;

namespace Homepage
{
    /// <summary>
    /// Logique d'interaction pour WindowMainAdmin.xaml
    /// </summary>
    public partial class WindowMainAdmin : Window
    {
        private Listes List => (App.Current as App).LeManager.CurrentList;

        private ExercicePageUCAdmin ucProg;
        private AdminProfilUC ucProfil;
        public WindowMainAdmin()
        {
            InitializeComponent();
            MainWindowContentControl.Content = InitUserControlProfil();
            DataContext = List;
        }
        /// <summary>
        /// Méthode qui change le programmeChoisi selon l'item selectionné dans la listbox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxProg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindowContentControl.Content = InitUserControlProg();
            if((sender as ListBox).SelectedItem!=List.ProgrammeChoisi)
                List.ProgrammeChoisi = (sender as ListBox).SelectedItem as Programme;
        }

        private void MWButtonProfile_Click(object sender, RoutedEventArgs e)
        {
            MainWindowContentControl.Content = InitUserControlProfil(); // Lorsqu'on clique sur le bouton, on revient sur le UserControl MainWindowContentControl
        }

        public ExercicePageUCAdmin InitUserControlProg()
        {
            if (ucProg == null)
            {
                ucProg = new ExercicePageUCAdmin();
            }
            return ucProg;
        }

        public AdminProfilUC InitUserControlProfil()
        {
            if (ucProfil == null)
            {
                ucProfil = new AdminProfilUC();
            }
            return ucProfil;
        }
        /// <summary>
        /// Méthode qui ouvre une nouvelle fenêtre AjouterProgramme après l'avoir instancié
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            AjouterProgramme ap = new AjouterProgramme();
            
            ap.ShowDialog();
        }
    }
}
