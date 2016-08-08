using System;

namespace MSDNForumHelper
{
    public class Thread
    {
        public string ThreadId { set; get; }
        public string CreatedBy { set; get; }
        public DateTime CreatedTime { set; get; }
        public bool IsAnswered { set; get; }

        public DateTime FirstAnsweredDate { set; get;}

        public string LastRepliedBy { set; get; }
        public string ThreadTitle { set; get; }

    }
}