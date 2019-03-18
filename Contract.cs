using System;
using System.Text;

namespace Assignment6
{
    public class Contract
    {
        //default constructor:
        public Contract()
        { 
        
        }

        //constructor to add contract to DB (without PK):
        public Contract(String contract_name,DateTime date_open, DateTime date_close,double total_value, int client_id)
        {
            Contract_Name = contract_name;
            Date_Open = date_open;
            Date_Close = date_close;
            Total_Value = total_value;
            Client_Id = client_id;
        }

        //using the auto-implement read/write properties:
        public int Contract_Id { get; set; }

        public String Contract_Name { get; set; }

        public DateTime Date_Open { get; set; }

        public DateTime Date_Close { get; set; }

        public Double Total_Value { get; set; }

        public int Client_Id { get; set; }

        //tostring:
        public override string ToString()
        {
            return string.Format("[Contract: " +
            	"Contract_Id={0}, Contract_Name={1}, Date_Open={2}, Date_Close={3}, Total_Value={4}, Client_Id={5}]", 
                Contract_Id, Contract_Name, Date_Open, Date_Close, Total_Value, Client_Id);
        }

    }
}
