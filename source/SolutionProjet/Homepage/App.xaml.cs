using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Application;
using Persistance;

namespace Homepage
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public Listes List { get; set; }
        private StubData stub = new StubData("");

        public App()
        {
            List = stub.ChargeDonnees();
        }  

    }
}
