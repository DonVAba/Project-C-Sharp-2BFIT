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
    /// Logique d'interaction pour ModifWindow.xaml
    /// </summary>
    public partial class ModifWindow : Window
    {
        public ModifWindow(UserControl uc)
        {
            InitializeComponent();
            ModifWindowContentControl.Content = uc;
        }

    }
}
