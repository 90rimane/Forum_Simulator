using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForumLibrary
{
    public class User
    {
        private const string _connectionString = "Data Source =.\\forumDB.db";

        private int userId = 4;
        private int userPass;

        public User(string userName, string userEmail)
        {
            UserId = userId;
            UserName = userName;
            UserEmail = userEmail;
            UserDate = DateTimeOffset.Now;
        }
        public int UserId { get; }
        //{
        //    get { return userId; }
        //    set
        //    {
        //        for (int i = 3; i < 999; i++)         ///i = 0
        //        {
        //            userId = i;
        //        }
        //    ;}
        //}
        public string UserName { get; set; }
        public int UserPass
        {
            get { return userPass; }
            set
            {
                Random random = new Random();
                int slumpTal = random.Next(1, 9999);
                userPass = slumpTal
                    ;
            }
        }
        public string UserEmail { get; set; }
        public DateTimeOffset UserDate { get;}

        public void PrintVersion()
        {
            Console.WriteLine("he hej hej");
            using (var connection = new SqliteConnection(_connectionString))
            {
                Console.WriteLine(connection.ServerVersion);
            }
        }

        public void AddUser()
        {
            Console.WriteLine("-----Add User-----\n");

            Console.WriteLine("Enter your name:");
            string newName = Console.ReadLine();

            Console.WriteLine("Enter your Email:");
            string newEmail = Console.ReadLine();

            List<User> users = new List<User>();
            users.Add(new User(newName, newEmail));

            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = $"INSERT INTO User (UserId,UserName,UserPass,UserEmail,UserDate) VALUES " +
                                           $"(@UserId,@UserName,@UserPass,@UserEmail,@UserDate)";
                var result = connection.Execute(sql, users);
            }

        }
        private void RemoveUser()
        {

        }
    }
}

