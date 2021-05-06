using System;
using Persistance;
using Application;
using System.Collections.Generic;

namespace Test_Utilisateur
{
    class Program
    {
        /// <summary>
        /// Programme de test Utilisateur
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Programme de test Utilisateur");
            ///Initialisation d'une nouvelle liste d'utilisateur en appellant la methode ChargeListUsers
            Persistance.StubData stub1 = new StubData();
            /// Test du ToString pour des utilisateur / admin 
            List<Utilisateur> listU =stub1.ChargeListUsers();
            foreach(Utilisateur utilisateur in listU)
            {
              Console.WriteLine(utilisateur);
            }
            ///Test ToString avec Utilisateur avec attributs incorrect/null 
            Valeur valDeb = new Valeur(8, 4, 80);
            Valeur valInter = new Valeur(10, 4, 70);
            Valeur valExpert = new Valeur(12, 4, 60);
            Application.Exercice exercice1 = new Exercice("Bras", "blabla", valDeb, valInter, valExpert);
            //Test du compareTo 
            Console.WriteLine("Test du compareTo");
            Console.WriteLine(listU[0].CompareTo(listU[1]));
            //Test Equals 
            Console.WriteLine("Test du Equals");
            Console.WriteLine("Avec 2 utilisateurs différents : "+listU[0].Equals(listU[1]));
            Application.Utilisateur utilisateur1 = new Utilisateur("Martel", "Baptiste", new DateTime(2003, 1, 30), 190, 190, "bamartel", "mdpDeBamartel");
            Console.WriteLine("Avec 2 utilisateurs égaux : " + listU[0].Equals(utilisateur1));
            Console.WriteLine("Avec 2 objet différents : " + listU[0].Equals(exercice1));
            //Test Hashcode
            Console.WriteLine("Test Hashcode");
            Console.WriteLine(listU[0].GetHashCode());


        }
    }
}
