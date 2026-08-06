using System;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

public class Program
{
    static void Main()
    {
        // using statement for database
        string ConnectionString = "Server=your_server;Database=your_database;" +
        "User Id=your_username;Password=your_password;";

        try
        {
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                string Query = @"select * from Employees";

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.HasRows)
                        {
                            while (Reader.Read())
                            {
                                string FirstName = Reader["FirstName"].ToString();
                                string Title = Reader["Title"].ToString();

                            }
                        }else
                        {
                            Console.WriteLine("No Rows Found!");
                        }
                    }
                }
            }

        }catch(SqlException Error)
        {
            Console.WriteLine($"Error: {Error.Message}");
        }
        // using statement with files
        string FilePath = "File.txt";
        try
        {
            using (StreamReader Reader = new StreamReader(FilePath))
            {
                string Line;
                while ((Line = Reader.ReadLine()) != null)
                {
                    Console.WriteLine(Line);
                }
            }
        }
        catch (FileNotFoundException) 
        {
            Console.WriteLine($"File Not Found: {FilePath}");
        }catch(IOException)
        {
            Console.WriteLine($"Error while Reading The File {FilePath}");
        }
    }
}

