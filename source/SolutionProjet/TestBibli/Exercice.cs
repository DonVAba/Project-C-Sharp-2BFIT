using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application
{
    public class Exercice : Nommable
    {
        /// <summary>
        /// Valeur d'un exerice (Temps de repos, Nombre de séries, répétitions, si la difficulté choisie est "DEBUTANT"
        /// </summary>
        public Valeur ValeurDeb { get; set; }

        /// <summary>
        /// Valeur d'un exerice (Temps de repos, Nombre de séries, répétitions, si la difficulté choisie est "INTERMEDIAIRE"
        /// </summary>
        public Valeur ValeurInter { get; set; }

        /// <summary>
        /// Valeur d'un exerice (Temps de repos, Nombre de séries, répétitions, si la difficulté choisie est "INTERMEDIAIRE"
        /// </summary>
        public Valeur ValeurExpert { get; set; }

        /// <summary>
        /// Valeur qui varie en fonction du niveau de difficulté choisi du programme
        /// </summary>
        public Valeur ValeurCourante { get; set; }


        /// <summary>
        /// Chemin de l'image associé à l'exercice
        /// </summary>
        public string CheminImage { get; set; }

        /// <summary>
        /// Constructeur de la classe Exercice
        /// </summary>
        /// <param name="Nom">Nom de l'exercice</param>
        /// <param name="cheminImage"> Chemin de l'image associé</param>
        /// <param name="valeurDeb"> Valeur choisie si la difficulté du programme dans lequel il est contenu est "DEBUTANT"</param>
        /// <param name="valeurInter">Valeur choisie si la difficulté du programme dans lequel il est contenu est "INTERMEDIAIRE"</param>
        /// <param name="valeurExpert">Valeur choisie si la difficulté du programme dans lequel il est contenu est "EXPERT"</param>
        public Exercice(string nom, string cheminImage, Valeur valeurDeb, Valeur valeurInter, Valeur valeurExpert) : base(nom)
        {
            CheminImage = cheminImage;
            this.ValeurDeb = valeurDeb;
            this.ValeurInter = valeurInter;
            this.ValeurExpert = valeurExpert;

        }

        /// <summary>
        /// Méthode renvoyant une forme écrite d'un exercice
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Nom : {Nom} ;\nDebutant : {ValeurDeb}\nIntermédiaire : {ValeurInter}\n Expert : {ValeurExpert} ";
        }

        public bool Equals(Exercice ex)
        {
            return Nom.Equals(ex.Nom);
        }

        public override bool Equals(object other)
        {
            if (!(other is Exercice))
            {
                return false;
            }
            return Equals(other as Exercice);
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }

    }
}
