using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDNForumHelper
{
    public class ThreadContext:DbContext
    {
        public ThreadContext() : base("ThreadsDB")
        {
        }

        public DbSet<Thread> Threads { set; get; }
    }
}
