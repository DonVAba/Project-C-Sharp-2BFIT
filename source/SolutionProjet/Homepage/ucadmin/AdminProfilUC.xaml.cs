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

namespace Homepage.ucadmin
{
    /// <summary>
    /// Logique d'interaction pour AdminProfilUC.xaml
    /// </summary>
    public partial class AdminProfilUC : UserControl
    {
        public AdminProfilUC()
        {
            InitializeComponent();
        }

        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            ModifierCorpulence mdc = new ModifierCorpulence();
            mdc.Show();
        }
    }
}
