using System;
using System.Collections.Generic;

namespace Assignment6
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            SeedData.SeedDB();

            DBInterface db = new DBInterface();

            db.ReadClientsFromDB();

            db.ReadContractsFromDB();

            List <Client> clients = db.DeserializeDB();

            foreach (Client client in clients)
            {
                Console.WriteLine(client);
            }

        }
    }
}
