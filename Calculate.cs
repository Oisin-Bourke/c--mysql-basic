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

        public TimeSpan TimeRemainingOnContract(Contract contract)
        {
            DateTime now = DateTime.Now;

            TimeSpan timeRemaining =  contract.Date_Close.Subtract(now);

            return timeRemaining;
        }
    }
}
