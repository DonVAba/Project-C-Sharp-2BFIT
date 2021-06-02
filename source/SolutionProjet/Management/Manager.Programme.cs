using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace Management
{

    public partial class Manager
    {
        ///Paramètre passé à toutes les méthodes 
        ///<param name="list"> Listes instancié contenant la liste des comptes et des programmes </param>

        /// <summary>
        /// Methode qui ajoute un programme
        /// </summary>
        /// <param name="programme"></param>
        public void AjouterProgramme(Programme programme)
        {
            if (CreationObjectValidator.ValidationAjoutProgramme(programme)) // Si le programme passé en paramètres est valide
            {
                CurrentList.AjouterProgramme(programme); // Appelle de la méthode AjouterProgramme de la classe Listes
            }
            else
            {
                throw new Exception("Non valid program"); // Sinon envoi une exception
            }
        }
        /// <summary>
        /// Methode pour supprimer un programme en parcourant toute la liste de programme 
        /// </summary>
        /// <param name="programme"></param>
        public void SupprimerProgramme(Programme programme)
        {
            if (CurrentList.ListProgrammes.Contains(programme)) // Si la listprogramme de la Listes l passé en paramètre contient un programme avec le même nom
            {
                CurrentList.SupprimerProgramme(programme); // Appel de la méthode SupprimerProgramme2
            }
            else
                throw new ArgumentException("Error : program you want delete not found");// sinon envoie une ArgumentException
        }

        /// <summary>
        /// Méthode qui permet d'ajouter un exercice à un programme déjà instancié
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="ex"></param>
        public void AjouterUnExercice(Programme prog, Exercice ex)
        {
            if (CreationObjectValidator.ValidationAjoutExercice(ex)) // Si l'exercice passé en paramètres est valide
            {
                CurrentList.AjouterUnExercice(prog, ex); // Appel de la méthode AjouterUnExercice
            }
            else
                throw new ArgumentException("Error : exercice you want add to prog.lesExercices is non-valid"); // sinon envoie une ArgumentException

        }


        /// <summary>
        /// Méthode qui permet d'ajouter les exercices rentrés à la liste d'exercice d'un programme qui vient d'être instancié
        /// en les vérifiant et ajoutant un par un (vérification dans la méthode AjouterUnExercice()
        /// </summary>
        /// <param name="prog">programme choisi</param>
        /// <param name="listEx">Liste dex exercices rentrés dans la vue</param>
        public void AjouterListExerciceALaCreationDunProgramme(Programme prog, LinkedList<Exercice> listEx)
        {
            if (CreationObjectValidator.ValidationAjoutProgramme(prog))// Si le programme passé en paramètres est valide
            {
                CurrentList.AjouterListExerciceALaCreationDunProgramme(prog, listEx); // Appel de la méthode AjouterListExerciceALaCreationDunProgramme dde la classe Liste

            }
            else throw new ArgumentException("Error : programme incorrect");// sinon envoie une ArgumentException
        }

        
    }
}
