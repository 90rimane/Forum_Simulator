using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumLibrary;

namespace Forum_simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var myForum = new Forum();
            myForum.Run();
            Console.ReadKey();
        }
    }
}
