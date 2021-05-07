using System;
using Persistance;
using Application;
using System.Collections.Generic;

namespace Test_Utilisateur
{
    class ProgramUtilisateur
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
            Valeur valDeb = new Valeur(8, 4, 80);
            Valeur valInter = new Valeur(10, 4, 70);
            Valeur valExpert = new Valeur(12, 4, 60);
            Application.Exercice exercice1 = new Exercice("Bras", "blabla", valDeb, valInter, valExpert);
            List<Utilisateur> listU = stub1.ChargeListUsers();

            /// Test du ToString pour des utilisateur / admin 

            foreach (Utilisateur utilisateur in listU)
            {
              Console.WriteLine(utilisateur);
            }

            Console.WriteLine("------------------------------");

            //Test du compareTo 
            Console.WriteLine("Test du compareTo");
            Console.WriteLine(listU[0].CompareTo(listU[1]));

            Console.WriteLine("------------------------------");

            //Test Equals 
            Console.WriteLine("Test du Equals");
            Console.WriteLine("Avec 2 utilisateurs différents : "+listU[0].Equals(listU[1]));

            Application.Utilisateur utilisateur1 = new Utilisateur("Martel", "Baptiste", new DateTime(2003, 1, 30), 190, 190, "bamartel", "mdpDeBamartel");
            Console.WriteLine("Avec 2 utilisateurs égaux : " + listU[0].Equals(utilisateur1));
            Console.WriteLine("Avec 2 objet différents : " + listU[0].Equals(exercice1));

            Console.WriteLine("------------------------------");

            //Test Hashcode
            Console.WriteLine("Test Hashcode");
            Console.WriteLine(listU[0].GetHashCode());

            Console.WriteLine("------------------------------");

            //Test Lancer Programme ( même chose c'est pas dans le test Unitaire qu'on fait ça ? )
            //On créer un programme en lui ajoutant une liste d'exercice, on lance 2 fois la méthode LancerProgramme à un même utilisateur pour observer
            //si les variables DernierProgramme et DiffDernierProg ont bien été modifié.
            Programme programme = new Programme("PUSH", "Programme qui fait travailler les pectoraux,triceps et épaules", "chemin image programme PUSH");
            var listExo = new LinkedList<Exercice>();
            listExo.AddLast(new Exercice("Traction", "chemin img traction", new Valeur(8, 4, 80), new Valeur(10, 4, 70), new Valeur(12, 4, 60)));
            Exercice e = new Exercice("Test", "chemin test", new Valeur(8, 4, 80), new Valeur(10, 4, 70), new Valeur(12, 4, 60));
            listExo.AddLast(e);
            programme.LesExercices = listExo;
            Programme programme2 = new Programme("Test", "Testtest", "test chemin")
            {
                LesExercices = listExo
            };


            utilisateur1.LancerProgramme(programme, Difficulte.DEBUTANT);
            Console.WriteLine($" Dernier programme de l'utilisateur : {utilisateur1.DernierProgramme} Derniere difficulte de l'utilisateur {utilisateur1.DiffDernierProg}");
            
            utilisateur1.LancerProgramme(programme2, Difficulte.EXPERT);
            Console.WriteLine($" Dernier programme de l'utilisateur : {utilisateur1.DernierProgramme} Derniere difficulte de l'utilisateur {utilisateur1.DiffDernierProg}");
        }
    }
}
