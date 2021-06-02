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

    public static class ProgrammeExtensions
    {
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

        public static ObservableCollection<Programme> ToPOCOs(this ObservableCollection<ProgrammeDTO> dtos)
        {
            ObservableCollection<Programme> pocos = new ObservableCollection<Programme>();
            foreach (var dto in dtos)
            {
                pocos.Add(dto.ToPOCO());
            }
            return pocos;
        }

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
