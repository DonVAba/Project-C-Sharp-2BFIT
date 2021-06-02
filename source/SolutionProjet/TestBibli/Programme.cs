using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Application
{
    [DataContract]
    public class Programme : Nommable, INotifyPropertyChanged
    {


        /// <summary>
        /// Description du programme
        /// </summary>
        private string description;
        public string Description
        {
            get => description;
            set 
            { 
                if(description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        /// <summary>
        /// Nombre d'exercice d'un programme (à moitié facultatif car il va être affiché)
        /// </summary>
        private int nbExercices;
        public int NbExercices
        {
            get => nbExercices;
            set 
            {
                nbExercices = LesExercices.Count();
            }
            
        }

        public void SetNbExercices()
        {
            nbExercices = LesExercices.Count();
        }

        public void SetNbExercices(int value)
        {
            nbExercices = value;
        }

        public int GetNbExercices()
        {
            return nbExercices;
        }

        /// <summary>
        /// Chemin de l'image associé au programme
        /// </summary>
        public string CheminImage { get; set; }

        /// <summary>
        /// Liste des exercices contenus dans le programme. 
        /// </summary>

        private ObservableCollection<Exercice> lesExercices; // ObservableCollection pour changer la propriété

        public ObservableCollection<Exercice> LesExercices 
        {
            get => lesExercices;
            set
            {
                if(lesExercices != value)
                {
                    lesExercices = value;
                    SetNbExercices();
                }
            } 
        }



        /// <summary>
        /// Constructeur de la classe Programme
        /// </summary>
        /// <param name="description"></param>
        /// <param name="cheminImage"></param>
        /// <param name="nom"></param>
        /// <param name="diff">Difficulté du programme qui va être converti en énum Difficulté</param>
        public Programme(string nom,string description, string cheminImage) : base(nom)
        {
            Description = description;
            CheminImage = cheminImage;
            LesExercices = new ObservableCollection<Exercice>();
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
        public bool Equals(Programme other)
        {
            return this.Nom.Equals(other.Nom);
        }

       

        /// <summary>
        /// Méthode renvoyant le HashCode du programme instancié
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }

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
            throw new Exception("Exercice rentré non trouvé "); // Envoie d'une nouvelle exception pour indiquer que l'exercice passé en paramètre n'a pas été trouvé

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
                LesExercices.Add(ex); // sinon ajout de l'exercice à la liste lesExercices du programme instancié
               
            }
            
        }
    }
}
