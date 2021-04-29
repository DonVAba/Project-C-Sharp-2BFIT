using System;

namespace Application
{
    public class Utilisateur : Nommable
    {
        private Programme dernierProgramme;
        public string Prenom
        {
            get;
            private set;
        }

        public int Age
        {
            get;
            private set;
        }

        public int Taille
        {
            get;
            private set;
        }

        public float Poids
        {
            get;
            private set;
        }

        public string Identifiant
        {
            get;
            private set;
        }

        public string Mdp
        {
            get;
            private set;
        }


        public Utilisateur(string Nom, string prenom, int age, int taille, int poids, string identifiant, string mdp):base(Nom)
        {
            Prenom = prenom;
            Age = age;
            Taille = taille;
            Poids = poids;
            Identifiant = identifiant;
            Mdp = mdp;
        }

        public override string ToString()
        {
            return $"Prenom : {Prenom} Nom : {Nom} Age : {Age} Taille : {Taille} Poids : {Poids} Identifiant {Identifiant} Mdp : {Mdp}";
        }

    }
}
