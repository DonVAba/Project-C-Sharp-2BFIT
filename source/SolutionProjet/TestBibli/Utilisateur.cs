using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Application
{
    public class Utilisateur : Nommable, IComparable, IComparable<Utilisateur>, IEquatable<Utilisateur>, INotifyPropertyChanged
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
            get => taille;
            set
            {
                if (value > 50 && value < 260)
                {
                    taille = value;
                    OnPropertyChanged(nameof(Taille));
                }
            }
        }

        /// <summary>
        /// Poids de l'utilisateur
        /// </summary>

        private float poids;
        public float Poids
        {
            get => poids;
            
            set
            {
                if (value > 20 && value < 200)
                {
                    poids = value;
                    OnPropertyChanged(nameof(Poids));
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
        private Programme dernierProgramme;
        public Programme DernierProgramme 
        {
            get => dernierProgramme;
            set
            {
                if (dernierProgramme != value)
                {
                    dernierProgramme = value;
                    OnPropertyChanged("DernierProgramme");
                }

            }
        }

        /// <summary>
        /// Difficulté du dernier programme effectué
        /// </summary>
        private Difficulte diffDernierProg;
        public Difficulte DiffDernierProg 
        {
            get => diffDernierProg;
            set
            {
                if (diffDernierProg != value)
                {
                    diffDernierProg = value;
                    OnPropertyChanged("DiffDernierProg");
                }

            }
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
        private int CalculAge(DateTime dateNaissance)
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
            this.DernierProgramme = prog;
            this.DiffDernierProg = diff;


        }

        /// <summary>
        /// Méthode renvoyant le profil d'un utilisateur
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Prenom : {Prenom} Nom : {Nom} Age : {Age} Taille : {Taille} Poids : {Poids} Identifiant {Identifiant} Mdp : {Mdp}";
        }

        /// <summary>
        /// Méthode qui renvoie un entier pour comparer l'utilisateur this et l'objet passé en paramètre 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            if(!(obj is Utilisateur)) // Si l'objet passé en pramètre n'est pas un Utilisateur
            {
                throw new ArgumentException("Error : l'objet à comparer n'est pas un Utilisateur"); // Envoie d'une Argument Exception
            }
            Utilisateur user = obj as Utilisateur; // Cast de l'objet obj en Utilisateur
            return this.CompareTo(user); // Retourne le retour de la méthode CompareTo recevant un Utilisateur en paramètres 
        }

        /// <summary>
        /// Méthode qui renvoie un entier pour comparer l'utilisateur this et l'utilisateur passé en paramètre
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int CompareTo(Utilisateur user)
        {
            return Identifiant.CompareTo(user.Identifiant); // retourne un entier <0 si l'identifiant de this est plus petit, 0 si il est égal et >0 si il est plus grand, à l'identifiant de l'utilisateur passé en paramètres
        }

        /// <summary>
        /// Méthode qui rédéfini la méthode Equals 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object other)
        {
            if(!(other is Utilisateur)) // Si l'object passé en paramètre n'est pas un utilisateur
            {
                return false; // retourne false
            }
            return Equals(other as Utilisateur); // sinon appelle de la méthode Equals recevant un Utilisateur en paramètre, ici le paramètre  est la variable obj passé en paramètres, qui a été cast en utilisateur
        }

        /// <summary>
        /// Equals qui reçoit un utilisateur en paramètres
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Equals(Utilisateur user) 
        {
            return Identifiant.Equals(user.Identifiant); // retourne 0 si l'identifiant de this est le même que celui de user
        }

        /// <summary>
        /// Méthode renvoyant un HashCode basé sur l'ientifiant
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Identifiant.GetHashCode();
        }

        /// <summary>
        /// Méthode qui redéfini l'opérateur == 
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns>

        public static bool operator ==(Utilisateur u1,Utilisateur u2)
        {
            return Equals(u1, u2);
        }

        /// <summary>
        /// Méthode qui rédéfini l'opérateur !=
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns>
        public static bool operator !=(Utilisateur u1, Utilisateur u2)
        {
            return !Equals(u1, u2);
        }

    }
}
