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
        public Category()
        {
        }
        public int CatId { get; }
        public string CatName { get; set; }

    }
}
