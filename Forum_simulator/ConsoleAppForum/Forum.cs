using System;
using System.Collections.Generic;
using System.Text;
using ForumsLibrary;

namespace ConsoleAppForum
{
    public class Forum
    {
        private Post _postRepo = new Post();
        private User _userRepo = new User();
        private Thread _threadRepo = new Thread();

        public void Run()
        {
            //PrintThreads(_threadRepo);
            //PrintThreadContentById(_postRepo,_threadRepo);
            //ListUsers(_userRepo);
            //AddThread();
            //AddPost();
            //UpdatePost(_postRepo);
            //DeletePost(_postRepo);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t------Welcome to the Forum-simulator!------");   //välkommen meddelande
                Console.WriteLine("\nEnter a Command:\n" +
                                  "[A] Add Post\n" +
                                  "[B] Update Post\n" +
                                  "[C] Remove Post\n" +
                                  "[D] Add Thread\n" +
                                  "[E] Show All Threads\n" +
                                  "[F] Show Thread By Id\n" +
                                  "[G] List Users\n" +
                                  "[X] Exit");
                ConsoleKeyInfo inputFromUser = Console.ReadKey(true);        //Consolekeyinfo är en klass funkar som direkt knapp
                switch (inputFromUser.Key)                                  //switch case för huvud meny
                {
                    case ConsoleKey.A:
                        {

                            break;
                        }
                    case ConsoleKey.B:
                        {

                            break;
                        }
                    case ConsoleKey.C:
                        {

                            Environment.Exit(0);
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Please choose something in the menu");
                            break;
                        }
                }
            }

        }
        public void AddPost()
        {
            var post = new Post();
            Console.WriteLine("\t------Create Post------\n");

            User repo = _userRepo;
            var users = repo.GetUsers();
            foreach (var u in users)
            {
                Console.Write($"{u.Id}|{u.UserName} ");
            }
            Console.Write("\n\n(User List Is Printing Only For Testing App)\nEnter user id:");
            post.UserId = int.Parse(Console.ReadLine());

            Thread repos = _threadRepo;
            var threads = repos.GetThreads();
            foreach (var thread in threads)
            {
                Console.Write($"\n{thread.Id}| {thread.Subject} ");
            }
            Console.Write("\nEnter thread id: ");
            post.ThreadId = int.Parse(Console.ReadLine());

            Console.Write("\nType Your Idea And Press Enter: ");
            post.Content = Console.ReadLine();
            _postRepo.Create(post);
        }
        public void UpdatePost(Post repo)
        {
            Console.WriteLine("\t------Update Post------\n");

            Console.Write("Enter Old Post Id: ");
            var postId = int.Parse(Console.ReadLine());
            var post = repo.GetPostById(postId);

            Console.Write("Type Your New Idea And Press Enter:: ");
            post.Content = Console.ReadLine();
            repo.Update(post);
            Console.WriteLine("\nYour Post Updated. Press Any Key To Continue...");
            Console.ReadKey();
        }
        public void DeletePost(Post repo)
        {
            Console.WriteLine("\t------Delete Post------\n");
            Console.Write("Enter a Post Id: ");
            var postId = int.Parse(Console.ReadLine());
            var post = repo.GetPostById(postId);
            repo.Delete(post);

            Console.WriteLine("\nPost Deleted Successfully. Press Any Key To Continue...");
            Console.ReadKey();
        }
        public void AddThread()
        {
            var thread = new Thread();
            Console.WriteLine("\t------Create Thread------\n");
            Console.Write("Enter a Subject : ");
            thread.Subject = Console.ReadLine();
            _threadRepo.CreateThread(thread);
            Console.WriteLine("\nThreat Created. Press Any Key To Continue...");
            Console.ReadKey();
        }
        public void ShowThreads(Thread repo)
        {
            var threads = repo.GetThreads();
            Console.WriteLine("\t------Threads------");
            Console.WriteLine("Id\t | Subject\t | User Name | Post Count\n");
            foreach (var thread in threads)
            {
                if (thread.PostCount == 0)
                {
                    Console.WriteLine($"{thread.Id}\t | {thread.Subject}\t\t | {thread.PostCount}");
                }
                else
                {
                    Console.WriteLine($"{thread.Id}\t | {thread.Subject}\t | {thread.Creator}\t | {thread.PostCount}");
                }
            }
        }
        public void ShowThreadContentById(Post postrepo, Thread threadrepo)
        {
            Thread repo = _threadRepo;
            var threads = repo.GetThreads();
            Console.WriteLine("\t------List Threads Content By Id------\n");

            foreach (var thre in threads)
                Console.Write($"|{thre.Id}-{thre.Subject} |");

            Console.Write("\n\nEnter Thread Id: ");

            var threadId = int.Parse(Console.ReadLine());
            var thread = threadrepo.GetById(threadId);
            var posts = postrepo.GetPostsByThread(thread);

            Console.WriteLine($"\n\t------\"{thread.Subject}\"------\n" +
                              $"\nUser | Post (Post Id)\n");

            foreach (var p in posts)            
                Console.WriteLine($"\t{p.User.UserName} | {p.Content} ({p.Id})\n");            
        }
        public void ListUsers(User repo)
        {
            var users = repo.GetUsers();
            Console.WriteLine("\t------Users List------");
            Console.WriteLine("\nid| User Name\n");
            foreach (var u in users)
                Console.WriteLine($"{u.Id}| {u.UserName}");
        }
    }
}
