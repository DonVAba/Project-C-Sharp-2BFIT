using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace Management
{
    public abstract class Manager
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

        /// <summary>
        /// Methode qui ajoute un programme
        /// </summary>
        /// <param name="programme"></param>
        public void AjouterProgramme(Programme programme)
        {
            if (CreationObjectValidator.ValidationAjoutProgramme(programme))
            {
                listProgrammes.Add(programme);
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
            foreach(var prog in listProgrammes)
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
        /// Méthode de vérification des programmes si supprimé ou non
        /// </summary>
        public void AfficherProgramme()
        {
            foreach(var programme in listProgrammes)
            {
                Console.WriteLine(programme);
            }
        }

        public Utilisateur UtilisateurCourant { get; set; }

        /// <summary>
        /// Méthode d'ajout d'un utilisateur dans la list d'utilisateur, et dans la liste de compte
        /// </summary>
        /// <param name="user"></param>
        public void AjouterUtilisateurInscription(Utilisateur user, string id)
        {
            if (user == null)
            {
                throw new Exception("Error : null user");
            }
            else
            {
                if (listComptes.ContainsKey(id))
                {
                    throw new Exception("Error : login already used");
                }
                else
                    listComptes.Add(id, user);

            }
        }

        /// <summary>
        /// Méthode quo vérifie si le login correspond au mdp rentré lors de la connexion
        /// </summary>
        /// <param name="login"> Login rentré</param>
        /// <param name="mdp"> Mot de passe rentré </param>
        /// <returns></returns>
        public bool VerifierConnexion(String login, String mdp)
        {
            if (listComptes.ContainsKey(login))
            {
                if (listComptes.TryGetValue(login, out Utilisateur value))
                {
                    return value.Mdp.Equals(mdp);
                }

            }
            return false;

        }

        /*public Utilisateur RechercherUtilisateur(string login) // pas sur qu'elle soit utile
        {
            if (listComptes.ContainsKey(login))
            {
                
            }
            return null;
        }
        */

        /*public bool ValidationExercice(Exercice e) /// Je suis pas sur de ce que fait la méthode, elle vérifie si l'exercice est valide dans un programme ? 
        {

        }

        public bool ValidationProgramme(Programme prog)///Même chose pour cette méthode 
        {

        }*/
    }
}
