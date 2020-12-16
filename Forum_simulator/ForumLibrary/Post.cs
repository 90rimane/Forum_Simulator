using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace ForumLibrary
{
    public class Post
    {
        private const string _connectionString = "Data Source =.\\forumDB.db";
        private int postId = -1;
        public Post()
        {
        }
        public int PostId
        {
            get { return postId; }
            set { if (postId == -1) postId = value; }
        }
        public string PostContent { get; set; }
        public string PostDate { get; set; }
        public int ThreadId { get; set; }
        public int UserId { get; set; }
        public Thread Threads { get; set; }
        public User Users { get; set; }

        public IList<Post> GetPosts()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var posts = connection.Query<Post>("SELECT * FROM Post");           
                return posts.ToList();
            }
        }
        public Post GetPostById(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            { 
                var sql = "SELECT * FROM Post WHERE PostId = @PostId";               //
                return connection.QuerySingle<Post>(sql, new { PostId = postId });
            }
        }
        public IList<Post> GetPostsByThread(Thread thread)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "SELECT p.*, u.* FROM Post AS p " +
                    "JOIN User AS u ON (p.UserId = u.UserIdId) " +
                    "JOIN Thread ON (p.ThreadId = ThreadId) " +
                    "WHERE ThreadId = @ThreadId; ";

                var posts = connection.Query<Post, User, Post>(sql, (post, user) =>
                {
                    post.User = user;
                    return post;
                }, thread);
                return posts.ToList();
            }
        }
        public void Create(Post post)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "INSERT INTO Post (ThreadId, Content, UserId) " +
                        "VALUES (@ThreadId, @Content, @UserId); " +
                       "SELECT last_insert_rowid();";
                var id = connection.Query<int>(sql, post);
                post.PostId = id.First();
            }
        }
        public void Update(Post post)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "UPDATE Post SET Content = @Content WHERE PostId = @PostId;";
                connection.Execute(sql, post);
            }
        }
        public void Delete(Post post)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "DELETE FROM Post WHERE PostId = @PostId;";
                connection.Execute(sql, post);
            }
        }
    }
}

