using aura_web_blazor.Data.Models;
using System.Text.Json;

namespace aura_web_blazor.Data
{
    public class GetData
    {
        public Task<List<DetaletEFaturimit>> GetDetaletAsync()
        {
            
            return Task.FromResult(JsonSerializer.Deserialize<List<DetaletEFaturimit>>(ReadJsonFromFile()));
        }

        public string ReadJsonFromFile()
        {
            string json = string.Empty;
            try
            {
                using (StreamReader r = new StreamReader("Data/data.json"))
                {
                    json = r.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                //throw e;
            }
            json = json.Replace("0.0000", "0");

            return json.Replace("<EOF>", "");
        }
    }
}
