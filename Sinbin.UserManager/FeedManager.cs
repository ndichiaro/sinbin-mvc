using Sinbin.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinbin.UserManager
{
    public class FeedManager
    {
        public IList<User> GetFeed(string username)
        {
            var user = new User();
            return user.GetUsers()
                       .Where(x => x.UserName != username)
                       .ToList();
        }
    }
}
