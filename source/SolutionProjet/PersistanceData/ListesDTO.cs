using Application;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;

namespace PersistanceData
{
    [DataContract]
    public class ListesDTO
    {
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public List<UtilisateurDTO> ListComptes { get; set; } = new List<UtilisateurDTO>();

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public ObservableCollection<ProgrammeDTO> ListProgrammes { get; set; } = new ObservableCollection<ProgrammeDTO>();


    }
    static class ListesExtensions
    {
        public static ListesDTO ToDTO(this Listes poco)
        {
            List<UtilisateurDTO> comptes = new List<UtilisateurDTO>();
            foreach (var kvp in poco.listComptes)
            {
                comptes.Add(kvp.Value.ToDTO());
            }
            return new ListesDTO
            {
                ListComptes = comptes,
                ListProgrammes = poco.ListProgrammes.ToDTOs()
            };
        }

        public static Listes ToPOCO(this ListesDTO dto)
        {
            Dictionary<string, Utilisateur> comptes = new Dictionary<string, Utilisateur>();
            foreach(var user in dto.ListComptes)
            {
                comptes.Add(user.ToPOCO().Identifiant, user.ToPOCO());
            }
            return new Listes(comptes, dto.ListProgrammes.ToPOCOs());
        }

    }
}
