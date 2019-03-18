using System;
using System.Collections.Generic;

namespace Assignment6
{
    public class SeedData
    {

        public static void SeedDB()
        {
            DBInterface db = new DBInterface();

            if (db.CheckIfDBEmpty())
            {
                List<Client> clientList = new List<Client>();

                List<Contract> contractList = new List<Contract>();

                //clients;
                clientList.Add(new Client("Jane Park", "1980-05-20", "Salthill, Galway"));
                clientList.Add(new Client("Sam Lake", "1995-02-10", "Tuam, Galway"));
                clientList.Add(new Client("Liam Burke", "2000-05-20", "Kinvarra, Galway"));
                clientList.Add(new Client("Linda Larkin", "2000-05-20", "Loughrea, Galway"));

                //add all clients to DB
                foreach (Client client in clientList)
                {
                    db.AddClientToDB(client);
                }

                //contracts:
                contractList.Add(new Contract("BT Sport", new DateTime(2018, 01, 01), new DateTime(2020, 01, 01), 200.50, 1));
                contractList.Add(new Contract("Eir Phone", new DateTime(2019, 04, 01), new DateTime(2020, 06, 01), 355.56, 1));
                contractList.Add(new Contract("Electricty", new DateTime(2017, 06, 01), new DateTime(2020, 07, 01), 400.90, 1));

                contractList.Add(new Contract("BT Sport", new DateTime(2019, 05, 01), new DateTime(2020, 01, 01), 200.50, 2));
                contractList.Add(new Contract("Eir Phone", new DateTime(2019, 06, 01), new DateTime(2020, 09, 01), 450.90, 2));
                contractList.Add(new Contract("Natural Gas", new DateTime(2019, 01, 01), new DateTime(2019, 01, 01), 355.56, 2));

                contractList.Add(new Contract("Eir Phone", new DateTime(2017, 05, 01), new DateTime(2019, 02, 01), 900.05, 3));
                contractList.Add(new Contract("Insurance", new DateTime(2019, 04, 01), new DateTime(2022, 05, 01), 250.50, 3));

                contractList.Add(new Contract("Greyhound", new DateTime(2018, 06, 01), new DateTime(2021, 03, 01), 100.00, 4));
                contractList.Add(new Contract("Insurance", new DateTime(2015, 06, 01), new DateTime(2025, 03, 01), 4500.00, 4));

                //add all contracts to DB
                foreach (Contract contract in contractList)
                {
                    db.AddContractToDB(contract);
                }

            }

        }

    }

}
