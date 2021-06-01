using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Application;

namespace Application
{
    /// <summary>
    /// Classe qui sera sérializable
    /// </summary>
    
    [DataContract]
    public partial class Listes : INotifyPropertyChanged
    {
        /// <summary>
        /// Dictionnaire contenant en clé les identifiants des utilisateurs et en valeur, leur mot de passe
        /// </summary>
        
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public Dictionary<string, Utilisateur> listComptes;

        /// <summary>
        /// Liste de tous les programmes
        /// </summary>

        private ObservableCollection<Programme> listProgrammes; // ObservableCollection pour changer la propriété
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public ObservableCollection<Programme> ListProgrammes 
        { 
            get => listProgrammes; 
            set
            {
                listProgrammes = value;
            }
        }

        /// <summary>
        /// COnstructeur d'une liste avec des liste déjà inclu
        /// </summary>
        /// <param name="comptes"></param>
        /// <param name="programmes"></param>
        public Listes(Dictionary<string, Utilisateur> comptes, ObservableCollection<Programme> programmes)
        {
            listComptes = new Dictionary<string, Utilisateur>(comptes);
            ListProgrammes = new ObservableCollection<Programme>(programmes);
        }

        /// <summary>
        /// Constructeur de Listes avec uniquement un ditcionnaire de compte en paramètres
        /// </summary>
        public Listes(Dictionary<string, Utilisateur> comptes)
        {
            listComptes = new Dictionary<string, Utilisateur>(comptes);
            ListProgrammes = new ObservableCollection<Programme>();
        }

        /// <summary>
        /// Constructeur de Listes avec uniquement une liste de programme en paramètre
        /// </summary>
        public Listes(ObservableCollection<Programme> programmes)
        {
            listComptes = new Dictionary<string, Utilisateur>();
            ListProgrammes = new ObservableCollection<Programme>(programmes);
        }

        /// <summary>
        /// Constructeur de Listes sans aucun paramètres qui instancie les listes comptes et programmes
        /// </summary>
        public Listes()
        {
            listComptes = new Dictionary<string, Utilisateur>();
            ListProgrammes = new ObservableCollection<Programme>();
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
            if (listComptes.ContainsKey(login)) // regarde si la liste de compte contient le login
            {
                listComptes.TryGetValue(login, out Utilisateur value); // si le login est effectivement présent, on récupère l'utilisateur associé dans l'attribut value
                return value; // retourne cette utilisateur
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
            Utilisateur user = RechercherUtilisateur(login); // Instancie un nouvel utilisateur avec l'appelle de la méthode Rechercherutilisateur qui peut renvoyer soit null, soit un utilisateur
            if (user == null) // si l'utilisateur renvoyé est null
            {
                throw new ArgumentException("Error : ce login n'appartient à aucun utilisateur"); // On envoie une ArgumentException
            }
            if (mdp.Equals(user.Mdp)) // si user n'est pas null, on regarde la correspondace du mdp
            {
                return true; // renvoie true si le mdp correspond
            }
            return false; // sinon false


        }

        /// <summary>
        /// Méthode d'ajout d'un utilisateur dans la list d'utilisateur, et dans la liste de compte
        /// </summary>
        /// <param name="user"></param>
        public void AjouterUtilisateurInscription(Utilisateur user)
        {  
            if (listComptes.ContainsKey(user.Identifiant)) // regarde si la liste de compte contient l'identifiant
            {
                throw new ArgumentException("Error : login already used"); // Si oui, envoie une exception
            }
            else
            {
                listComptes.Add(user.Identifiant, user); //SInon ajoute l'utilisateur user à la liste de compte
                UtilisateurCourant = user; //L'utilisateur courant devient user
            }
        }


        /*
         * METHODES PROGRAMMES
        */

        /// <summary>
        /// Methode qui ajoute un programme en vérifiant qu'il n'existe pas déjà dans la liste
        /// </summary>
        /// <param name="programme"></param>
        public bool AjouterProgramme(Programme programme)
        {
            if (ListProgrammes.Contains(programme)) // regarde si la liste de compte contient déjà un programme équivalent (avec le même nom)
            { 
                return false; // retourne false si un programme a déjà le même nom
            }
            else
            {
                ListProgrammes.Add(programme); //sinon ajoute ce programme à la liste de programme
                return true; // et retourne true
            }
        }

        /// <summary>
        /// Methode pour suppr un programme en parcourant toute la liste de programme 
        /// </summary>
        /// <param name="programme"></param>
        public void SupprimerProgramme(Programme programme)
        {
            foreach (Programme prog in ListProgrammes) // pour chaque programme prog dans la liste des programmes
            {
                if (programme.Equals(prog)) // si le programme passé en paramètre a le même nom
                {
                    ListProgrammes.Remove(programme); // suppression du programme
                }
                else
                {
                    throw new ArgumentException("Programm not found"); // sinon on envoie une nouvelle Exception qui dit que le prorgramme n'a pas été trouvé
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
            ProgrammeChoisi = prog; // ProgrammeChoisi prend la valeur de prog
            if (ProgrammeChoisi.LesExercices is null) // Si sa liste d'exercice est nulle (ce qui n'est normalement pas censé arriver)
            {
                ProgrammeChoisi.LesExercices = new ObservableCollection<Exercice>(); // on instancie sa liste d'exercice
            }

            ProgrammeChoisi.AjouterExercice(ex); // on ajoute l'exercice à la liste lesExercices de ProgrammeChoisi en appelant la méthode AjouterExercice de la classe programme
            
        }


        /// <summary>
        /// Méthode qui permet d'ajouter les exercices rentrés à la liste d'exercice d'un programme qui vient d'être instancié
        /// en les vérifiant et ajoutant un par un (vérification dans la méthode AjouterUnExercice()
        /// </summary>
        /// <param name="prog">programme choisi</param>
        /// <param name="listEx">Liste dex exercices rentrés dans la vue</param>
        public void AjouterListExerciceALaCreationDunProgramme(Programme prog, LinkedList<Exercice> listEx)
        {
                AjouterProgramme(prog); // Appelle de la méthode AjouterProgramme pour ajouter prog à la list des programmes
                ProgrammeChoisi = prog; // ProgrammeChoisi prend la valeur de prog
                foreach (Exercice exo in listEx) // Pour chaque exercice dans la listEx(passée en paramètre)
                {
                    AjouterUnExercice(ProgrammeChoisi, exo); // Appelle de la méthode AjouterUnExercice
                }
                
        }

    }
}
