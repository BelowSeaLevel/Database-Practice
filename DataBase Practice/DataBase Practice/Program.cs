using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DataBase_Practice
{
    class Program
    {
        static void Main()
        {
            // Connection String. Contains the information it needs to know,
            // about which database to conect to, the location of the database, and how to authenticate against the database.
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Roy\Desktop\TrowAway\TrowAway\Database\PracticeDataBase.mdf;Integrated Security=True;Connect Timeout=30";


            try
            {
                // A SqlConnection with a using statement to automatically close it.
                // SqlConnection inherits from the DbConnection base class.
                // SqlConnection is used to connect to a Microsoft SQL Server.
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // This is the Query we want to execute, in a string.
                    string query = @"SELECT Naam FROM Auto";

                    // Is used to execute some code or Query against a SQL Server database.
                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Opens the connections to the database.
                    connection.Open();


                    // Retrieving your query's results.
                    SqlDataReader dr = cmd.ExecuteReader();

                    // "HasRows" Gets a value that indicates whether the SqlDataReader contains one or more rows.
                    if (dr.HasRows)
                    {
                        // (Read) Advances the SqlDataReader to the next record.
                        while (dr.Read())
                        {
                            Console.WriteLine(dr.GetString(0));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                    // Closes the SqlDataReader object.
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }



            Console.ReadKey();



        }







    }

}
