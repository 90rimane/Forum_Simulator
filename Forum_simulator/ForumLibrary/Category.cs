using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Data.Sqlite;

namespace ForumLibrary
{

    public class Category
    {
        private const string _connectionString = "Data Source =.\\forumDB.db";
        public Category()
        {
        }
        public int CatId { get; }
        public string CatName { get; set; }

    }
}
