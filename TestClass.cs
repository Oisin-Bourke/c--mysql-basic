using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Assignment6
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void OverallAverageNumberOfContractsPerCleintTest()
        {
            List<Contract> contracts = new List<Contract>();
            contracts.Add(new Contract());
            contracts.Add(new Contract());
            contracts.Add(new Contract());

            Client client = new Client();
            client.MyContracts = contracts;
            List<Client> clients = new List<Client>();
            clients.Add(client);
            clients.Add(client);

            Console.WriteLine("TESTING - 2 clients each with 3 contracts");
            Calculate calculate = new Calculate();
            double result = calculate.OverallAverageNumberOfContractsPerCleint(clients);
            Assert.AreEqual(3.0,result);
            Assert.AreNotEqual(2.5, result);
            Assert.NotNull(clients);
        }

        [Test]
        public void AverageContractDurarionDaysTest()
        {
            List<Contract> contracts = new List<Contract>();

            Contract contract1 = new Contract();
            contract1.Date_Open = new DateTime(2000, 01, 01);
            contract1.Date_Close = new DateTime(2000, 01, 04);

            Contract contract2 = new Contract();
            contract2.Date_Open = new DateTime(2000, 01, 01);
            contract2.Date_Close = new DateTime(2000, 01, 04);

            contracts.Add(contract1);
            contracts.Add(contract2);

            Client client = new Client();
            client.MyContracts = contracts;
            List<Client> clients = new List<Client>();
            clients.Add(client);
            clients.Add(client);

            Console.WriteLine("TESTING - 4 contracts all duration 3 days");
            Calculate calculate = new Calculate();
            int result = calculate.AverageContractDurarion(clients);
            Assert.AreEqual(3, result);
            Assert.AreNotEqual(20, result);
            Assert.NotNull(clients);
        }
    }
}
