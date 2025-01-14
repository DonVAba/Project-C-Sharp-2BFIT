﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Application;
using Homepage.converters;
using Management;

namespace Homepage.ucWindowAjout
{
    /// <summary>
    /// Logique d'interaction pour UCProgramme.xaml
    /// </summary>
    public partial class UCProgramme : UserControl
    {
        private Navigator Nav => (App.Current as App).Navigator;
        private Listes List => (App.Current as App).LeManager.CurrentList;
        private bool isLoadedImage;
        private string ImagesPath { get; set; }
        public UCProgramme()
        {
            InitializeComponent();
            DataContext = List;
        }

        /// <summary>
        /// Méthode permattant de définir le cheminImage d'un programme via un FileDialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportImageButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = @"C:\Users\Public\Pictures";
            dialog.FileName = "Images";
            dialog.DefaultExt = ".jpg | .png";

            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                ImagesPath = dialog.FileName;
                isLoadedImage = true;
            }
            else
                isLoadedImage = false;
            
        }
        /// <summary>
        /// Méthode qui navigue sur l'UC "UC_AjoutExercice" après vérification que les valeurs et l'image rentrées sont bonnes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isLoadedImage)
            {
                MessageBox.Show("Erreur : image pas chargée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(nomProg.Text) || string.IsNullOrWhiteSpace(descProg.Text) || string.IsNullOrWhiteSpace(nbExos.Text))
            {
                MessageBox.Show("Mauvaises valeurs rentrées, veuillez réessayer", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                if(Int32.TryParse(nbExos.Text, out int value)) 
                {
                    if(value <= 0)
                    {
                        MessageBox.Show("Mauvaises nombres d'exercices, veuillez réessayer", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        List.NouveauProg = new Programme(nomProg.Text.ToUpper(), descProg.Text, ImagesPath);//Set du nouveau programme avec les données rentrées  
                        List.NouveauProg.SetNbExercices(value);
                        Nav.NavigateTo("UC_AjoutExercice");//Navigation vers l'UC 
                    }
                    
                }
                else
                    MessageBox.Show("Nombre d'exercice rentrés incorrect", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);


            }



        }
    }
}
