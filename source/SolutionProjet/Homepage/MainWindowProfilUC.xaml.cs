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

namespace Homepage
{
    /// <summary>
    /// Logique d'interaction pour MainWindowProfilUC.xaml
    /// </summary>
    public partial class MainWindowProfilUC : UserControl
    {
        public MainWindowProfilUC()
        {
            InitializeComponent();
        }
        private void ButtonModifierCorpulence_Click(object sender, RoutedEventArgs e)
        {
            ModifierCorpulence m = new ModifierCorpulence();
            m.Show();
        }
    }
}
