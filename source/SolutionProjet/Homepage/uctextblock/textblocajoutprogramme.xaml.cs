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

namespace Homepage.uctextblock
{
    /// <summary>
    /// Logique d'interaction pour textblocajoutprogramme.xaml
    /// </summary>
    public partial class textblocajoutprogramme : UserControl
    {
        public textblocajoutprogramme()
        {
            InitializeComponent();
        }

        public string Message
        {
            set
            {
                textblock.Text = value;
            }
        }



        public int Valeur
        {
            get { return (int)GetValue(ValeurProperty); }
            set { SetValue(ValeurProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Valeur.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValeurProperty =
            DependencyProperty.Register("Valeur", typeof(int), typeof(textblocajoutprogramme), new PropertyMetadata(0));


    }
}
