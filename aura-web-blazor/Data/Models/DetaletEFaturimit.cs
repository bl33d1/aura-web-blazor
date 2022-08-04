namespace aura_web_blazor.Data.Models
{
    public class DetaletEFaturimit
    {
        public string artikulli { get; set; }
        public string sasia { get; set; }
        public string nj2 { get; set; }
        public string qmimi { get; set; }
        public string password { get; set; }
        public string kam { get; set; }
        public string ora { get; set; }
        public string data { get; set; }
        public string tav { get; set; }
        public string vlera { get; set; }
        public string nrPorosise { get; set; }
        public string eshteMbyllur { get; set; }


        override public string ToString()
        {
            return $"\n \"artikulli\": \"{artikulli}\",\n  \"sasia\": \"{sasia}\",\n \"qmimi\": \"{qmimi}\",\n \"vlera\": \"{vlera}\",\n \"nj2\": \"{nj2}\",\n  \"password\": \"{password}\",\n  \"kam\": \"{kam}\",\n  \"ora\": \"{ora}\",\n  \"data\": \"{data}\",\n  \"tav\": \"{tav}\",\n  \"nrPorosise\": \"{nrPorosise}\",\n  \"eshteMbyllur\": \"{eshteMbyllur}\",\n";
        }
    }
}
