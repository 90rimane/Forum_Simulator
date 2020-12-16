using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace ForumLibrary
{
    public class Thread
    {
        //private const string _connectionString = "Data Source =.\\forumDB.db";
        public Thread()
        {
        }
        public int ThreadId { get; }
        public string ThreadSubject { get; set; }
        public string ThreadDate { get; set; }
        public int CatId { get; set; }
        public int UserId { get; set; }
        public List<Category> Cats { get; set; }
        public List<User> Users { get; set; }
        //public IList<Thread> GetThread()
        //{
        //    using (var connection = new SqliteConnection(_connectionString))
        //    {
        //        var threads = connection.Query<Thread>("SELECT * FROM Thread");
        //        return threads.ToList();
        //    }
        //}
        private void CreateThread()
        {

        }
        private void ListThreadContent()      //name of thread,who created, how many post exist in threads
        {

        }
        // For a given thread it should be possible to view all posts that were created in it
    }
}

