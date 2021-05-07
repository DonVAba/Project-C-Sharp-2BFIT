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
        /// Méthode qui permet le lancement d'un programme dans la classe utilisateur à partir d'un programme et d'une difficulté
        /// et qui met à jour les valeurs du dernier programme effectué et de la difficulté de celui ci
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="diff"></param>
        public static void LancementProgramme(Programme prog, String diff,Listes l)
        {
            l.LancementProgramme(prog, diff);
        }

    }
}
