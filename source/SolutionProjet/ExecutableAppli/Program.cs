using System;
using Application;

using System.Diagnostics;

namespace ExecutableAppli
{
    class Program
    {
        static void Main(string[] args)
        {
            Programme p1 = new Programme("Premier programme ajouté",7,"chemin image A","Programme PUSH\n");
            Console.WriteLine(p1);
            p1.LesExercices.AddLast(new Exercice("Exercice 1", "chemin image ",new Valeur(1,2,3), new Valeur(4,5,6),new Valeur(7,8,9)));
            p1.LesExercices.AddLast(new Exercice("Exercice 2", "chemin image ", new Valeur(1, 2, 3), new Valeur(4, 5, 6), new Valeur(7, 8, 9)));
            p1.LesExercices.AddLast(new Exercice("Exercice 3", "chemin image ", new Valeur(1, 2, 3), new Valeur(4, 5, 6), new Valeur(7, 8, 9)));
            foreach (var ex in p1.LesExercices)
            {
                Console.WriteLine(ex);
                Console.WriteLine("-------------");
            }     
            
            Utilisateur u1 = new Utilisateur("Thomas","Paul",18,170,90,"loginnumero1","mdpnumero1");
            Utilisateur u2 = new Utilisateur("Jake", "Paul", 18, 70,90, "loginnumero1", "mdpnumero2");
            Console.WriteLine(u2.Equals(u1));



        }

       
    }
}
