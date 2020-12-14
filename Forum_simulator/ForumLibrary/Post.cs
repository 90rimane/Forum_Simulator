using System;
using System.Collections.Generic;
using System.Text;

namespace ForumLibrary
{
    class Post
    {
        public Post()
        {
        }
        public int PostId { get; set; }
        public string PostContent { get; set; }
        public string PostDate { get; set; }
        public List<Thread> ThreadId { get; set; }
        public List<User> UserId { get; set; }
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

