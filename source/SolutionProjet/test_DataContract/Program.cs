using System;
using PersistanceData;
using Application;
using Management;

namespace test_DataContract
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var manager = new Manager(new StubData("").ChargeDonnees());
            manager.Persistance = new DataContract();
            manager.ChargeDonnees();
            manager.SauvegardeDonnees();

            /*var manager = new Manager(new DataContract());
            manager.ChargeDonnees();
            manager.SauvegardeDonnees();*/


        }
    }
}
