using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDNForumHelper
{
    interface IThreadParse
    {
        List<Thread> Parse(string htmlThread);
    }
}
