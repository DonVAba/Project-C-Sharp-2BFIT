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

        public Utilisateur UtilisateurCourant { get; set; }

        /// <summary>
        /// Dictionnaire contenant en clé les identifiants des utilisateurs et en valeur, leur mot de passe
        /// </summary>
        public Dictionary<string, Utilisateur> listComptes;


        /// <summary>
        /// Programme choisi par un utilisateur avant de le lancer
        /// </summary>
        private Programme programmeChoisi;
        public Programme ProgrammeChoisi { get; set; }


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

        /// <summary>
        /// Méthode qui permet le lancement d'un programme dans la classe utilisateur à partir d'un programme et d'une difficulté
        /// et qui met à jour les valeurs du dernier programme effectué et de la difficulté de celui ci
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="diff"></param>
        public void LancementProgramme(Programme prog,String diff)
        {
            Enum.TryParse(diff, out Difficulte value);
            ProgrammeChoisi = prog;
            utilisateurCourant.LancerProgramme(ProgrammeChoisi, value);
            utilisateurCourant.DernierProgramme = prog;
            utilisateurCourant.DiffDernierProg = value;
        }

        /// <summary>
        /// Méthode qui permet d'ajouter les exercices rentrés à la liste d'exercice d'un programme qui vient d'être instancié
        /// en les vérifiant et ajoutant un par un
        /// </summary>
        /// <param name="prog">programme choisi</param>
        /// <param name="listEx">Liste dex exercices rentrés dans la vue</param>
        public void AjouterListExerciceALaCreationDunProgramme(Programme prog,LinkedList<Exercice> listEx)
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
        public void AjouterUnExercice(Programme prog,Exercice ex)
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
