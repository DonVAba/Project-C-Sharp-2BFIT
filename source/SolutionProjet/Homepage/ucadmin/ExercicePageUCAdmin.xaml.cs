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

namespace Homepage.ucadmin
{
    /// <summary>
    /// Logique d'interaction pour ExercicePageUCAdmin.xaml
    /// </summary>
    public partial class ExercicePageUCAdmin : UserControl
    {
        public ExercicePageUCAdmin()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            ExerciceWindow e = new ExerciceWindow();
            e.Show();
        }
    }
}
