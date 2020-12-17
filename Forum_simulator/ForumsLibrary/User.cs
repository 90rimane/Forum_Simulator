using Dapper;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Linq;

namespace ForumsLibrary
{
    public class User
    {
        private const string _connectionString = "Data Source=.\\ForumDB.db";

        private int _id = -1;
        public int Id
        {
            get { return _id; }
            set { if (_id == -1) _id = value; }
        }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
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
