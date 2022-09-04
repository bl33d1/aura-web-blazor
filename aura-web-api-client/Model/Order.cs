using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aura_web_api_client.Model
{
    public class Order
    {
        public string Artikulli { get; set; }
        public int Sasia { get; set; }
        public char Nj2 { get; set; }
        public decimal Qmimi { get; set; }
        public string Kamarieri { get; set; }
        public DateTime Ora { get; set; }
        public DateTime Data { get; set; }
        public string Tavolina { get; set; }
        public decimal Vlera { get; set; }
        public string NrPorosise { get; set; }
        public string EshteMbyllur { get; set; }
    }

   
}

