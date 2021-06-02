using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Application;

namespace PersistanceData
{
    [DataContract]
    public class UtilisateurDTO
    {

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Nom { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Prenom { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public DateTime DateNaissance { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public int Taille { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public float Poids { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string Identifiant { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string Mdp { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public ProgrammeDTO DernierProgramme { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public Difficulte DiffDernierProg { get; set; }
    }

    public static class UtilisateurExtensions
    {
        public static Utilisateur ToPOCO(this UtilisateurDTO dto)
        {
            var user = new Utilisateur(dto.Nom,dto.Prenom,dto.DateNaissance,dto.Taille,dto.Poids,dto.Identifiant,dto.Mdp);
            user.DernierProgramme = dto.DernierProgramme.ToPOCO();
            user.DiffDernierProg = dto.DiffDernierProg;
            return user;
        }

        public static List<Utilisateur> ToPOCOs(this List<UtilisateurDTO> dtos)
            => dtos.Select(user => user.ToPOCO()).ToList();

        public static UtilisateurDTO ToDTO(this Utilisateur poco)
            => new UtilisateurDTO
            {
                Nom = poco.Nom,
                Prenom = poco.Prenom,
                Identifiant = poco.Identifiant,
                Mdp = poco.Mdp,
                Taille = poco.Taille,
                Poids = poco.Poids,
                DateNaissance = poco.DateNaissance,
                DernierProgramme = poco.DernierProgramme.ToDTO(),
                DiffDernierProg = poco.DiffDernierProg
            };

        public static List<UtilisateurDTO> ToDTOs(this List<Utilisateur> pocos)
            => pocos.Select(user => user.ToDTO()).ToList();
    }
}
