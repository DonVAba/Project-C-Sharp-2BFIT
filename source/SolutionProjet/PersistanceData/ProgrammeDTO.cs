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

    /// Classe sérialisable et miroir de la classe programme
    public class ProgrammeDTO
    {
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string Nom { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Description { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string CheminImage { get; set; }


        [DataMember(EmitDefaultValue = false, Order = 3)]
        public ObservableCollection<ExerciceDTO> LesExercices { get; set; }


    }

    /// <summary>
    /// Classe d'extension contenant les méthodes permettant de passer un objet DTO en POCO et inversement
    /// </summary>
    public static class ProgrammeExtensions
    {

        /// <summary>
        /// Transforme un ProgrammeDTO en ProgrammePOCO  pour la désérialisation
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Programme ToPOCO(this ProgrammeDTO dto)
        {
            if(dto != null)
            {
                var p = new Programme(dto.Nom, dto.Description, dto.CheminImage);
                var listExo = dto.LesExercices.ToPOCOs();
                foreach (var ex in listExo)
                {
                    p.LesExercices.Add(ex);
                }
                return p;
            }
            return null;
        }

        /// <summary>
        /// Transforme une collection de ProgrammeDTO en collection de ProgrammePOCO  pour la désérialisation
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ObservableCollection<Programme> ToPOCOs(this ObservableCollection<ProgrammeDTO> dtos)
        {
            ObservableCollection<Programme> pocos = new ObservableCollection<Programme>();
            foreach (var dto in dtos)
            {
                pocos.Add(dto.ToPOCO());
            }
            return pocos;
        }


        /// <summary>
        /// Transforme un ProgrammePOCO en ProgrammeDTO pour la sérialisation
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ProgrammeDTO ToDTO(this Programme poco)
        {
            if(poco != null)
            {
                return new ProgrammeDTO
                {
                    Nom = poco.Nom,
                    Description = poco.Description,
                    CheminImage = poco.CheminImage,
                    LesExercices = poco.LesExercices.ToDTOs()
                };
            }
            return null;
           
        }

        /// <summary>
        /// Transforme une collection de ProgrammePOCO en collection de ProgrammeDTO pour la désérialisation
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ObservableCollection<ProgrammeDTO> ToDTOs(this ObservableCollection<Programme> pocos)
        {
            ObservableCollection<ProgrammeDTO> dtos = new ObservableCollection<ProgrammeDTO>();
            foreach(var poco in pocos)
            {
                dtos.Add(poco.ToDTO());
            }
            return dtos;
        }


    }
}
