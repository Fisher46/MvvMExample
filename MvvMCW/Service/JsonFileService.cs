using System.Collections.Generic;
using System.IO;
using MvvMCW.Model;
using System.Runtime.Serialization.Json;


namespace MvvMCW.Service
{
    public class JsonFileService : IFileService
    {
        public List<Movie> Open(string fileName)
        {
            var movies = new List<Movie>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Movie>));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                movies = jsonFormatter.ReadObject(fs) as List<Movie>;
            }

            return movies;
        }

        public void Save(string fileName, List<Movie> movies)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Movie>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, movies);
            }
        }
    }
}