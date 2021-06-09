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

    
    /// Classe sérialisable et miroir de la classe Exercice

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

    /// <summary>
    /// Classe d'extension contenant les méthodes permettant de passer un objet DTO en POCO et inversement
    /// </summary>
    public static class ExerciceExtensions
    {

        /// <summary>
        /// Transforme un exerciceDTO en exercicePOCO  pour la désérialisation
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Exercice ToPOCO(this ExerciceDTO dto)
            => new Exercice(dto.Nom, dto.CheminImage, dto.ValeurDeb.ToPOCO(), dto.ValeurInter.ToPOCO(), dto.ValeurExpert.ToPOCO());

        /// <summary>
        /// transforme une collection d'exerciceDTO en collection d'exercicePOCO
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static ObservableCollection<Exercice> ToPOCOs(this ObservableCollection<ExerciceDTO> dtos)
        {
            ObservableCollection<Exercice> pocos = new ObservableCollection<Exercice>();
            foreach(var dto in dtos)
            {
                pocos.Add(dto.ToPOCO());
            }
            return pocos;
        }

        /// <summary>
        /// Transforme un exercicePOCO en exerciceDTO  pour la sérialisation
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        public static ExerciceDTO ToDTO(this Exercice poco)
            => new ExerciceDTO
            {
                Nom = poco.Nom,
                CheminImage = poco.CheminImage,
                ValeurDeb = poco.ValeurDeb.ToDTO(),
                ValeurInter = poco.ValeurInter.ToDTO(),
                ValeurExpert = poco.ValeurExpert.ToDTO()
            };

        /// <summary>
        /// transforme une collection d'exercicePOCO en collection d'exerciceDTO
        /// </summary>
        /// <param name="pocos"></param>
        /// <returns></returns>
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
