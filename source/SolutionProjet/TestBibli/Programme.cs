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
        /// Nombre d'exercice d'un programme 
        /// </summary>
        private int nbExercices;
        public int NbExercices
        {
            get => nbExercices;
            set 
            { 
                nbExercices = LesExercices.Count(); // par défaut, le nombre d'exercice est le nombre d'élémments présent dans la liste
            }
            
        }

        public void SetNbExercices() 
        {
            nbExercices = LesExercices.Count();
        }

        /// <summary>
        /// Permet de définir le nobre d'exercice avec une valeur passé en paramètres
        /// Est utilie pour l'ajout d'un programme
        /// </summary>
        /// <param name="value"></param>
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
        /// Méthode qui supprime un exercice
        /// </summary>
        /// <param name="e"> Exercice courant</param>
        /// <returns></returns>
        public void SupprimerExercices(Exercice e)
        {

            if (LesExercices.Contains(e))//Vérification que l'ObservableCollection contient l'exercice courant 
                LesExercices.Remove(e);// Suppression de l'exercice courant 
            else 
                throw new Exception("Exercice rentré non trouvé "); //Exception si l'exercice n'est pas trouvé

        }

        /// <summary>
        /// Ajoute un exercice à l'ObservableCollection<Exercice> lesExercices
        /// </summary>
        /// <param name="ex"></param>
        public void AjouterExercice(Exercice ex)
        {
            if (LesExercices.Contains(ex)) // Vérification que l'ObservableCollection lesExercices contient déjà l'exercice
            {
                throw new ArgumentException("Exercice rentré déjà existant"); // Envoie d'une ArgumentException
            }
            else
            {
                LesExercices.Add(ex); // Ajout de l'exercice dans l'ObservableCollection lesExercices
            }
            
        }
    }
}
