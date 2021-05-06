using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace Management
{
    /// <summary>
    /// Classe sérializable avec la liste des programme
    /// </summary>
    public partial class Manager
    {


        /// <summary>
        /// Liste de tous les programmes
        /// </summary>
        public LinkedList<Programme> listProgrammes;

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
                    throw new Exception("Programm not found");
                }
            }
        }



        /// <summary>
        /// Méthode qui permet d'ajouter les exercices rentrés à la liste d'exercice d'un programme qui vient d'être instancié
        /// en les vérifiant et ajoutant un par un
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
                    if (CreationObjectValidator.ValidationAjoutExercice(exo))
                    {
                        ProgrammeChoisi.LesExercices.AddLast(exo);
                    }
                    else throw new ArgumentException("Error : exercice incorrect");
                }
                return;

            }
            else throw new ArgumentException("Error : programme incorrect");
        }

        /// <summary>
        /// Méthode qui permet d'ajouter un exercice à un programme déjà instancié
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="ex"></param>
        public void AjouterUnExercice(Programme prog, Exercice ex)
        {
            ProgrammeChoisi = prog;
            if (CreationObjectValidator.ValidationAjoutExercice(ex))
            {
                ProgrammeChoisi.LesExercices.AddLast(ex);
            }
            else throw new ArgumentException("Error : exercice rentré incomplet");
        }
    }
}
