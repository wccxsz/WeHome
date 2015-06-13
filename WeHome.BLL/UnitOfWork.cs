using System;
using WeHome.Data.Context;

namespace WeHome.BLL
{
    public class UnitOfWork : IDisposable
    {
        private readonly WeHomeContext _db;
        private UserBll _userBll;

        public void Dispose()
        {
            _db.Dispose();
        }

        public UnitOfWork()
        {
            _db = new WeHomeContext();
        }

        public UserBll UserBll
        {
            get { return _userBll ?? (_userBll = new UserBll(_db)); }
        }

    }

}
