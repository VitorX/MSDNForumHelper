using HtmlAgilityPack;
using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDNForumHelper
{
    class MSDNThreadParse : IThreadHelper
    {
        public List<Thread> Parse(string htmlThread)
        {
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(htmlThread);

            var threads = new List<Thread>();
            Thread t1;
            DateTime createdTime;
            bool parseCreatedTime = false;
            foreach (var childNode in html.DocumentNode.SelectNodes("//ul[@id='threadList']/li[@data-threadid]"))
            {
                t1 = new Thread();
                t1.ThreadId = childNode.Attributes["data-threadid"].Value;
                var header = childNode.DescendantNodes(3).FirstOrDefault(node => node.Name == "h3");
                var nodeTitle = header.ChildNodes.FirstOrDefault(node => node.Name == "a");
                t1.ThreadTitle = nodeTitle.InnerText;
                t1.IsAnswered = !(childNode.SelectNodes("div/div[@class='details']/div[@class='detailscontainer']/div[@class='metrics smallgreytext']/span/a").FirstOrDefault().InnerText.ToLower() == "unanswered");
                parseCreatedTime=DateTime.TryParse(childNode.SelectNodes("div/div[@class='details']/div[@class='detailscontainer']/div[@class='metrics smallgreytext']/span[7]/span[2]").FirstOrDefault().InnerText, out createdTime);
                t1.CreatedTime = parseCreatedTime? createdTime:new DateTime(1971,1,1);
                threads.Add(t1);
            }
            return threads;
        }

  
    }
}
