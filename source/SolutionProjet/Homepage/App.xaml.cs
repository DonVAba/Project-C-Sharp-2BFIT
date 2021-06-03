using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Application;
using PersistanceData;
using Management;

namespace Homepage
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public Listes List { get; set; }
        public Manager LeManager { get; private set; } = new Manager();
        public Navigator Navigator { get; private set; }
        private StubData stub = new StubData("");

        public App()
        {
            /*
            LeManager.ChargeDonnees();
            List = LeManager.CurrentList;
            Navigator = Navigator.GetInstance();*/

            /*LeManager.CurrentList = stub.ChargeDonnees();
            Navigator = Navigator.GetInstance();
            LeManager.Persistance = new DataContract();
            LeManager.SauvegardeDonnees();
            LeManager.ChargeDonnees();*/

            LeManager.Persistance = new DataContract();
            LeManager.ChargeDonnees();
            Navigator = Navigator.GetInstance();

        }  

    }
}
