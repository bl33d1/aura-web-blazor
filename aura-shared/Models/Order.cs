using System;
using System.Collections.Generic;
using System.Text;

namespace aura_shared.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Artikulli { get; set; }
        public int Sasia { get; set; }
        public char Nj2 { get; set; }
        public decimal Qmimi { get; set; }
        public string Kamarieri { get; set; }
        public string Ora { get; set; }
        public string Data { get; set; }
        public string Tavolina { get; set; }
        public decimal Vlera { get; set; }
        public string NrPorosise { get; set; }
        public string EshteMbyllur { get; set; }
    }
}
