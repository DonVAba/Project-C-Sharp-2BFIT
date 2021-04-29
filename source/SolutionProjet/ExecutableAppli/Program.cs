using System;
using Application;

using System.Diagnostics;

namespace ExecutableAppli
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilisateur utilisateur = new Utilisateur("Bastien", "Test", 18, 185, 60, "Bast", "toto");
            Console.WriteLine(utilisateur);
            ///Test console utilisateur
            Programme programme = new Programme("Le programme blablabla", 10, "/dossier/Images/FentesAvant.png","testprog");
            Console.WriteLine(programme);
            //Test Console Valeur
            Valeur v = new Valeur(10,20,30);
            //Console.WriteLine(v);
            Debug.WriteLine(v);
        }
    }
}
