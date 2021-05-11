﻿using System;
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
using Application;
using Persistance;

namespace Homepage.ucuser
{
    /// <summary>
    /// Logique d'interaction pour UserProfilUC.xaml
    /// </summary>
    public partial class UserProfilUC : UserControl
    {
        public Listes List => (App.Current as App).List;
        
        public UserProfilUC()
        {
            InitializeComponent();
            DataContext = List;

        }

        private void ButtonModifierCorpulence_Click(object sender, RoutedEventArgs e)
        {
            ModifierCorpulence mc = new ModifierCorpulence();
            mc.Show();
        }
    }
}
