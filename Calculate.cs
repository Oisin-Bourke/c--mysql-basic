using System;
using System.Collections.Generic;

namespace Assignment6
{

    public class Calculate
    {
        //a method that returns average number of clients:
        public double OverallAverageNumberOfContractsPerCleint(List <Client> clients)
        {
            double total = 0;

            foreach (Client client in clients)
            {
                total += client.MyContracts.Count;
            }

            double average = total / clients.Count;

            return average;
        }

    }
}
