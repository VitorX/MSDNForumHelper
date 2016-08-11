using System;

namespace MSDNForumHelper
{
    public class Thread
    {
        public string ThreadId { set; get; }
        public string CreatedBy { set; get; }
        public DateTime? CreatedTime { set; get; }
        public DateTime? LastRepliedTime { set; get; }
        public DateTime? FirstAnsweredDate { set; get;}
        public bool IsAnswered { set; get; }
        public string LastRepliedBy { set; get; }
        public string ThreadTitle { set; get; }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Thread p = obj as Thread;
            if ((System.Object)p == null)
            {
                return false;
            }

            return ThreadId.Equals(p.ThreadId, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return ThreadId.GetHashCode();
        }
    }
}