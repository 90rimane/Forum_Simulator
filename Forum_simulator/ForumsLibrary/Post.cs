using System.Collections.Generic;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace ForumsLibrary
{
    public class Post
    {
        private const string _connectionString = "Data Source=.\\ForumDB.db";
        private int _id = -1;
        public int Id
        {
            get { return _id; }
            set { if (_id == -1) _id = value; }
        }
        public int ThreadId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Thread Thread { get; set; }

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
                var sql = "SELECT * FROM Post WHERE Post.Id = @Id";
                return connection.QuerySingle<Post>(sql, new { Id = id });
            }
        }
        public IList<Post> GetPostsByThread(Thread thread)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "SELECT p.*, u.* FROM Post AS p " +
                "JOIN User AS u ON (p.UserId = u.Id) " +
                "JOIN Thread ON (p.ThreadId = Thread.Id) " +
                "WHERE ThreadId = @Id; ";
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
                post.Id = id.First();
            }
        }
        public void Update(Post post)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "UPDATE Post SET Content = @Content WHERE Id = @Id;";
                connection.Execute(sql, post);
            }
        }
        public void Delete(Post post)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "DELETE FROM Post WHERE Id = @Id;";
                connection.Execute(sql, post);
            }
        }
    }
}