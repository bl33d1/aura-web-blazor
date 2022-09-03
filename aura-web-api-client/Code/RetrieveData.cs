using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace aura_web_api_client.Code
{
    public class RetrieveData
    {

        private static readonly HttpClient client = new HttpClient();

        public List<Model.Order> detaletFaturimit;
        string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\bledi\\Desktop\\kohaa\\b1.mdb;User Id=;Password=;";
        string query4444a = @"SELECT DISTINCTROW tblprodukti.strartikulli, [tbldetalet e faturimit].sasia, [tbldetalet e faturimit].qmimishites, [qmimishites]*[sasia] AS Expr1, tblprodukti.nj2, tblUser.UserPassword, [tbldetalet e faturimit].ora, [tbldetalet e faturimit].Data, [tbldetalet e faturimit].Adresa, [tbldetalet e faturimit].marzha, [tbldetalet e faturimit].Blersi, [tbldetalet e faturimit].isTransfered
FROM tblprodukti INNER JOIN (tblUser INNER JOIN [tbldetalet e faturimit] ON tblUser.UserName = [tbldetalet e faturimit].kam) ON tblprodukti.pkeyProductID = [tbldetalet e faturimit].fkeyProductID
WHERE ((([tbldetalet e faturimit].isTransfered)=No));";

        string queryUpdateTransfered = @"UPDATE 44a SET [44a].isTransfered = Yes;";
        
        public void GetOrdersFromDB()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connString))
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand(query4444a, connection);
                    OleDbDataReader reader = command.ExecuteReader();
                    if (!reader.HasRows) return;
                    detaletFaturimit = new List<Model.Order>();
                     while (reader.Read())
                    {
                        //getting all the lines from db and adding to list for easier access
                        detaletFaturimit.Add(new Model.Order()
                        {
                            artikulli = reader.GetValue(0).ToString(),
                            sasia = int.Parse(reader.GetValue(1).ToString()),
                            qmimi = decimal.Parse(reader.GetValue(2).ToString()),
                            vlera = decimal.Parse(reader.GetValue(3).ToString()),
                            nj2 = char.Parse(reader.GetValue(4).ToString()),
                            kamarieri = reader.GetValue(5).ToString(),
                            ora = DateTime.Parse(reader.GetValue(6).ToString()),
                            data = DateTime.Parse(reader.GetValue(7).ToString()),
                            tavolina = reader.GetValue(8).ToString(),
                            nrPorosise = reader.GetValue(9).ToString(),
                            eshteMbyllur = reader.GetValue(10).ToString()
                        });

                    }
                     //mark as trasfrerred
                    new OleDbCommand(queryUpdateTransfered, connection).ExecuteNonQuery();
                }
                if (detaletFaturimit.Count == 0) return;
                
            }
            catch (Exception e)
            {
                //TO
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return;
            }



            SendPost(detaletFaturimit);
            //foreach (var x in detaletFaturimit)
            //{
            //    Console.WriteLine(x.Artikulli + ": " + x.Nj2);
            //}
            Console.ReadLine();
        }

        public async void SendPost(List<Model.Order> orders)
        {
            var content = JsonConvert.SerializeObject(orders, Formatting.Indented);

            var response = await client.PostAsync("https://localhost:7174/api/Order", new StringContent(content, Encoding.UTF8, "application/json"));

            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseString.Length);
        }
            
    }
}


