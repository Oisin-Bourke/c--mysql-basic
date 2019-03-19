using System;
using System.Collections.Generic;

namespace Assignment6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //this populates the DB only if it is empty:
            SeedData.SeedDB();

            //am instance of db Interface to call DB methods:
            DBInterface db = new DBInterface();

            //read all clients:
            db.ReadClientsFromDB();

            //read all contracts:
            db.ReadContractsFromDB();

            Console.WriteLine("\nDeserialized Clients with Contracts List:");

            //deserialize the database:
            List <Client> clientsList = db.DeserializeDB();

            foreach (Client client in clientsList)
            {
                Console.WriteLine(client);
            }

            //an instance of Calculate to call the various calculation methods:
            Calculate calc = new Calculate();

            double result = calc.OverallAverageNumberOfContractsPerCleint(clientsList);

            Console.WriteLine("The result is: "+result);


        }
    }
}
