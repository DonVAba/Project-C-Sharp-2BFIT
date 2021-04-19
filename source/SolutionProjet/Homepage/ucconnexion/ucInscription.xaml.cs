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
using Homepage.ucconnexion;

namespace Homepage.ucconnexion
{
    /// <summary>
    /// Logique d'interaction pour ucInscription.xaml
    /// </summary>
    public partial class ucInscription : UserControl
    {
        public ucInscription()
        {
            InitializeComponent();
        }

        private void InsButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FFFFFFFF");
            var bru = (Brush)converter.ConvertFromString("#FF6495ED");
            b.Foreground = brush;
            b.Background = bru;
        }

        private void InsButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FFFFFFFF");
            var bru = (Brush)converter.ConvertFromString("#FF6495ED");
            b.Foreground = bru;
            b.Background = brush;
        }


        public event RoutedEventHandler PremièreConnexionClick
        {
            add
            {
                CoFlatButton.Click += value;
            }
            remove
            {
                CoFlatButton.Click -= value;
            }
        }
    }
}
