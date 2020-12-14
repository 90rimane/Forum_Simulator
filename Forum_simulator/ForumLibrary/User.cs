using Microsoft.Data.Sqlite;
using System;

namespace ForumLibrary
{
    public class User
    {
        private const string _connectionString = "Data Source =.\\ConsoleApp\forumDB.db";
        public User()
        {
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string UserEmail { get; set; }
        public string UserDate { get; set; }
        public void PrintVersion()
        {
            Console.WriteLine("he hej hej");
            using (var connection = new SqliteConnection(_connectionString))
            {
                Console.WriteLine(connection.ServerVersion);
            }
        }
        private void AddUser()
        {

        }
        private void RemoveUser()
        {

        }
    }
}

