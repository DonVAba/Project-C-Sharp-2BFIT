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

namespace Homepage
{
    /// <summary>
    /// Logique d'interaction pour AjouterProgramme.xaml
    /// </summary>
    public partial class AjouterProgramme : Window
    {
        public AjouterProgramme()
        {
            InitializeComponent();
        }

        private void ImportImageButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = @"C:\Users\Public\Pictures";
            dialog.FileName = "Images";
            dialog.DefaultExt = ".jpg | .png | .gif";

            bool? result = dialog.ShowDialog();

            if(result == true)
            {
                string filename = dialog.FileName;
                CheminFichierExo.Text = filename;
            }
        }
    }
}
