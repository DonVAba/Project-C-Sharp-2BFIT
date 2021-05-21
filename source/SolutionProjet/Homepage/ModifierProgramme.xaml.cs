using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Logique d'interaction pour ModifierProgramme.xaml
    /// </summary>
    public partial class ModifierProgramme : Page
    {
        public Listes List => (App.Current as App).List;
        public ModifierProgramme()
        {
            InitializeComponent();
            DataContext = List;
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ///Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
