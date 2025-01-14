﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Application;

namespace PersistanceData
{
    [DataContract]

    // Classe sérialisable et miroir de la classe Valeur
    public class ValeurDTO
    {
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public int NbSeries { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public int NbReps { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public int TpsRepos { get; set; }
    }

    /// <summary>
    /// Classe d'extension contenant les méthodes permettant de passer un objet DTO en POCO et inversement
    /// </summary>
    public static class ValeurExtensions
        {
            public static Valeur ToPOCO(this ValeurDTO dto)
            {
                return new Valeur
                (
                  dto.NbSeries,
                  dto.NbReps,
                  dto.TpsRepos
                );
            }

            public static ValeurDTO ToDTO(this Valeur poco)
            {
                 return new ValeurDTO
                 {
                    NbReps = poco.NbReps,
                    NbSeries = poco.NbSeries,
                    TpsRepos = poco.TpsRepos
                 };
            }
        }  
}
