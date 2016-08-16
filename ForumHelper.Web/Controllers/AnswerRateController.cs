using MSDNForumHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ForumHelper.Web.Controllers
{
    public class AnswerRateController : ApiController
    {

        public string Post([FromBody]ARRequest arRequest)
        {
            return $"ok:{arRequest.BeginDate},{arRequest.EndDate}";
        }

    }

   
}