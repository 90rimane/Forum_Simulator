using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace ForumLibrary
{
    public class Thread
    {
        private const string _connectionString = "Data Source =.\\forumDB.db";
        public Thread()
        {
        }
        public int ThreadId { get; }
        public string ThreadSubject { get; set; }
        public DateTimeOffset ThreadDate { get; }
        public int CatId { get; set; }
        public int UserId { get; set; }
        public Category Cats { get; set; }
        public User Users { get; set; }

        public void CreateThread(Thread thread)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "INSERT INTO Thread (ThreadSubject, ThreadDate, CatId, UserId) VALUES (@ThreadSubject, @ThreadDate, @CatId, @UserId); " +
                    "SELECT last_insert_rowid();";
                var userId = connection.Query<int>(sql, thread);
                thread.UserId = userId.First();
            }
        }
        public IList<Thread> GetThread()
        {
            using (var connection = new SqliteConnection(_connectionString))    //
            {
                var threads = connection.Query<Thread>("SELECT t.*, u.UserName AS Creator, COUNT(p.Id) AS PostCount " +
                "FROM Thread AS t " +
                "LEFT JOIN Post AS p ON (p.ThreadId = t.ThreadId) " +
                "LEFT JOIN User AS u ON (p.UserId = u.UserId) " +
                "GROUP BY t.ThreadSubject " +
                "ORDER BY t.Id;");
                return threads.ToList();
            }
        }
        public Thread GetById(int userId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "SELECT * FROM Thread WHERE ThreadId = @UserId";         //
                return connection.QuerySingle<Thread>(sql, new { UserId = userId });
            }
        }

    }
}

