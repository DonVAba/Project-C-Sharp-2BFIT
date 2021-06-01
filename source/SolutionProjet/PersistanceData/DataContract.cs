using System;
using System.Collections.Generic;
using System.Text;
using Application;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace PersistanceData
{
    public class DataContract : IDataManager
    {
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//XML");

        public string FileName { get; set; } = "2bfitData.xml";

        string PersFile => Path.Combine(FilePath,FileName);
        public DataToPersist ChargeDonnees()
        {
            if (!File.Exists(PersFile))
            {
                throw new FileNotFoundException("Error : fichier de persistance inexistant");
            }
            var serializer = new DataContractSerializer(typeof(DataToPersist));
            using(Stream stream = File.OpenRead(PersFile))
            {
                var data = serializer.ReadObject(stream) as DataToPersist;
                return data;
            }
            
        }

        public void SauvegardeDonnees(Listes list)
        {

            var data = new DataToPersist
            {
                ListeProgramme = list.ListProgrammes
            };
            foreach (var kvp in list.listComptes)
            {
                data.ListeUtilisateurs.Add(kvp.Value);
            }

            var serializer = new DataContractSerializer(typeof(DataToPersist));

            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(PersFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(writer, data);
                }
            }
        }
    }
}
