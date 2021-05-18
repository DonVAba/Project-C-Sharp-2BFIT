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
        public static Navigator Navigator { get; set; } = Navigator.GetInstance();
        

        public WindowConnexion()
        {
            InitializeComponent();
            DataContext = Navigator;
        }
    }
}
