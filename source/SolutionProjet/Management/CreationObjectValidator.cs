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
            if(value is Utilisateur)
            {
                return ValidationAjoutUser(value as Utilisateur);
            }
            if(value is Programme)
            {
                return ValidationAjoutProgramme(value as Programme);
            }
            if (value is Exercice)
            {
                return ValidationAjoutExercice(value as Exercice);
            }
            if (value is Valeur)
            {
                return ValidationAjoutValeur(value as Valeur);
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
                if (string.IsNullOrWhiteSpace(Convert.ToString(user.Age)))
                {
                    return false;
                }
                if (string.IsNullOrWhiteSpace(Convert.ToString(user.Taille)))
                {
                    return false;
                }
                if (string.IsNullOrWhiteSpace(Convert.ToString(user.Poids)))
                {
                    return false;
                }

            return true;

        }

        /// <summary>
        /// Méthode appelé si l'objet reçu dans la méthode "ValidationObjet" est un Programme
        /// </summary>
        /// <param name="prog">Programme à valider</param>
        /// <returns></returns>
        public static bool ValidationAjoutProgramme(Programme prog)
        {
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

            return true;
        }

        /// <summary>
        /// Méthode appelé si l'objet reçu dans la méthode "ValidationObjet" est un Exercice
        /// </summary>
        /// <param name="ex">Exercice à valider</param>
        /// <returns></returns>
        public static bool ValidationAjoutExercice(Exercice ex)
        {
            if (string.IsNullOrWhiteSpace(ex.Nom))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(ex.CheminImage))
            {
                return false;
            }
            if (ex.ValeurDeb is null || ex.ValeurExpert is null || ex.ValeurInter is null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Méthode appelé si l'objet reçu dans la méthode "ValidationObjet" est une Valeur
        /// </summary>
        /// <param name="val">Valeur à valider</param>
        /// <returns></returns>
        public static bool ValidationAjoutValeur(Valeur val)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(val.NbReps)))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(val.NbSeries)))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(val.TpsRepos)))
            {
                return false;
            }

            return true;
        }
    }
}
