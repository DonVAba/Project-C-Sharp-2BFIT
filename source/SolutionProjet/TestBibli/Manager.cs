using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class Manager
    {
        /// <summary>
        /// Utilisateur Connecté
        /// </summary>
        private Utilisateur utilisateurCourant;

        /// <summary>
        /// Dictionnaire contenant en clé les identifiants des utilisateurs et en valeur, leur mot de passe
        /// </summary>
        public Dictionary<string, Utilisateur> listComptes;


        /// <summary>
        /// Liste de tous les programmes
        /// </summary>
        public IList<Programme> listProgrammes; 
        
        public Utilisateur UtilisateurCourant { get; set;}

        /// <summary>
        /// Méthode d'ajout d'un utilisateur dans la list d'utilisateur, et dans la liste de compte
        /// </summary>
        /// <param name="user"></param>
        public void AjouterUtilisateurInscription(Utilisateur user,string id) 
        {
            if (user == null)
            {
                throw new Exception("Error : null user");
            }
            else
            {
                if(listComptes.ContainsKey(id))
                {
                    throw new Exception("Error : login already used");
                }
                else
                    listComptes.Add(id, user);
                
            }
        }

        /// méthode pour vérifier la connexion (il faut que je trouve la méthode pour vérifier que le mot de passe est bien associé à la Key login)
        /*public bool VerifierConnexion(String login, String mdp)
        {
            if (listComptes.ContainsKey(login))
            {
                if (List)
            }
            else
                return false;
        }
        */
    }
}
