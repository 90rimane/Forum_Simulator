using System;
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
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t------Welcome to the Forum-simulator!------"); 
                Console.WriteLine("\nEnter a Command:\n\n" +
                                  "[A] Add Post\n" +
                                  "[B] Update Post\n" +
                                  "[C] Remove Post\n" +
                                  "[D] Add Thread\n" +
                                  "[E] Show All Threads\n" +
                                  "[F] Show Thread By Id\n" +
                                  "[G] List Users\n" +
                                  "[X] Exit");
                ConsoleKeyInfo inputFromUser = Console.ReadKey(true);        
                switch (inputFromUser.Key)                                  
                {
                    case ConsoleKey.A:
                        {
                            AddPost();
                            break;
                        }
                    case ConsoleKey.B:
                        {
                            UpdatePost(_postRepo);
                            break;
                        }
                    case ConsoleKey.C:
                        {
                            DeletePost(_postRepo);
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            AddThread();
                            break;
                        }
                    case ConsoleKey.E:
                        {
                            ShowThreads(_threadRepo);
                            break;
                        }
                    case ConsoleKey.F:
                        {
                            ShowThreadContentById(_postRepo, _threadRepo);
                            break;
                        }
                    case ConsoleKey.G:
                        {
                            ListUsers(_userRepo);
                            break;
                        }
                    case ConsoleKey.X:
                        {

                            Environment.Exit(0);
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Please Choose Something In The Menu");
                            break;
                        }
                }
            }
        }
        public void AddPost()
        {
            Console.Clear();
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

            Console.WriteLine("\nYour Post Added. Press Any Key To Continue...");
            Console.ReadKey(true);
        }
        public void UpdatePost(Post repo)
        {
            Console.Clear();
            Console.WriteLine("\t------Update Post------\n");

            Console.Write("Enter Old Post Id: ");
            var postId = int.Parse(Console.ReadLine());
            var post = repo.GetPostById(postId);

            Console.Write("Type Your New Idea And Press Enter:: ");
            post.Content = Console.ReadLine();
            repo.Update(post);
            Console.WriteLine("\nPost Updated Successfuly. Press Any Key To Continue...");
            Console.ReadKey(true);
        }
        public void DeletePost(Post repo)
        {
            Console.Clear();
            Console.WriteLine("\t------Delete Post------\n");
            Console.Write("Enter a Post Id: ");
            var postId = int.Parse(Console.ReadLine());
            var post = repo.GetPostById(postId);
            repo.Delete(post);

            Console.WriteLine("\nPost Deleted Successfully. Press Any Key To Continue...");
            Console.ReadKey(true);
        }
        public void AddThread()
        {
            Console.Clear();
            var thread = new Thread();
            Console.WriteLine("\t------Create Thread------\n");
            Console.Write("Enter a Subject : ");
            thread.Subject = Console.ReadLine();
            _threadRepo.CreateThread(thread);

            Console.WriteLine("\nThreat Created Successfuly. Press Any Key To Continue...");
            Console.ReadKey(true);
        }
        public void ShowThreads(Thread repo)
        {
            Console.Clear();
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
            Console.WriteLine("\nPress Any Key To Continue...");
            Console.ReadKey(true);
        }
        public void ShowThreadContentById(Post postrepo, Thread threadrepo)
        {
            Console.Clear();
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

            Console.WriteLine("\nPress Any Key To Continue...");
            Console.ReadKey(true);
        }
        public void ListUsers(User repo)
        {
            Console.Clear();
            var users = repo.GetUsers();
            Console.WriteLine("\t------Users List------");
            Console.WriteLine("\nid| User Name\n");
            foreach (var u in users)
                Console.WriteLine($"{u.Id}| {u.UserName}");

            Console.WriteLine("\nPress Any Key To Continue...");
            Console.ReadKey(true);
        }
    }
}
