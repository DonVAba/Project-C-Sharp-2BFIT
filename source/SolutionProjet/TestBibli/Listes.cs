using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace Application
{
    /// <summary>
    /// Classe qui sera sérializable
    /// </summary>
    public partial class Listes
    {
        /// <summary>
        /// Dictionnaire contenant en clé les identifiants des utilisateurs et en valeur, leur mot de passe
        /// </summary>
        public Dictionary<string, Utilisateur> listComptes;

        /// <summary>
        /// Liste de tous les programmes
        /// </summary>
        public LinkedList<Programme> listProgrammes;

        /// <summary>
        /// COnstructeur d'une liste avec des liste déjà inclu
        /// </summary>
        /// <param name="comptes"></param>
        /// <param name="programmes"></param>
        public Listes(Dictionary<string, Utilisateur> comptes, LinkedList<Programme> programmes)
        {
            listComptes = new Dictionary<string, Utilisateur>(comptes);
            listProgrammes = new LinkedList<Programme>(programmes);
        }

        /// <summary>
        /// Constructeur de Listes avec uniquement un ditcionnaire de compte en paramètres
        /// </summary>
        public Listes(Dictionary<string, Utilisateur> comptes)
        {
            listComptes = new Dictionary<string, Utilisateur>(comptes);
            listProgrammes = new LinkedList<Programme>();
        }

        /// <summary>
        /// Constructeur de Listes avec uniquement une liste de programme en paramètre
        /// </summary>
        public Listes(LinkedList<Programme> programmes)
        {
            listComptes = new Dictionary<string, Utilisateur>();
            listProgrammes = new LinkedList<Programme>(programmes);
        }

        /// <summary>
        /// Constructeur de Listes sans aucun paramètres qui instancie les listes comptes et programmes
        /// </summary>
        public Listes()
        {
            listComptes = new Dictionary<string, Utilisateur>();
            listProgrammes = new LinkedList<Programme>();
        }


        /*
         * METHODES UTILISATEURS
        */

        /// <summary>
        /// Méthode qui cherche un utilisateur à partir d'un login passé en paramètre
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Null si le login ne correspond à aucun utilisateur sinon l'utilisateur</returns>
        public Utilisateur RechercherUtilisateur(string login)
        {
            if (listComptes.ContainsKey(login))
            {
                listComptes.TryGetValue(login, out Utilisateur value);
                return value;
            }
            return null;
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
        /// Méthode d'ajout d'un utilisateur dans la list d'utilisateur, et dans la liste de compte
        /// </summary>
        /// <param name="user"></param>
        public void AjouterUtilisateurInscription(Utilisateur user, string id)
        {  
            if (listComptes.ContainsKey(id))
            {
                throw new ArgumentException("Error : login already used");
            }
            else
            {
                listComptes.Add(id, user);
                UtilisateurCourant = user;
            }
        }


        /*
         * METHODES PROGRAMMES
        */

        /// <summary>
        /// Methode qui ajoute un programme
        /// </summary>
        /// <param name="programme"></param>
        public void AjouterProgramme(Programme programme)
        {
             listProgrammes.AddFirst(programme);
            
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
            if (ProgrammeChoisi.LesExercices is null)
            {
                ProgrammeChoisi.LesExercices = new LinkedList<Exercice>();
            }

            ProgrammeChoisi.AjouterExercice(ex);
            
        }


        /// <summary>
        /// Méthode qui permet d'ajouter les exercices rentrés à la liste d'exercice d'un programme qui vient d'être instancié
        /// en les vérifiant et ajoutant un par un (vérification dans la méthode AjouterUnExercice()
        /// </summary>
        /// <param name="prog">programme choisi</param>
        /// <param name="listEx">Liste dex exercices rentrés dans la vue</param>
        public void AjouterListExerciceALaCreationDunProgramme(Programme prog, LinkedList<Exercice> listEx)
        {
                AjouterProgramme(prog);
                ProgrammeChoisi = prog;
                foreach (var exo in listEx)
                {
                    AjouterUnExercice(ProgrammeChoisi, exo);
                }
                return;
        }

    }
}
