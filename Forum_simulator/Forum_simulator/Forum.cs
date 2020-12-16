using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumLibrary;

namespace Forum_simulator
{
    public class Forum
    {
        public void Run()
        {

            //var threRepo = new Thread();
            //PrintThread(threRepo);

            var user = new User(null,null);
            user.PrintVersion();
            user.AddUser();
        }

        //private void PrintThread(Thread repository)
        //{
        //    var threads = repository.GetThread();
        //    foreach (var thread in threads)
        //    {
        //        Console.WriteLine($"Thread List: {thread.ThreadSubject },categoriesId: { thread.CatId}, {thread.ThreadDate},{ thread.Cats}");
        //        Console.ReadKey();
        //    }
        //}

        
    }
}
