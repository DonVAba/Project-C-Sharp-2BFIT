using Application;
using Persistance;
using System;
using System.Collections.Generic;

namespace Test_Programme
{
    class ProgramProgramme
    {
        static void Main(string[] args)
        { 
            StubData stub = new StubData("");
            LinkedList<Programme> listProg = stub.ChargeListprogramme();


            //A ameliorer l'affichage est pas super propre
            Console.WriteLine("Affichage des programmes");
            foreach (Programme p in listProg)
            {
                Console.WriteLine(p);
                foreach (Exercice ex in p.LesExercices)
                {
                    Console.WriteLine(ex);
                }
            }

            Console.WriteLine("-----------------------");

            //Test du ToString
            Console.WriteLine("Test du ToString");
            foreach(Programme programme in listProg)
            {
                Console.WriteLine(programme);
            }

           
            Console.WriteLine("-----------------------");

            //Test Equals
            Programme prog = new Programme("PUSH", "Programme qui fait travailler les pectoraux,triceps et épaules", "chemin image programme PUSH");
            Console.WriteLine($"Test Equals avec le programme : {prog.Nom}");
            //La methode ChargeListProgramme ajoute le programme ci dessus en 2eme position, le TRUE du Equals doit donc être après un tour dans la boucle
            foreach(Programme programme in listProg)
            {
                Console.WriteLine($"Test du Equals : {programme.Equals(prog)}");
            }
            Console.WriteLine("-----------------------");

            //Test Hashcode
            Console.WriteLine("Test HashCode :");
            foreach (Programme programme in listProg)
            {
                Console.WriteLine($"HashCode de chaque programme : {programme.GetHashCode()}");
            }
            Console.WriteLine("-----------------------");

           
            Console.WriteLine("Supprimer exercice");

            //Création d'un nouveau programme avec deux exercice
            LinkedList<Exercice> listExo = new LinkedList<Exercice>();
            listExo.AddLast(new Exercice("Traction", "chemin img traction", new Valeur(8, 4, 80), new Valeur(10, 4, 70), new Valeur(12, 4, 60)));
            Exercice e = new Exercice("Test", "chemin test", new Valeur(8, 4, 80), new Valeur(10, 4, 70), new Valeur(12, 4, 60));
            listExo.AddLast(e);
            prog.LesExercices = listExo;
            foreach(Exercice exercice in prog.LesExercices)
            {
                Console.WriteLine(exercice);
            }

            // Test suppressione exercice
            Console.WriteLine("---- Suppression de l'exercice -------");
            prog.SupprimerExercices(e);
            foreach (Exercice exercice in prog.LesExercices)
            {
                Console.WriteLine(exercice);
            }


        }
    }
}
