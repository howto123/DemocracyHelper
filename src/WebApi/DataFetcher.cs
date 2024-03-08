using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApi.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi
{
    public class DataFetcher
    {
        private static readonly string BasePath = "C:/Users/Thinkpad53u/Files/Dev/99_ProjectIdeas/DemocracyHelper/DemocracyHelper/ExampleData/";

        public static List<Proposition> FetchPropositions()
        {
            return ListFromJson<Proposition>("propositionsSample.json");
        }

        public static List<Opinion> FetchOpinions()
        {
            return ListFromJson<Opinion>("opinionsSample.json");
        }

        private static List<TEntity> ListFromJson<TEntity>(string nameOfFileInBasePath)
        {
            var path = BasePath + nameOfFileInBasePath;
            var json = File.ReadAllText(path);
            List<TEntity> list = JsonSerializer.Deserialize<List<TEntity>>(json) ??
                throw new JsonException($"List of {typeof(TEntity)} could not be deserialized from path: {path}");
            return list;
        }
    }
}