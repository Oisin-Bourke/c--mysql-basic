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
            contracts.Add((new Contract()));
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
    }
}
