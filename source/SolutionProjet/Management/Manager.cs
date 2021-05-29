using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace Management
{
    
    public partial class Manager
    {

        /// <summary>
        /// Méthode qui permet le lancement d'un programme dans la classe utilisateur à partir d'un programme et d'une difficulté
        /// et qui met à jour les valeurs du dernier programme effectué et de la difficulté de celui ci
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="diff"></param>
        ///<param name="list"> Listes instancié contenant la liste des comptes et des programmes </param>
        public static void LancementProgramme(Programme prog, String diff,Listes l)
        {
            if (!CreationObjectValidator.ValidationAjoutProgramme(prog)) // Si le programme passé en paramètres n'est pas valide 
            {
                throw new ArgumentException("Error : programme invalide"); // Envoie une exception
            }
            l.LancementProgramme(prog, diff); // Appelle la méthode Lancementprogramme de la classe Listes
        }

    }
}
