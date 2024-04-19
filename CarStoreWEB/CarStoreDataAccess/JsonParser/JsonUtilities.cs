using Newtonsoft.Json;

namespace CarStoreDataAccess.JsonUtilities
{
    public class JsonUtilities
    {
        [JsonProperty("DbConnectionString")]
        public string? ConnectionStrValue { get; set; }

        /// <summary>
        /// Method for geting connection string from ".json" file
        /// </summary>
        /// <param name="path">Is path to JSON file</param>
        /// <returns></returns>
        public string GetConnectionStr(string path)
        {
            /* 
             Use .json format like this ->
             {
                "DbConnectionString": "*your connection string*"
             }
            */

            var json = File.ReadAllText(path);
            var data = JsonConvert.DeserializeObject<JsonUtilities>(json);

            if (string.IsNullOrEmpty(data?.ConnectionStrValue))
            {
                return "Connection string is not found of empty.";
            }
            return data.ConnectionStrValue;
        }
    }
}
