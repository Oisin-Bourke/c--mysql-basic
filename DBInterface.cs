using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Assignment6
{
    public class DBInterface
    {
        readonly string connectionString = "server=localhost;port=3306;database=NET;uid=root;password=Born1980$";

        //check if DB is empty for seed:
        public Boolean CheckIfDBEmpty()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            MySqlDataReader reader = null;

            try
            {
                mySqlConnection.Open();

                string queryString = "select count(*) from client";

                MySqlCommand command = new MySqlCommand(queryString, mySqlConnection);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int result = int.Parse(reader[0].ToString());

                    if (result == 0) return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (reader != null) reader.Close();

                if (mySqlConnection != null) mySqlConnection.Close();

            }

            return false;
        }

        //read clients from DB:
        public void ReadClientsFromDB()
        {
            Console.WriteLine("Client List:");

            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            MySqlDataReader reader = null;

            try
            {
                mySqlConnection.Open();

                string queryString = "select * from client";

                MySqlCommand command = new MySqlCommand(queryString, mySqlConnection);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}", reader[0], reader[1], reader[2], reader[3]);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (reader != null) reader.Close();

                if (mySqlConnection != null) mySqlConnection.Close();
            }

        }

        //read contracts from DB:
        public void ReadContractsFromDB()
        {
            Console.WriteLine("Contract List:");

            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            MySqlDataReader reader = null;

            try
            {
                mySqlConnection.Open();

                string queryString = "select * from contract";

                MySqlCommand command = new MySqlCommand(queryString, mySqlConnection);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (reader != null) reader.Close();

                if (mySqlConnection != null) mySqlConnection.Close();

            }

        }//end ReadMySQL

        //deseialize the DB:
        public List <Client> DeserializeDB()
        {
            List <Client> clients = new List<Client>();

            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            MySqlDataReader reader = null;

            try
            {
                mySqlConnection.Open();

                string queryString = "select * from client";

                MySqlCommand command = new MySqlCommand(queryString, mySqlConnection);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Client temp = new Client();

                    temp.Client_Id = (int)reader[0];
                    temp.Client_Name = (string)reader[1];
                    temp.Dob = (string)reader[2];
                    temp.Address = (string)reader[3];

                    //deserialise the contracts for each client:
                    List<Contract> contracts = new List<Contract>();

                    contracts = DeserializeContractsForOneClient(temp);

                    temp.MyContracts = contracts;

                    clients.Add(temp);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (reader != null) reader.Close();

                if (mySqlConnection != null) mySqlConnection.Close();

            }

            return clients;
        }

        //deserialise contracts for one client:
        public List<Contract> DeserializeContractsForOneClient(Client client)
        {
            List<Contract> contracts = new List<Contract>();

            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            MySqlDataReader reader = null;

            try
            {
                mySqlConnection.Open();

                string queryString = "select * from contract where client_id ="+client.Client_Id;

                MySqlCommand command = new MySqlCommand(queryString, mySqlConnection);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contract temp = new Contract();

                    temp.Contract_Id = (int)reader[0];
                    temp.Contract_Name = (string)reader[1];
                    temp.Date_Open = (DateTime)reader[2];
                    temp.Date_Close = (DateTime)reader[3];
                    temp.Total_Value = (Double)reader[4];
                    temp.Client_Id = (int)reader[5];

                    contracts.Add(temp);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (reader != null) reader.Close();

                if (mySqlConnection != null) mySqlConnection.Close();

            }

            return contracts;
        }



        //adding a new client to the database:
        public void AddClientToDB(Client client)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            try
            {
                mySqlConnection.Open();

                string insertString = "insert into client (client_name,dob,address) " 
                                + "values('" 
                                + client.Client_Name + "','" 
                                + client.Dob + "','" 
                                + client.Address + "')";

                MySqlCommand command = new MySqlCommand(insertString, mySqlConnection);

                command.ExecuteNonQuery();

                //Console.WriteLine("New client added");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (mySqlConnection != null) mySqlConnection.Close();
            }

        }//end InsertMySQL

        public void AddContractToDB(Contract contract)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            try
            {
                mySqlConnection.Open();

                String insertString = "insert into contract(contract_name, date_open, date_close, total_value, client_id)values(@contract_name,@date_open,@date_close ,@total_value, @client_id)";

                MySqlCommand command = new MySqlCommand(insertString, mySqlConnection);
                command.Parameters.AddWithValue("@contract_name",contract.Contract_Name);
                command.Parameters.AddWithValue("@date_open", contract.Date_Open.Date);
                command.Parameters.AddWithValue("@date_close", contract.Date_Close.Date);
                command.Parameters.AddWithValue("@total_value", contract.Total_Value);
                command.Parameters.AddWithValue("@client_id", contract.Client_Id);

                command.ExecuteNonQuery();

                //Console.WriteLine("New contract added");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (mySqlConnection != null) mySqlConnection.Close();
            }

        }


        //updating the name of a client by primary key client id:
        public void UpdateMySQL(string newName,int client_id)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            try
            {
                mySqlConnection.Open();

                string updateString = "update client set client_name = '" + newName 
                                       + "' where client_id =" + client_id;

                MySqlCommand command = new MySqlCommand(updateString, mySqlConnection);

                command.ExecuteNonQuery();

                Console.WriteLine("Update recorded");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (mySqlConnection != null) mySqlConnection.Close();
            }

        }//end UpdateMySQL

        //delete entry by primary key client id:
        public void DeleteMySQL(int client_id)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            try
            {
                mySqlConnection.Open();

                string deleteString = "delete from client where client_id =" + client_id;

                MySqlCommand command = new MySqlCommand(deleteString, mySqlConnection);

                command.ExecuteNonQuery();

                Console.WriteLine("Record deleted");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (mySqlConnection != null) mySqlConnection.Close();
            }

        }//EndDeleteMySQL


    }
}