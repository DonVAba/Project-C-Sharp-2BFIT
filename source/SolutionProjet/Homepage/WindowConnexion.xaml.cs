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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class WindowConnexion : Window
    {
        private Navigator Nav => (App.Current as App).Navigator;
        public WindowConnexion()
        {
            InitializeComponent();
            ConnexionCC.DataContext = Nav;    //Set le dataContext sur notre Navigator 
        }
    }
}
