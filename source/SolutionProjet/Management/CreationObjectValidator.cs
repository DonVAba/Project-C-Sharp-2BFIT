using System;
using Application;

namespace Management
{
    public static class CreationObjectValidator
    {
        /// <summary>
        /// Méthode qui va appeler les autres méthodes de validation en fonction du type de l'objet passé en paramètre
        /// </summary>
        /// <param name="value"> Objet reçu en paramètre</param>
        /// <returns></returns>
        public static bool ValidationObjet(Object value)
        {
            if(value is Utilisateur) // SI l'objet est un Utilisateur
            {
                return ValidationAjoutUser(value as Utilisateur); // Appel de la méthode ValidationAjoutUser et retourne la valeur de retour de cette dernière
            }
            if(value is Programme) // Si l'objet est un Programme
            {
                return ValidationAjoutProgramme(value as Programme); // Appel de la méthode ValidationAjoutProgramme et retourne la valeur de retour de cette dernière
            }
            if (value is Exercice) // Si l'objet est un éxercice
            {
                return ValidationAjoutExercice(value as Exercice);// Appel de la méthode ValidationAjoutExercice et retourne la valeur de retour de cette dernière
            }
            if (value is Valeur) // si l'objet est une valeur
            {
                return ValidationAjoutValeur(value as Valeur);// Appel de la méthode ValidationAjoutValeur et retourne la valeur de retour de cette dernière
            }

            return false;
        }
        /// <summary>
        /// Méthode appelé si l'objet reçu dans la méthode "ValidationObjet" est un Utilisateur
        /// </summary>
        /// <param name="user">Utilisateur à valider</param>
        /// <returns></returns>
        public static bool ValidationAjoutUser(Utilisateur user)
        {
            // La méthode va à chaque fois vérifier si les chaines de caractère ne sont pas null ou des espaces, et si c'est le cas, retourne false

                if (string.IsNullOrWhiteSpace(user.Nom)) 
                {
                    return false;
                }
                if (string.IsNullOrWhiteSpace(user.Prenom))
                {
                    return false;
                }
                if (string.IsNullOrWhiteSpace(user.Identifiant))
                {
                    return false;
                }
                if (string.IsNullOrWhiteSpace(user.Mdp))
                {
                    return false;
                }
                
                    
                if (user.Poids <= 0 || user.Taille <= 0 || user.Poids >= 300 || user.Taille >= 260) // Vérification de la validité des valeurs de Poids et Taille
                {
                return false;
                }

            return true; // Si il n'y a eu aucun problème, retourne true

        }

        /// <summary>
        /// Méthode appelé si l'objet reçu dans la méthode "ValidationObjet" est un Programme
        /// </summary>
        /// <param name="prog">Programme à valider</param>
        /// <returns></returns>
        public static bool ValidationAjoutProgramme(Programme prog)
        {
            // La méthode va à chaque fois vérifier si les chaines de caractère ne sont pas null ou des espaces, et si c'est le cas, retourne false
            if (string.IsNullOrWhiteSpace(prog.Nom))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(prog.Description))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(prog.CheminImage))
            {
                return false;
            }
            foreach(Exercice ex in prog.LesExercices) // Pour chasue Exercice de la lkist lesExercices du programme passé en paramètres
            {
                if (!ValidationAjoutExercice(ex)) // Si l'exercice n'est pas valide
                {
                    return false; // retourne false
                }
            }

            return true; // Si il n'y a eu aucun problème, retourne true
        }

        /// <summary>
        /// Méthode appelé si l'objet reçu dans la méthode "ValidationObjet" est un Exercice
        /// </summary>
        /// <param name="ex">Exercice à valider</param>
        /// <returns></returns>
        public static bool ValidationAjoutExercice(Exercice ex)
        {
            // La méthode va à chaque fois vérifier si les chaines de caractère ne sont pas null ou des espaces, et si c'est le cas, retourne false
            if (string.IsNullOrWhiteSpace(ex.Nom))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(ex.CheminImage))
            {
                return false;
            }
            if(!ValidationAjoutValeur(ex.ValeurDeb) || !ValidationAjoutValeur(ex.ValeurInter) || !ValidationAjoutValeur(ex.ValeurExpert)) // Si les 3 valeurs obligatoires pour l'instanciation d'un Exercice ne sont pas valides
            {
                return false; // retourne false
            }

            return true; // Si il n'y a eu aucun problème, retourne true
        }

        /// <summary>
        /// Méthode appelé si l'objet reçu dans la méthode "ValidationObjet" est une Valeur
        /// </summary>
        /// <param name="val">Valeur à valider</param>
        /// <returns></returns>
        public static bool ValidationAjoutValeur(Valeur val)
        {
            if (val.NbReps <= 0 || val.TpsRepos <= 0 || val.NbSeries <= 0) // Vérificationd e la validité des entier contenus dans les Valeurs
            {
                return false; // Retourne false si un ou plusieurs de ces entiers sont <= 0
            }
            return true; // Si il n'y a eu aucun problème, retourne true
        }
    }
}
