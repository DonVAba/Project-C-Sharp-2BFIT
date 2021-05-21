using Application;
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
using Homepage.ucWindowAjout;

namespace Homepage
{
    /// <summary>
    /// Logique d'interaction pour AjouterProgramme.xaml
    /// </summary>
    public partial class AjouterProgramme : Window
    {
        public Listes List => (App.Current as App).List;
        public static Navigator Navigator { get; set; } = Navigator.GetInstance();

        public AjouterProgramme()
        {
            InitializeComponent();
            DataContext = Navigator;
            Navigator.NavigateTo("UC_AjoutProg");
        }

    }
}
