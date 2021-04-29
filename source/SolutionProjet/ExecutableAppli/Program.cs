using System;
using Application;

namespace ExecutableAppli
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilisateur utilisateur = new Utilisateur("Bastien", "Test", 18, 185, 60, "Bast", "toto");
            Console.WriteLine(utilisateur);
            ///Test console utilisateur
            Programme programme = new Programme("Le programme blablabla", 10, "/dossier/Images/FentesAvant.png");
            Console.WriteLine(programme);
        }
    }
}
