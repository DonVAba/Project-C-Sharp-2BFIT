using System;
using System.Collections.Generic;
using System.Linq;
using Application;

namespace Persistance
{
    public class StubData : DataLoad
    {
        /// <summary>
        /// Méthode de chargement de données qui appelle les autres méthodes de chargement pour retourner les données nécessaires
        /// au bon déroulement de l'application
        /// </summary>
        /// <returns></returns>
        /// 
        public StubData(string chemin) : base(chemin)
        {

        }
        public override Listes ChargeDonnees()
        {
            LinkedList<Programme> programmeStub = ChargeListprogramme();
            List<Utilisateur> listUsers = ChargeListUsers();
            Dictionary<String, Utilisateur> listCompte = new Dictionary<String, Utilisateur>();
            foreach(Utilisateur user in listUsers)
            {
                try
                {
                    listCompte.Add(user.Identifiant, user);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            }
            
            Listes list = new Listes(listCompte, programmeStub);
            //list.ProgrammeChoisi = programmeStub.First();
            return list;
        
    }

        /// <summary>
        /// Méthode qui instancie 3 utilisateurs et 1 admin et qui retourne une liste contenant ces utilisateurs 
        /// </summary>
        /// <returns></returns>
        public List<Utilisateur> ChargeListUsers()
        {
            List<Utilisateur> listUser = new List<Utilisateur>() {
                new Utilisateur("Martel","Baptiste",new DateTime(2003, 1, 30),88,190,"bamartel","mdpDeBamartel"),
                new Utilisateur("Malea","Bastien",new DateTime(2002, 8, 11),88,190,"bamalea","mdpDeBamalea"),
                new Utilisateur("Dallet","Simon",new DateTime(2002, 6, 12),88,190,"bamalea","mdpDeSimon"), // même identifiant fait exprès pour les tests du equals et de l'inscription
                new Utilisateur("Bouhours","Cedric",new DateTime(1950, 10, 1),88,190,"admin","admin")
            };
            return listUser;

        }

        /// <summary>
        /// Méthode qui instancie 3 programmes, les insere dans une liste et retourne cette liste
        /// </summary>
        /// <returns></returns>
        public LinkedList<Programme> ChargeListprogramme()
        {
            
            (LinkedList<Exercice> listExercicePull, LinkedList<Exercice> listExercicePush, LinkedList<Exercice> listExerciceJambes) = ChargeListExercice();
            Programme push = new Programme("PUSH", "Programme qui fait travailler les pectoraux,triceps et épaules  azeazeazeeeeeeeeeeeeeeeeeezazeaze", "/Image;Component/img/imgfond/background_ciel.jpg");
            Programme pull = new Programme("PULL", "Programme qui fait travailler le dos et les biceps azeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeaz", "/Image;Component/img/imgfond/background_ciel.jpg");
            Programme jambes = new Programme("JAMBES", "Programme qui fait travailler les quadriceps et ischios azeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeez", "/Image;Component/img/imgfond/background_ciel.jpg");
            LinkedList<Programme> programmeStub = new LinkedList<Programme>();
            programmeStub.AddLast(pull);
            programmeStub.AddLast(push);
            programmeStub.AddLast(jambes);
            push.LesExercices = listExercicePush;
            pull.LesExercices = listExercicePull;
            jambes.LesExercices = listExerciceJambes;
            return programmeStub;
            
        }

        /// <summary>
        /// Méthode qui instancie 3 exercices pour chaque programme instancié, les insère dans 3 listes différentes et retourne ces listes
        /// </summary>
        /// <returns></returns>
        private (LinkedList<Exercice>, LinkedList<Exercice>, LinkedList<Exercice>) ChargeListExercice()
        {
            Valeur valDeb = new Valeur(8,4,80);
            Valeur valInter = new Valeur(10, 4,70);
            Valeur valExpert = new Valeur(12,4,60);

            LinkedList<Exercice> listExercicePull = new LinkedList<Exercice>();
            LinkedList<Exercice> listExercicePush = new LinkedList<Exercice>();
            LinkedList<Exercice> listExerciceJambes = new LinkedList<Exercice>();
            listExercicePull.AddLast(new Exercice("Traction", "/Image;Component/img/imgfond/background_ciel.jpg", valDeb, valInter, valExpert));
            listExercicePull.AddLast( new Exercice("Traction australienne", "/Image;Component/img/imgfond/background_ciel.jpg", valDeb, valInter, valExpert));
            listExercicePull.AddLast(new Exercice("Rowing", "/Image;Component/img/imgfond/background_ciel.jpg", valDeb, valInter, valExpert));

            listExercicePush.AddLast(new Exercice("Dips", "/Image;Component/img/imgExercice/dips.png", valDeb, valInter, valExpert));
            listExercicePush.AddLast(new Exercice("Pompes surelevees", "/Image;Component/img/imgfond/background_ciel.jpg", valDeb, valInter, valExpert));
            listExercicePush.AddLast(new Exercice("Gainage", "/Image;Component/img/imgfond/background_ciel.jpg", valDeb, valInter, valExpert));

            listExerciceJambes.AddLast(new Exercice("Squats", "/Image;Component/img/imgfond/background_ciel.jpg", valDeb, valInter, valExpert));
            listExerciceJambes.AddLast(new Exercice("hip trust", "/Image;Component/img/imgfond/background_ciel.jpg", valDeb, valInter, valExpert));
            listExerciceJambes.AddLast(new Exercice("fentes avant ", "/Image;Component/img/imgfond/background_ciel.jpg", valDeb, valInter, valExpert));
            listExerciceJambes.AddLast(new Exercice("fentes arrière ", "/Image;Component/img/imgfond/background_ciel.jpg", valDeb, valInter, valExpert));

            return (listExercicePull, listExercicePush, listExerciceJambes);

        }
    }
}
