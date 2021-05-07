using System;
using System.Collections.Generic;


namespace Application
{

    public class Utilisateur : Nommable, IComparable, IComparable<Utilisateur>, IEquatable<Utilisateur>
    {
       
        /// <summary>
        /// Prenom de l'utilisateur
        /// </summary>
        
        public string Prenom
        {
            get;
            private set;
        }

        public DateTime DateNaissance { get; set; }

        /// <summary>
        /// Age de l'utilisateur
        /// </summary>
        public int Age => CalculAge(DateNaissance);

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
        /// Dernier programme lancé par l'utilisateur
        /// </summary/
        public Programme DernierProgramme { get; set; }

        /// <summary>
        /// Difficulté du dernier programme effectué
        /// </summary>

        public Difficulte DiffDernierProg { get; set; }


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
        public Utilisateur(string Nom, string prenom, DateTime dateNaissance, int taille, float poids, string identifiant, string mdp):base(Nom)
        {
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Taille = taille;
            Poids = poids;
            Identifiant = identifiant;
            Mdp = mdp;
        }

        /// <summary>
        /// Méthode qui calcul l'âge de l'utilisateur à partir de sa date de naissance
        /// </summary>
        /// <param name="dateNaissance">Date de naissance de l'utilisateur</param>
        /// <returns>Age de l'utilisateur</returns>
        public int CalculAge(DateTime dateNaissance)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - dateNaissance.Year;
            if (dateNaissance > now.AddYears(-age))
                age--;
            return age;
        }

        /// <summary>
        /// Méthode qui permet le lancement d'un programme en définissant les valeurs courantes des exercices du programme choisi en fonction de la difficulté choisie
        /// </summary>
        /// <param name="prog">Programme choisi</param>
        /// <param name="diff">Difficulté choisie</param>
        public void LancerProgramme(Programme prog, Difficulte diff)
        {
            LinkedList<Exercice> list = prog.LesExercices;
            foreach(var ex in list)
            {
                if (diff.ToString().Equals("DEBUTANT"))
                {
                    ex.ValeurCourante = ex.ValeurDeb;
                }
                if (diff.ToString().Equals("INTERMEDIAIRE"))
                {
                    ex.ValeurCourante = ex.ValeurInter;
                }
                if (diff.ToString().Equals("EXPERT"))
                {
                    ex.ValeurCourante = ex.ValeurExpert;
                }
            }
            
            
        }

        /// <summary>
        /// Méthode renvoyant une forme écrite d'un utilisateur
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Prenom : {Prenom} Nom : {Nom} Age : {Age} Taille : {Taille} Poids : {Poids} Identifiant {Identifiant} Mdp : {Mdp}";
        }

        int IComparable.CompareTo(object obj)
        {
            if(!(obj is Utilisateur))
            {
                throw new ArgumentException("Error : l'objet à comparer n'est pas un Utilisateur");
            }
            Utilisateur user = obj as Utilisateur;
            return this.CompareTo(user);
        }

        public int CompareTo(Utilisateur user)
        {
            return Identifiant.CompareTo(user.Identifiant);
        }

        public override bool Equals(object other)
        {
            if(!(other is Utilisateur))
            {
                return false;
            }
            return Equals(other as Utilisateur);
        }

        public bool Equals(Utilisateur user)
        {
            return Identifiant.Equals(user.Identifiant);
        }

        public override int GetHashCode()
        {
            return Identifiant.GetHashCode();
        }

        public static bool operator ==(Utilisateur u1,Utilisateur u2)
        {
            return Equals(u1, u2);
        }
        public static bool operator !=(Utilisateur u1, Utilisateur u2)
        {
            return !Equals(u1, u2);
        }

    }
}
