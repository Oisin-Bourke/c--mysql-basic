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

        //average contract duration:
        public int AverageContractDurarion(List<Client> clients)
        {
            int totalDays = 0;

            int totalContracts = 0;

            foreach (Client client in clients)
            {
                foreach(Contract contract in client.MyContracts)
                {
                    totalDays += contract.Date_Close.Subtract(contract.Date_Open).Days;

                    totalContracts++;
                }
            }

            int averageContractDurDays = totalDays / totalContracts;

            return averageContractDurDays;
        }

        //time remaining on a contract:
        public TimeSpan TimeRemainingOnContract(Contract contract)
        {
            DateTime now = DateTime.Now;

            TimeSpan timeRemaining =  contract.Date_Close.Subtract(now);

            return timeRemaining;
        }

        //the average contract value per client:
        public double AverageContractValuePerClient(Client client)
        {
            double total = 0;

            foreach(Contract contract in client.MyContracts)
            {
                total += contract.Total_Value;
            }

            return total / client.MyContracts.Count;
        }

        //total number of contracts currently open:
        public int TotalNumberContractsCurrentlyOpen()
        {

            return 0;
        }
    }
}
