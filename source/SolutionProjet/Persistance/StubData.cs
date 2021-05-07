using System;
using System.Collections.Generic;
using Application;

namespace Persistance
{
    public class StubData : IDataLoad
    {

        public override (LinkedList<Programme>, Dictionary<String, Utilisateur>) ChargeDonnees()
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
            return (programmeStub, listCompte);
        }

        public List<Utilisateur> ChargeListUsers()
        {
            List<Utilisateur> listUser = new List<Utilisateur>() {
                new Utilisateur("Martel","Baptiste",new DateTime(2003, 1, 30),190,190,"bamartel","mdpDeBamartel"),
                new Utilisateur("Malea","Bastien",new DateTime(2002, 8, 11),190,190,"bamalea","mdpDeBamalea"),
                new Utilisateur("Dallet","Simon",new DateTime(2002, 6, 12),190,190,"bamalea","mdpDeSimon"), // même identifiant fait exprès pour les tests du equals et de l'inscription
                new Admin("Bouhours","Cecric",new DateTime(1950, 10, 1),190,190,"admin","mdpAdmin")
            };
            return listUser;

        }

        public LinkedList<Programme> ChargeListprogramme()
        {
            
            (LinkedList<Exercice> listExercicePull, LinkedList<Exercice> listExercicePush, LinkedList<Exercice> listExerciceJambes) = ChargeListExercice();
            Programme push = new Programme("PUSH", "Programme qui fait travailler les pectoraux,triceps et épaules", "chemin image programme PUSH");
            Programme pull = new Programme("PULL", "Programme qui fait travailler le dos et les biceps", "chemin image programme PULL");
            Programme jambes = new Programme("JAMBES", "Programme qui fait travailler les quadriceps et ischios", "chemin image programme JAMBES");
            LinkedList<Programme> programmeStub = new LinkedList<Programme>();
            programmeStub.AddLast(pull);
            programmeStub.AddLast(push);
            programmeStub.AddLast(jambes);
            push.LesExercices = listExercicePush;
            pull.LesExercices = listExercicePull;
            jambes.LesExercices = listExerciceJambes;
            return programmeStub;
            
        }

        public (LinkedList<Exercice>, LinkedList<Exercice>, LinkedList<Exercice>) ChargeListExercice()
        {
            Valeur valDeb = new Valeur(8,4,80);
            Valeur valInter = new Valeur(10, 4,70);
            Valeur valExpert = new Valeur(12,4,60);

            LinkedList<Exercice> listExercicePull = new LinkedList<Exercice>();
            listExercicePull.AddLast(new Exercice("Traction", "chemin img traction", valDeb, valInter, valExpert));
            listExercicePull.AddLast( new Exercice("Traction australienne", "chemin img traction australienne", valDeb, valInter, valExpert));
            listExercicePull.AddLast(new Exercice("Rowing", "chemin img rowing", valDeb, valInter, valExpert));

            LinkedList<Exercice> listExercicePush = new LinkedList<Exercice>();
            listExercicePull.AddLast(new Exercice("Dips", "chemin img dips", valDeb, valInter, valExpert));
            listExercicePull.AddLast(new Exercice("Pompes surelevees", "chemin img pompes surelevees", valDeb, valInter, valExpert));
            listExercicePull.AddLast(new Exercice("Gainage", "chemin img gainage", valDeb, valInter, valExpert));

            LinkedList<Exercice> listExerciceJambes = new LinkedList<Exercice>();
            listExercicePull.AddLast(new Exercice("Squats", "chemin img squats", valDeb, valInter, valExpert));
            listExercicePull.AddLast(new Exercice("hip trust", "chemin img hips trust", valDeb, valInter, valExpert));
            listExercicePull.AddLast(new Exercice("fentes avant ", "chemin fentes avant", valDeb, valInter, valExpert));
            listExercicePull.AddLast(new Exercice("fentes arrière ", "chemin fentes arrière", valDeb, valInter, valExpert));

            return (listExercicePull,listExercicePush,listExerciceJambes);

        }
    }
}
