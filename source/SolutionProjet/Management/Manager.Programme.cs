using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace Management
{

    /// CLASSE A MODIFIER : il ne faut pas avoir de données dans une classe manager, elle sert uniquement à délguer les "taches"
    /// donc en gros à vérifier les objets avec CreatorValidationObject et à appeller les méthodes de la classe Liste
    public partial class Manager
    {


        /// <summary>
        /// Liste de tous les programmes
        /// </summary>
        public LinkedList<Programme> listProgrammes = new LinkedList<Programme>();

        /// <summary>
        /// Methode qui ajoute un programme
        /// </summary>
        /// <param name="programme"></param>
        public void AjouterProgramme(Programme programme)
        {
            if (CreationObjectValidator.ValidationAjoutProgramme(programme))
            {
                listProgrammes.AddFirst(programme);
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
        public void SupprimerProgramme(Programme programme)
        {
            foreach (var prog in listProgrammes)
            {
                if (programme.Equals(prog))
                {
                    listProgrammes.Remove(programme);
                }
                else
                {
                    throw new ArgumentException("Programm not found");
                }
            }
        }

        /// <summary>
        /// Méthode qui permet d'ajouter un exercice à un programme déjà instancié
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="ex"></param>
        public void AjouterUnExercice(Programme prog, Exercice ex)
        {
            ProgrammeChoisi = prog;
            if(ProgrammeChoisi.LesExercices is null)
            {
                ProgrammeChoisi.LesExercices = new LinkedList<Exercice>();
            }
            if (CreationObjectValidator.ValidationAjoutExercice(ex))
            {
                ProgrammeChoisi.LesExercices.AddLast(ex);
            }
            else throw new ArgumentException("Error : exercice rentré incomplet");
        }


        /// <summary>
        /// Méthode qui permet d'ajouter les exercices rentrés à la liste d'exercice d'un programme qui vient d'être instancié
        /// en les vérifiant et ajoutant un par un (vérification dans la méthode AjouterUnExercice()
        /// </summary>
        /// <param name="prog">programme choisi</param>
        /// <param name="listEx">Liste dex exercices rentrés dans la vue</param>
        public void AjouterListExerciceALaCreationDunProgramme(Programme prog, LinkedList<Exercice> listEx)
        {
            if (CreationObjectValidator.ValidationAjoutProgramme(prog))
            {
                AjouterProgramme(prog);
                ProgrammeChoisi = prog;
                foreach (var exo in listEx)
                {
                   AjouterUnExercice(ProgrammeChoisi, exo);  
                }
                return;

            }
            else throw new ArgumentException("Error : programme incorrect");
        }

        
    }
}
