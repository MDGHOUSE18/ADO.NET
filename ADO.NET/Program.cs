using System;
using System.Data.SqlClient;

namespace ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Connection();
        }

        static void Connection()
        {
            SqlConnection connection = null;
            String connString = @"Data Source=GHOUSE\SQLEXPRESS;Initial Catalog=payroll_service;Integrated Security=True;";


            try
            {
                connection = new SqlConnection(connString);
                connection.Open();
                Console.WriteLine("Connection established Sucessfully ");

                string query = "SELECT * FROM employee_payroll";

                //string insertQuery = "INSERT INTO employee_payroll(Name, Salary, start_date, gender) VALUES ('Chetna', 29500, '2024-05-03', 'F')";

                //SqlCommand cmd = new SqlCommand(insertQuery,connection);


                //int rowsAffected = cmd.ExecuteNonQuery();
                //Console.WriteLine($"{rowsAffected} row(s) inserted successfully.");

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader[0]}, Name: {reader[1]}, Salary : {reader[2]}, DateOfJoining : {reader[3]}, Gender : {reader[4]}");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Connection closed.");
                }
            }
            //using (SqlConnection connection = new SqlConnection(connString))
            //{
            //    try
            //    {
            //        connection.Open();
            //        Console.WriteLine("Connection established Sucessfully ");

            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
        }
    }
}
