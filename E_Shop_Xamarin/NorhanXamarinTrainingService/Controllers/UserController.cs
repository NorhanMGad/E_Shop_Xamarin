using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using NorhanXamarinTrainingService.Models;
using NorhanXamarinTrainingService.DataObjects;
using System.Linq;
using System.Collections.Generic;

namespace NorhanXamarinTrainingService.Controllers
{
    [MobileAppController]
    public class UserController : ApiController
    {
        private NorhanXamarinTrainingContext dbCntxt = new NorhanXamarinTrainingContext();
        // GET api/User
        [Route("{id:int}")]
        public string Get(int id)
        {
            return "Hello from custom controller! "+id;
        }

        public void Post([FromUri] int id,[FromBody] List<Cart> items)
        {
            foreach(var c in items)
            {
                var item = dbCntxt.Items.Find(c.RelatedItemID);
                if (item.Quantity >= c.UserQuantity)
                {
                    item.Quantity -= c.UserQuantity;
                }
            }
            dbCntxt.SaveChanges();
        }

        public int Post([FromBody]string username)
        {
            var lstUsers = dbCntxt.Users.Where(u => u.UserName == username).ToList();
            if (lstUsers.Count() == 0)
            {
                User newUser = new User() { UserName = username };
                dbCntxt.Users.Add(newUser);
                dbCntxt.SaveChanges();
                return newUser.ID;
            }
            else
            {
                return lstUsers[0].ID;
            }
        }
    }
}
