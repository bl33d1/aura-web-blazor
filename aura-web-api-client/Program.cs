using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aura_web_api_client.Code;

namespace aura_web_api_client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                new RetrieveData().GetOrdersFromDB();
                System.Threading.Thread.Sleep(4000);
            }

        }
    }
}
