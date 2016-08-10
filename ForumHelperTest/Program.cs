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
            var threads= retchRequest.Run();
            const int nameWidth = -10;
            foreach (var thread in threads)
            {
                Console.WriteLine($"{"id",nameWidth}: {thread.ThreadId}");
                Console.WriteLine($"{"title",nameWidth}: {thread.ThreadTitle}");
                Console.WriteLine($"{"isAnswered",nameWidth}: {thread.IsAnswered}");
                Console.WriteLine($"{"createdTime",nameWidth}: {thread.CreatedTime}");
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }
}
