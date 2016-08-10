using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MSDNForumHelper
{
    public class FetchRequest
    {
        public string BaseUrl { set; get; }

        public string Category { set; get; }
        //=officedev&forum=wfprerelease&filter=alltypes&sort=lastpostdesc
        public string ForumName { set; get; }
        public string Filter { set; get; }
        public string Sort { set; get; }

        public int PagesPerRequest = 1;

        private int ThreadsCount;

        private string requestUrl = "";
        private System.Object lockThis = new System.Object();
        public FetchRequest(string baseUrl = "https://social.msdn.microsoft.com/Forums/office/en-US/home")
        {
            this.BaseUrl = baseUrl;
        }

        private void InitRequestUrl()
        {
            Dictionary<string, string> urlParamters = new Dictionary<string, string>();
            AddUrlParameter(urlParamters, "Category", Category);
            AddUrlParameter(urlParamters, "forum", ForumName);
            AddUrlParameter(urlParamters, "Filter", Filter);
            AddUrlParameter(urlParamters, "Sort", Sort);

            bool baseUrlCotainsQuestionMark = BaseUrl.Contains("?");
            foreach (var urlParamter in urlParamters)
            {
                if (BaseUrl.Contains("?"))
                    requestUrl = $"{requestUrl}&{urlParamter.Key}={urlParamter.Value}";
                else
                    requestUrl = $"{requestUrl}?{urlParamter.Key}={urlParamter.Value}";
            }

            requestUrl = BaseUrl + requestUrl;
        }

        private void AddUrlParameter(Dictionary<string, string> urlParamters, string urlName, string urlValue)
        {
            if (!String.IsNullOrEmpty(urlValue))
                urlParamters.Add(urlName, urlValue);
        }

        public List<Thread> Run()
        {

            InitRequestUrl();

            HttpClient client = new HttpClient();
            //var tasks = new List<Task<HttpResponseMessage>>();
            var tasks = new List<Task>();
            MSDNThreadParse threadParse = new MSDNThreadParse();
            var threads = new List<Thread>();


            for (int i = 1; i <= PagesPerRequest; i++)
            {
                Task<HttpResponseMessage> task;
                if (i == 1)
                {
                    task = new Task<HttpResponseMessage>(() => { return client.GetAsync(requestUrl).Result; });

                }
                else
                {
                    var requestUrlWithPage = $"{requestUrl}&page={i}";
                    task = new Task<HttpResponseMessage>(() => { return client.GetAsync(requestUrlWithPage).Result; });
                }
                Task taskParseResponse =task.ContinueWith(t => {
                    threads.AddRange(threadParse.Parse(t.Result.Content.ReadAsStringAsync().Result).ToArray());
                });
                tasks.Add(taskParseResponse);
                task.Start();
            }

            try
            {
                Task.WaitAll(tasks.ToArray());
                return threads;
            }
            catch (Exception ex)
            {
                return threads;
            }

        }
    }
}
