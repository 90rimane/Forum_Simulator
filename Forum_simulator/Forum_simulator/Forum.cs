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
            var repo = new User();
            repo.PrintVersion();
        }
    }
}
