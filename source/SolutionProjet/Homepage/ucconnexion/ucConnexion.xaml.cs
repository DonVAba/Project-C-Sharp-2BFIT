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

namespace Homepage.ucconnexion
{
    /// <summary>
    /// Logique d'interaction pour ucConnexion.xaml
    /// </summary>
    public partial class ucConnexion : UserControl
    {
        public ucConnexion()
        {
            InitializeComponent();
        }

        private void ConnexionButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }


        private void ConnexionButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FFFFFFFF");
            var bru = (Brush)converter.ConvertFromString("#FF6495ED");
            b.Foreground = brush;
            b.Background = bru;
        }

        public event RoutedEventHandler InscriptionClick
        {
            add
            {
                InscriptionButton.Click += value;
            }
            remove
            {
                InscriptionButton.Click -= value;
            }
        }
    }
}
