using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace Management
{

    /// CLASSE A MODIFIER : il ne faut pas avoir de données dans une classe manager, elle sert uniquement à délguer les "taches"
    /// donc en gros à vérifier les objets avec CreatorValidationObject et à appeller les méthodes de la classe Liste
    public static partial class Manager
    {


        /// <summary>
        /// Methode qui ajoute un programme
        /// </summary>
        /// <param name="programme"></param>
        public static void AjouterProgramme(Programme programme,Listes l)
        {
            if (CreationObjectValidator.ValidationAjoutProgramme(programme))
            {
                l.AjouterProgramme(programme);
            }
            else
            {
                throw new Exception("Non valid program");
            }
        }
        /// <summary>
        /// Methode pour suppr un programme en parcourant toute la liste de programme 
        /// </summary>
        /// <param name="programme"></param>
        public static void SupprimerProgramme(Programme programme,Listes l)
        {
            if (l.listProgrammes.Contains(programme))
            {
                l.SupprimerProgramme(programme);
            }
            else
                throw new ArgumentException("Error : program you want delete not found");
        }

        /// <summary>
        /// Méthode qui permet d'ajouter un exercice à un programme déjà instancié
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="ex"></param>
        public static void AjouterUnExercice(Programme prog, Exercice ex,Listes l)
        {
            if (CreationObjectValidator.ValidationAjoutExercice(ex))
            {
                l.AjouterUnExercice(prog, ex);
            }
            else
                throw new ArgumentException("Error : exercice you want add to prog.lesExercices is non-valid");
            
        }


        /// <summary>
        /// Méthode qui permet d'ajouter les exercices rentrés à la liste d'exercice d'un programme qui vient d'être instancié
        /// en les vérifiant et ajoutant un par un (vérification dans la méthode AjouterUnExercice()
        /// </summary>
        /// <param name="prog">programme choisi</param>
        /// <param name="listEx">Liste dex exercices rentrés dans la vue</param>
        public static void AjouterListExerciceALaCreationDunProgramme(Programme prog, LinkedList<Exercice> listEx,Listes l)
        {
            if (CreationObjectValidator.ValidationAjoutProgramme(prog))
            {
                l.AjouterListExerciceALaCreationDunProgramme(prog, listEx);

            }
            else throw new ArgumentException("Error : programme incorrect");
        }

        
    }
}
