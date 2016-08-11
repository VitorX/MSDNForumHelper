using HtmlAgilityPack;
using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDNForumHelper
{
    class MSDNThreadParse : IThreadParse
    {
        public List<Thread> Parse(string htmlThread)
        {
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(htmlThread);

            var threads = new List<Thread>();
            Thread t1;
            DateTime createdTime;
            DateTime lastRepliedTime;
            bool parseCreatedTime = false;
            bool parseLastRepliedTime = false;
            foreach (var childNode in html.DocumentNode.SelectNodes("//ul[@id='threadList']/li[@data-threadid]"))
            {
                t1 = new Thread();
                t1.ThreadId = childNode.Attributes["data-threadid"].Value.Trim();
                t1.ThreadTitle = childNode.SelectNodes("div/div/div/h3").FirstOrDefault().InnerText.Replace("\n","").Trim();
                t1.IsAnswered = !(childNode.SelectNodes("div/div[@class='details']/div[@class='detailscontainer']/div[@class='metrics smallgreytext']/span/a").FirstOrDefault().InnerText.ToLower() == "unanswered");

                parseCreatedTime=DateTime.TryParse(childNode.SelectNodes("div/div[@class='details']/div[@class='detailscontainer']/div[@class='metrics smallgreytext']/span[7]/span[2]").FirstOrDefault().InnerText, out createdTime);
                if (parseCreatedTime)
                    t1.CreatedTime = createdTime;

                t1.CreatedBy = childNode.SelectNodes("div/div[@class='details']/div[@class='detailscontainer']/div[@class='metrics smallgreytext']/span[7]/a/span[1]").FirstOrDefault().InnerText.Trim();
                t1.LastRepliedBy= childNode.SelectNodes("div/div[@class='details']/div[@class='detailscontainer']/div[@class='metrics smallgreytext']/span[9]/a[2]").FirstOrDefault().InnerText.Replace("-","").Trim();

                parseLastRepliedTime = DateTime.TryParse(childNode.SelectNodes("div/div[@class='details']/div[@class='detailscontainer']/div[@class='metrics smallgreytext']/span[9]/span").FirstOrDefault().InnerText, out lastRepliedTime);
                if (parseLastRepliedTime)
                    t1.LastRepliedTime = lastRepliedTime;
               
                threads.Add(t1);
            }
            return threads;
        }

  
    }
}
