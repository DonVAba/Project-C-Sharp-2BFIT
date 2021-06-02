using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Application;

namespace PersistanceData
{
    public class StubData : IDataManager
    {

        /// <summary>
        /// Méthode de chargement de données qui appelle les autres méthodes de chargement pour retourner les données nécessaires
        /// au bon déroulement de l'application
        /// </summary>
        /// <returns></returns>

        private string filepath;
        public StubData(string chemin)
        {
            filepath = chemin;
        }
        public Listes ChargeDonnees()
        {
            ObservableCollection<Programme> programmeStub = ChargeListprogramme();
            List<Utilisateur> listUsers = ChargeListUsers();
            Dictionary<String, Utilisateur> listCompte = new Dictionary<String, Utilisateur>();
            foreach (Utilisateur user in listUsers)
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

            return new Listes(listCompte,programmeStub);

        }

        /// <summary>
        /// Méthode qui instancie 3 utilisateurs et 1 admin et qui retourne une liste contenant ces utilisateurs 
        /// </summary>
        /// <returns></returns>
        public List<Utilisateur> ChargeListUsers()
        {
            List<Utilisateur> listUser = new List<Utilisateur>() {
                new Utilisateur("Martel","Baptiste",new DateTime(2003, 1, 30),188,90,"bamartel","mdpDeBamartel"),
                new Utilisateur("Malea","Bastien",new DateTime(2002, 8, 11),188,90,"bamalea","mdpDeBamalea"),
                new Utilisateur("Bouhours","Cedric",new DateTime(1985, 10, 1),188,90,"admin","admin")
            };
            return listUser;

        }

        /// <summary>
        /// Méthode qui instancie 3 programmes, les insere dans une liste et retourne cette liste
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Programme> ChargeListprogramme()
        {

            (ObservableCollection<Exercice> listExercicePull, ObservableCollection<Exercice> listExercicePush, ObservableCollection<Exercice> listExerciceJambes) = ChargeListExercice();
            Programme push = new Programme("PUSH", "Programme qui fait travailler les pectoraux,triceps et épaules", "/Image;Component/img/imgprogramme/progpush.jpg");
            Programme pull = new Programme("PULL", "Programme qui fait travailler le dos et les biceps", "/Image;Component/img/imgprogramme/progpull.jpg");
            Programme jambes = new Programme("JAMBES", "Programme qui fait travailler les quadriceps et ischios", "/Image;Component/img/imgprogramme/progjambes.jpg");
            ObservableCollection<Programme> programmeStub = new ObservableCollection<Programme>();
            programmeStub.Add(pull);
            programmeStub.Add(push);
            programmeStub.Add(jambes);
            push.LesExercices = listExercicePush;
            pull.LesExercices = listExercicePull;
            jambes.LesExercices = listExerciceJambes;
            return programmeStub;

        }

        /// <summary>
        /// Méthode qui instancie 3 exercices pour chaque programme instancié, les insère dans 3 listes différentes et retourne ces listes
        /// </summary>
        /// <returns></returns>
        private (ObservableCollection<Exercice>, ObservableCollection<Exercice>, ObservableCollection<Exercice>) ChargeListExercice()
        {
            Valeur valDeb = new Valeur(8, 4, 80);
            Valeur valDeb2 = new Valeur(6, 4, 80);

            Valeur valInter = new Valeur(10, 4, 70);
            Valeur valInter2 = new Valeur(9, 5, 70);

            Valeur valExpert = new Valeur(12, 4, 60);
            Valeur valExpert2 = new Valeur(10, 5, 60);

            ObservableCollection<Exercice> listExercicePull = new ObservableCollection<Exercice>();
            ObservableCollection<Exercice> listExercicePush = new ObservableCollection<Exercice>();
            ObservableCollection<Exercice> listExerciceJambes = new ObservableCollection<Exercice>();
            listExercicePull.Add(new Exercice("Superman", "/Image;Component/img/imgExercice/exsuperman.jpg", valDeb, valInter, valExpert));
            listExercicePull.Add(new Exercice("Variante Superman", "/Image;Component/img/imgExercice/exsuperman2.jpg", valDeb2, valInter2, valExpert2));
            listExercicePull.Add(new Exercice("Rowing", "/Image;Component/img/imgExercice/extractionaustra.jpg", valDeb, valInter, valExpert));

            listExercicePush.Add(new Exercice("Dips", "/Image;Component/img/imgExercice/dips.png", valDeb, valInter, valExpert));
            listExercicePush.Add(new Exercice("Pompes surelevees", "/Image;Component/img/imgExercice/expompessur.jpg", valDeb2, valInter2, valExpert2));
            listExercicePush.Add(new Exercice("Gainage", "/Image;Component/img/imgExercice/exgainage.jpg", valDeb, valInter, valExpert));

            listExerciceJambes.Add(new Exercice("Squats", "/Image;Component/img/imgExercice/exsquat.jpg", valDeb2, valInter2, valExpert2));
            listExerciceJambes.Add(new Exercice("Hip Trust", "/Image;Component/img/imgExercice/exhiptrust.jpg", valDeb, valInter, valExpert));
            listExerciceJambes.Add(new Exercice("Fentes avant", "/Image;Component/img/imgExercice/exfentesavant.jpg", valDeb2, valInter2, valExpert2));
            listExerciceJambes.Add(new Exercice("Alternative Squat", "/Image;Component/img/imgExercice/exsquatcote.jpg", valDeb, valInter, valExpert));

            return (listExercicePull, listExercicePush, listExerciceJambes);

        }

        public void SauvegardeDonnees(Listes list)
        {
            return;
        }
    }
}
