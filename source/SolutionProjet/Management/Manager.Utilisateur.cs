using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace Management
{
    /// <summary>
    /// Classe sérializable avec la list des comptes, donc la liste des utilisateurs
    /// </summary>
    public partial class Manager
    {

        /// <summary>
        /// Dictionnaire contenant en clé les identifiants des utilisateurs et en valeur, leur mot de passe
        /// </summary>
        public Dictionary<string, Utilisateur> listComptes;


        /// <summary>
        /// Méthode d'ajout d'un utilisateur dans la list d'utilisateur, et dans la liste de compte
        /// </summary>
        /// <param name="user"></param>
        public void AjouterUtilisateurInscription(Utilisateur user, string id)
        {
            if (user == null || !CreationObjectValidator.ValidationAjoutUser(user))
            {
                throw new Exception("Error : null user ou null attribut");
            }
            else
            {
                if (listComptes.ContainsKey(id))
                {
                    throw new Exception("Error : login already used");
                }
                else
                {
                    listComptes.Add(id, user);
                    utilisateurCourant = user;
                }


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
            Utilisateur user = RechercherUtilisateur(login);
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

        /// <summary>
        /// Méthode qui recherche un utilisateur dans la liste de compte en fonction du login rentré
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Utilisateur RechercherUtilisateur(string login) // pas sur qu'elle soit utile
        {
            if (listComptes.ContainsKey(login))
            {
                listComptes.TryGetValue(login, out Utilisateur value);
                return value;
            }
            return null;
        }
    }
}
