using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class Programme : Nommable/*, IEquatable<Programme>*/
    {
        

        /// <summary>
        /// Description du programme
        /// </summary>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// Nombre d'exercice d'un programme (à moitié facultatif car il va êtr affiché)
        /// </summary>
        private int nbExercices;

        public int NbExercices
        {
            get => nbExercices;
            set
            {
                value = LesExercices.Count();
            }
            
        }

        /// <summary>
        /// Chemin de l'image associé au programme
        /// </summary>
        private string cheminImage;

        public string CheminImage
        {
            get => cheminImage;
            set => cheminImage = value;
        }

        /// <summary>
        /// Liste des exercices contenus dans le programme. 
        /// </summary>

        public LinkedList<Exercice> LesExercices { get; set; }


        /// <summary>
        /// Constructeur de la classe Programme
        /// </summary>
        /// <param name="description"></param>
        /// <param name="nbExercices"></param>
        /// <param name="cheminImage"></param>
        /// <param name="nom"></param>
        /// <param name="diff">Difficulté du programme qui va être converti en énum Difficulté</param>
        public Programme(string nom,string description, string cheminImage) : base(nom)
        {
            Description = description;
            CheminImage = cheminImage;
            LesExercices = new LinkedList<Exercice>();
        }

        

        /// <summary>
        /// Méthode de paramérage de la chaine de caractère renvoyé si une instance de cette classe veut être écrite sur une COnsole ou Debug
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return  $"{Nom}";
        }

        /// <summary>
        /// Méthode qui compare 2 programmes entre eux
        /// </summary>
        /// <param name="other">Programme à comparer</param>
        /// <returns></returns>
        //public bool Equals(Programme other)
        //{
        //    return this.Nom.Equals(other.Nom);
        //}

        /// <summary>
        /// Méthode qui vérifie que l'objet passé en paramètre est un programme et qui appelle la méthode Equals avec un Programme passé en paramètres
        /// </summary>
        /// <param name="value">Objet à comparer</param>
        /// <returns></returns>
        //public override bool Equals(Object value)
        //{
        //    /*if(!(value is Programme))
        //    {
        //        throw new ArgumentException("Error : l'objet passé en paramètre n'est pas un programme");
        //    }*/
        //    return Equals(value as Programme);
        //}

        /// <summary>
        /// Méthode renvoyant le HashCode du programme instancié
        /// </summary>
        /// <returns></returns>
        //public override int GetHashCode()
        //{
        //    return Nom.GetHashCode();
        //}

        /// <summary>
        /// Méthode qui supprime un exercice, je l'ai ajouté je me suis dit si on ajoute un exo ca serait plus logique si on peut les supprimer aussi
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public void SupprimerExercices(Exercice e)
        {
            foreach (Exercice exo in LesExercices) // pour chaque Exercice dans la LinkedList lesExercices
            {
                if (e.Equals(exo)) // si l'exercice a le même nom que e
                {
                    LesExercices.Remove(e); // Suppression de l'exercice
                    return;
                }
            }
            throw new Exception("Exercice rentré non trouvé "); // Envoie d'une nouvelle excpetion pour indiquer que l'exercice passé en paramètre n'a pas été trouvé

        }

        /// <summary>
        /// Ajoute un exercice à la liste d'exercice lesExercices
        /// </summary>
        /// <param name="ex"></param>
        public void AjouterExercice(Exercice ex)
        {
            if (LesExercices.Contains(ex)) // Si la linkedList lesExercices du programme instancié contient un exercice avec le même nom que celui passé en paramètres
            {
                throw new ArgumentException("Exercice rentré déjà existant"); // Envoie d'une ArgumentException
            }
            else
            {
                LesExercices.AddLast(ex); // sinon ajout de l'exercice à la liste lesExercices du programme instancié
               
            }
            
        }
    }
}
