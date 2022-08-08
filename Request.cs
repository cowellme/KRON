using System;
using System.Data.SqlClient;

namespace KRON
{
    public class Request
    {
        public static async void NewUser(string numberTg, string userName, double balance, SqlConnection connection)
        {
            string date = DateTime.Now.ToString("MMMd");

            await connection.OpenAsync();

            SqlCommand command = new SqlCommand();                  

            command.CommandText = $"INSERT INTO USERS(NumberTg, Name, Balance, Registr) VALUES('{numberTg}', '{userName}', {balance}, '{date}')";

            command.Connection = connection;                        

            await command.ExecuteNonQueryAsync();
        }

        public static async void DeleteUser(string numberTg,SqlConnection connection)
        {
            await connection.OpenAsync();

            SqlCommand command = new SqlCommand();

            command.CommandText = $"DELETE FROM USERS WHERE NumberTg = {numberTg}";

            command.Connection = connection;

            await command.ExecuteNonQueryAsync();
        }

        public static async void AddBalance()
        {

        }

        public static async void CutBalance()
        {

        }

        private static async void Checking()
        {

        }
    }
}
