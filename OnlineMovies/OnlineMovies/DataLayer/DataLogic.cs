using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using OnlineMovies.Models;
using System.Data;
using System.Linq.Expressions;
using System.Configuration;

namespace OnlineMovies.DataLayer
{
    public class UserDataAccess
    {
        private readonly string connectionString;

        public UserDataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

       
        public User GetUserByUsernameAndPassword(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetUserByUsernameAndPassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@PasswordHash", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Username = reader["Username"].ToString(),
                                IsAdmin = Convert.ToBoolean(reader["IsAdmin"]),
                                PasswordHash = reader["PasswordHash"].ToString(),
                                Email = reader["Email"].ToString()
                            };
                        }
                        else
                        {
                            return null; 
                        }
                    }
                }
            }
        }
    }
    //public class DataLogic
    //{
    //    //    SqlConnection con = new SqlConnection(
    //    //WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
    //    static void Main(string[] args)
    //    {
    //        try
    //        {

    //            SqlConnection conn = new SqlConnection(
    //        WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);


    //            //string dl = "data source=CMDLHRLTX523;database=Movies;Integrated security=SSPI";
    //            //using (SqlConnection conn = new SqlConnection(dl))
    //            {
    //                SqlCommand cmd = new SqlCommand();
    //                cmd.CommandText = "AddUser";
    //                cmd.Connection = conn;
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                conn.Open();
    //                SqlDataReader rd = cmd.ExecuteReader();
    //                Console.WriteLine("Student Data");
    //                while (rd.Read())
    //                {
    //                    Console.WriteLine(rd[0] + "," + rd[1] + "," + rd[2]);

    //                }
    //            }

    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);

    //        }

    //        Console.ReadLine();





    //    }
    //}
}