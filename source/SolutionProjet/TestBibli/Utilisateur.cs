using System;

namespace Application
{
    public class Utilisateur : Nommable
    {
        private Programme dernierProgramme;
        /// <summary>
        /// Prenom de l'utilisateur
        /// </summary>
        public string Prenom
        {
            get;
            private set;
        }

        /// <summary>
        /// Age de l'utilisateur
        /// </summary>
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            private set
            {
                if (value > 0 && value < 120)
                {
                    age = value;
                }
            }
        }

        /// <summary>
        /// Taille de l'utilisateur
        /// </summary>

        private int taille;
        public int Taille
        {
            get
            {
                return taille;
            }
            private set
            {
                if (value >50 && value <260)
                {
                    taille = value;
                }
            }
        }

        /// <summary>
        /// Poids de l'utilisateur
        /// </summary>

        private float poids;
        public float Poids
        {
            get
            {
                return poids;
            }
            private set
            {
                if (value > 20 && value < 200)
                {
                    poids = value;
                }
            }
        }

        /// <summary>
        /// Identifiant de l'utilisateur
        /// </summary>
        public string Identifiant
        {
            get;
            private set;
        }

        /// <summary>
        /// Mot de passe de l'utilisateur
        /// </summary>
        public string Mdp
        {
            get;
            private set;
        }

        /// <summary>
        /// Constructeur de la classe utilisateur
        /// </summary>
        /// <param name="Nom">Nom de l'utilisateur</param>
        /// <param name="prenom">Prenom de l'utilisateur</param>
        /// <param name="age">Age de l'utilisateur</param>
        /// <param name="taille">Taille de l'utilisateur</param>
        /// <param name="poids">Poids de l'utilisateur</param>
        /// <param name="identifiant">Identifiant de l'utilisateur</param>
        /// <param name="mdp">Mot de passe de l'utilisateur</param>
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
