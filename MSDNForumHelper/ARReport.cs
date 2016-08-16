using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDNForumHelper
{
    public class ARReport
    {
        public int TotalThreads;
        public int AnsweredThreads;

        public static ARReport GetReport(ARRequest arRequest)
        {
            ARReport arReport = new ARReport();
            ThreadContext threadsContext = new ThreadContext();
            var threads = threadsContext.Threads.Where(t => t.CreatedTime >= arRequest.BeginDate && t.CreatedTime <= arRequest.EndDate);
            arReport.TotalThreads = threads.Count();
            arReport.AnsweredThreads=threads.Where(t => t.IsAnswered).Count();

            return arReport;
        }
    }


    public class ARRequest
    {
        public DateTime BeginDate;
        public DateTime EndDate;
    }
}
