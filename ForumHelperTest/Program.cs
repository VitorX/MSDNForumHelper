using MSDNForumHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumHelperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var retchRequest = new FetchRequest();
            retchRequest.ForumName = "vsto";
            retchRequest.PagesPerRequest = 2;

            var threads = retchRequest.Run();

            const int nameWidth = -20;
            int index = 1;
            foreach (var thread in threads)
            {
                Console.WriteLine(index++);
                Console.WriteLine($"{"id",nameWidth}: {thread.ThreadId}");
                Console.WriteLine($"{"title",nameWidth}: {thread.ThreadTitle}");
                Console.WriteLine($"{"isAnswered",nameWidth}: {thread.IsAnswered}");
                Console.WriteLine($"{"createdTime",nameWidth}: {thread.CreatedTime}");
                Console.WriteLine($"{"lastRepliedBy",nameWidth}: {thread.LastRepliedBy}");
                Console.WriteLine($"{"lastRepliedTime",nameWidth}: {thread.LastRepliedTime}");
                Console.WriteLine("");
            }

            ThreadContext threadsContext = new ThreadContext();
            var threadsFromDB = threadsContext.Threads.ToList();
            IEnumerable<Thread> newThreads = threads.Except(threadsFromDB);
            if (newThreads.Count() > 0)
                threadsContext.Threads.AddRange(newThreads);

            threadsContext.SaveChanges();
            Console.ReadLine();
        }
    }
}
