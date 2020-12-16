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

        private int userId = -1;
        private int userPass;

        public User(string userName, string userEmail)
        {
            UserId = userId;
            UserName = userName;
            UserEmail = userEmail;
            UserDate = DateTimeOffset.Now;
        }
        public int UserId
        {
            get { return userId; }
            set { if (userId == -1) userId = value; }
        }
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
        public DateTimeOffset UserDate { get; }

        public IList<User> GetUsers()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var users = connection.Query<User>("SELECT * FROM User");
                return users.ToList();
            }
        }
    }
}