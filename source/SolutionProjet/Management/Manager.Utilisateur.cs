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
        /// Méthode d'ajout d'un utilisateur dans la list d'utilisateur, et dans la liste de compte
        /// </summary>
        /// <param name="user"></param>
        public void AjouterUtilisateurInscription(Utilisateur user)
        {
            if (user == null || !CreationObjectValidator.ValidationAjoutUser(user))
            {
                throw new Exception("Error : null user ou null attribut");
            }
            else
            {
                CurrentList.AjouterUtilisateurInscription(user);
            }
        }

        /// <summary>
        /// Méthode qui vérifie si le login correspond au mdp rentré lors de la connexion
        /// </summary>
        /// <param name="login"> Login rentré</param>
        /// <param name="mdp"> Mot de passe rentré </param>
        /// <returns></returns>
        public bool VerifierConnexion(String login, String mdp)
        {
            Utilisateur user = CurrentList.RechercherUtilisateur(login);
            if (user == null)
            {
                throw new ArgumentException("Error : ce login n'appartient à aucun utilisateur");
            }
            if (mdp.Equals(user.Mdp))
            {
                return true;
            }
            return false;


        }

    }
}
