using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aura_web_api_client.Model
{
    public class Order
    {
        public string artikulli { get; set; }
        public int sasia { get; set; }
        public char nj2 { get; set; }
        public decimal qmimi { get; set; }
        public string kamarieri { get; set; }
        public DateTime ora { get; set; }
        public DateTime data { get; set; }
        public string tavolina { get; set; }
        public decimal vlera { get; set; }
        public string nrPorosise { get; set; }
        public string eshteMbyllur { get; set; }
    }

   
}

