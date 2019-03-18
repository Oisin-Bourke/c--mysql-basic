using System.Collections.Generic;
using System.Text;

namespace Assignment6
{
    public class Client
    {
        //each client has a list of contracts:
        List <Contract> contractList;

        //default constructor:
        public Client()
        {

        }

        //constructor to add client to DB (without PK)
        public Client(string client_name,string dob,string address)
        {
            Client_Name = client_name;
            Dob = dob;
            Address = address;
        }

        //using the auto-implement read/write properties:
        public int Client_Id { get; set; }

        public string Client_Name { get; set; }

        public string Dob { get; set; }

        public string Address { get; set; }

        public List<Contract> MyContracts
        {
            get { return contractList; }

            set { contractList = value; }
        }

        //complex to string using string builder:
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("#"+Client_Id+")");
            sb.Append(" ~ Name: "+Client_Name);
            sb.Append(" ~ DOB: "+Dob);
            sb.Append(" ~ Address: "+Address+".\n");
            foreach(Contract contract in MyContracts)
            {
                sb.AppendLine("\t#" + contract.Contract_Id + ")" 
                            + " Company: " + contract.Contract_Name 
                            + " | Open Date: " + contract.Date_Open
                            + " | Close Date: " + contract.Date_Close 
                            + " | Total Value :€" + contract.Total_Value);
            }

            return sb.ToString();
        }

    }
}
