using System;
using System.Collections.Generic;
using System.Text;

namespace ForumLibrary
{
    class Thread
    {
        public Thread()
        {
        }
        public int ThreadId { get; set; }
        public string ThreadSubject { get; set; }
        public string ThreadDate { get; set; }
        public List<Category> CatId { get; set; }
        public List<User> UserId { get; set; }
        private void CreateThread()
        {

        }
        private void ListThreadContent()      //name of thread,who created, how many post exist in threads
        {

        }
        // For a given thread it should be possible to view all posts that were created in it
    }
}

