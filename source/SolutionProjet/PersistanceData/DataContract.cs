using System;
using System.Collections.Generic;
using System.Text;
using Application;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Collections.ObjectModel;
using System.Linq;

namespace PersistanceData
{
    public class DataContract : IDataManager
    {
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "../../../../2bfit_bin//XML");

        public string FileName { get; set; } = "2bfitData.xml";

        private string PersFile => Path.Combine(FilePath,FileName);

        internal List<Utilisateur> LUser { get; set; } = new List<Utilisateur>();
        internal List<Programme> LProg { get; set; } = new List<Programme>();

        /// <summary>
        /// Propriété qui va serialiser et deserialiser les données dans le fichier voulu, on lui demande de garder les references (ListeFavoris d'un utilisateur)
        /// </summary>
        private DataContractSerializer Serializer { get; set; } = new DataContractSerializer(typeof(ListesDTO),
                                                 new DataContractSerializerSettings()
                                                 {
                                                     PreserveObjectReferences = true
                                                 });
        public Listes ChargeDonnees()
        {
            if (!File.Exists(PersFile))
            {
                throw new FileNotFoundException("Error : fichier de persistance inexistant");
            }
            
            using(Stream stream = File.OpenRead(PersFile))
            {
                var data = Serializer.ReadObject(stream) as ListesDTO;
                return data.ToPOCO();
            }
            
        }

        public void SauvegardeDonnees(Listes list)
        {
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            var data = list.ToDTO();
            
            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(PersFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    Serializer.WriteObject(writer, data);
                }
            }
        }
    }
}
