using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Homepage.ucconnexion;
using Homepage.ucWindowAjout;
using Homepage.ucadmin;

namespace Homepage
{
    public class Navigator : INotifyPropertyChanged
    {

        /// <summary>
        /// Evenement qui permet de signaler à la vue par un évenement qu'une propriété a changé
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private Dictionary<string, UserControl> userControls = new Dictionary<string, UserControl>()
        {
            ["UC_Connexion"] = new ucconnexion.ucConnexion(),
            ["UC_Inscription"] = new ucInscription(),
            ["UC_AjoutExercice"] = new UCExercice(),
            ["UC_AjoutProg"] = new UCProgramme(),
            ["UC_ProfilAdmin"] = new AdminProfilUC(),
            ["UC_ProgAdmin"] = new ExercicePageUCAdmin()

        }; 

        public Dictionary<string, UserControl> UserControls { get; set; }

        /// <summary>
        /// Méthode permettant de naviguer vers un userControl dont le nom reçu en paramètre
        /// </summary>
        /// <param name="userControl"> nom du UserControl</param>
        public void NavigateTo(string userControl)
        {
            SelectedUserControl = userControls.GetValueOrDefault(userControl);
        }

        /// <summary>
        /// Méthode permettant de s'abonner à un UserControl prédéfini pour chaque évènement click dans le Xaml
        /// </summary>
        private void InitUserControls()
        {
            SelectedUserControl = userControls["UC_Connexion"]; //Définit par défault le UserControl sélectionné
        }

        /// <summary>
        /// instance unique du navigator 
        /// </summary>
        private static Navigator instanceUnique;

        /// <summary>
        /// Méthode qui vérifie qu'il n'y ai pas d'instance de navigator déja créée, si non alors elle l'instancie
        /// </summary>
        /// <returns>Navigator créé instanceUnique déja instanciée</returns>
        public static Navigator GetInstance() // singleton
        {
            if (instanceUnique == null)
            {
                instanceUnique = new Navigator();
            }
            return instanceUnique;
        }

        /// <summary>
        /// Méthode de navigation
        /// </summary>
        private Navigator()
        {
            InitUserControls();
        }

        /// <summary>
        /// User control sélectionné
        /// </summary>
        private UserControl selectedUserControl;
        public UserControl SelectedUserControl
        {
            get => selectedUserControl;
            set
            {
                selectedUserControl = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Méthode qui va informer
        /// </summary>
        /// <param name="propertyName"></param>
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedUserControl)));
    }
}
