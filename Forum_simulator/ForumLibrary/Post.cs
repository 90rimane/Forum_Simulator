using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace ForumLibrary
{
    class Post
    {
        public Post()
        {
        }
        public int PostId { get; }
        public string PostContent { get; set; }
        public string PostDate { get; set; }
        public int ThreadId { get; set; }
        public int UserId { get; set; }
        public List<Thread> Threads { get; set; }
        public List<User> Users { get; set; }

        private void CreatePost() //A post contains text and who created the post
        {

        }
        private void DeletePost()
        {

        }
        private void UpdatePost()
        {

        }

    }
}

