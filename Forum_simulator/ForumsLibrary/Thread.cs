using System.Collections.Generic;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace ForumsLibrary
{
    public class Thread
    {
        private const string _connectionString = "Data Source=.\\ForumDB.db";
        private int _id = -1;
        public int Id
        {
            get { return _id; }
            set { if (_id == -1) _id = value; }
        }
        public string Subject { get; set; }
        public string Creator { get; set; }
        public int PostCount { get; set; }

        public IList<Thread> GetThreads()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var threads = connection.Query<Thread>("SELECT t.*, u.UserName AS Creator, COUNT(p.Id) AS PostCount " +
                "FROM Thread AS t " +
                "LEFT JOIN Post AS p ON (p.ThreadId = t.Id) " +
                "LEFT JOIN User AS u ON (p.UserId = u.Id) " +
                "GROUP BY t.Subject " +
                "ORDER BY t.Id;");
                return threads.ToList();
            }
        }
        public Thread GetById(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "SELECT * FROM Thread WHERE Thread.Id = @Id";
                return connection.QuerySingle<Thread>(sql, new { Id = id });
            }
        }
        public void CreateThread(Thread thread)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "INSERT INTO Thread (Subject) VALUES (@Subject); " +
                "SELECT last_insert_rowid();";
                var id = connection.Query<int>(sql, thread);
                thread.Id = id.First();
            }
        }
    }
}
