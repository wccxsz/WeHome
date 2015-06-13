using System;
using System.Linq;
using WeHome.Data.Context;
using WeHome.Entities;

namespace WeHome.BLL
{
    public class UserBll
    {
        private WeHomeContext _db;

        internal UserBll(WeHomeContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 查找个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetUser(int? id = null, string userName = "")
        {
            
            if (id == null && string.IsNullOrEmpty(userName))
                throw new ArgumentNullException();
            if (id!=null)
            {
                return _db.Users.Find(id.Value);
            }
            if (string.IsNullOrEmpty(userName)) return null;
            userName = userName.ToLower();
            return _db.Users.FirstOrDefault(c => c.UserName == userName);
        }
    }
}
