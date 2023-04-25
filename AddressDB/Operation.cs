using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressDB
{
    public class Operation
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBook";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllRecords()
        {
            try
            {
                Address address = new Address();
                using (this.connection)
                {
                    string query = @"Select * from AddressBookData";

                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader read = command.ExecuteReader();
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            address.Id = read.GetInt32(0);
                            address.firstName = read.GetString(1);
                            address.firstName = read.GetString(1);
                            address.lastName = read.GetString(2);
                            address.address = read.GetString(3);
                            address.city = read.GetString(4);
                            address.state = read.GetString(5);
                            address.zip = read.GetString(6);
                            address.phone = read.GetString(7);
                            address.email = read.GetString(8);
                            Console.WriteLine(address.firstName + " " + address.lastName + " " + address.address + " " + address.city + " " + address.state + " " + address.zip + " " + address.phone + " " + address.email);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No records found");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                //Console.Write("Check code once");
            }
        }
    }
}
