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
            using (var ctx = IdentityContext.Create())
            {
                var user = new User();
                return user.GetUsers(ctx)
                           .Where(x => x.UserName != username)
                           .ToList();
            }
        }
    }
}
