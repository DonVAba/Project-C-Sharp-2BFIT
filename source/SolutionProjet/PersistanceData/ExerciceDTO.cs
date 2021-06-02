using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Application;

namespace PersistanceData
{
    [DataContract]
    public class ExerciceDTO
    {
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string Nom { get; set; }
       
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public ValeurDTO ValeurDeb { get; set; }

        
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public ValeurDTO ValeurInter { get; set; }

        
        [DataMember(EmitDefaultValue = false, Order = 4)]
        public ValeurDTO ValeurExpert { get; set; }


        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string CheminImage { get; set; }
    }

    public static class ExerciceExtensions
    {
        public static Exercice ToPOCO(this ExerciceDTO dto)
            => new Exercice(dto.Nom, dto.CheminImage, dto.ValeurDeb.ToPOCO(), dto.ValeurInter.ToPOCO(), dto.ValeurExpert.ToPOCO());

        public static ObservableCollection<Exercice> ToPOCOs(this ObservableCollection<ExerciceDTO> dtos)
        {
            ObservableCollection<Exercice> pocos = new ObservableCollection<Exercice>();
            foreach(var dto in dtos)
            {
                pocos.Add(dto.ToPOCO());
            }
            return pocos;
        }

        public static ExerciceDTO ToDTO(this Exercice poco)
            => new ExerciceDTO
            {
                Nom = poco.Nom,
                CheminImage = poco.CheminImage,
                ValeurDeb = poco.ValeurDeb.ToDTO(),
                ValeurInter = poco.ValeurInter.ToDTO(),
                ValeurExpert = poco.ValeurExpert.ToDTO()
            };

        public static ObservableCollection<ExerciceDTO> ToDTOs(this ObservableCollection<Exercice> pocos)
        {
            ObservableCollection<ExerciceDTO> dtos = new ObservableCollection<ExerciceDTO>();
            foreach(var ex in pocos)
            {
                dtos.Add(ex.ToDTO());
            }
            return dtos;
        }

    }
}
