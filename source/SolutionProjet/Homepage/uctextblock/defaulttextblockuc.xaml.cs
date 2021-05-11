using Application;
using Persistance;
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
    /// Logique d'interaction pour defaulttextblockuc.xaml
    /// </summary>
    public partial class defaulttextblockuc : UserControl
    {

        public Listes List => (App.Current as App).List;
        public defaulttextblockuc()
        {
            InitializeComponent();
            DataContext = List;
        }

        public string Message
        {
            set
            {
                textblock.Text = value;
            }
        }

        public string Valeur
        {
            set
            {
                textvalue.Text = value;            }
        }

      
    }
}
