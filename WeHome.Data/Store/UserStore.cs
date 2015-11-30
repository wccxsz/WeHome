using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using WeHome.Data.Context;
using WeHome.Entities;
using WeHome.Framework.Tools;

namespace WeHome.Data.Store
{
    public class UserStore<TUser, TKey> : IUserStore<TUser, TKey>,
        IUserLockoutStore<TUser, TKey>,
        IUserPasswordStore<TUser, TKey> where TUser : User, IUser<TKey>
    {
        private readonly WeHomeContext _dbcontext = new WeHomeContext();


        #region IUserStore

        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        public Task CreateAsync(TUser user)
        {
            Check.NotNull(user, "user");
            user.Password = EncryptTool.Encrypt(user.Password);
            _dbcontext.Users.Add(user);
            return Task.FromResult<int>(_dbcontext.SaveChanges());
        }

        public Task UpdateAsync(TUser user)
        {
            Check.NotNull(user, "user");
            _dbcontext.Users.AddOrUpdate(user);
            return Task.FromResult<int>(_dbcontext.SaveChanges());
        }

        public Task DeleteAsync(TUser user)
        {
            Check.NotNull(user, "user");
            _dbcontext.Users.Remove(user);
            return Task.FromResult(_dbcontext.SaveChanges());
        }

        public Task<TUser> FindByIdAsync(TKey userId)
        {
            var id = userId as int?;
            Check.NotNull(id, "userId");
            var user = (TUser) _dbcontext.Users.Find(userId);
            return Task.FromResult<TUser>(user);
        }

        public Task<TUser> FindByNameAsync(string userName)
        {
            Check.NotEmpty(userName, "userName");
            var user = (TUser) _dbcontext.Users.FirstOrDefault(c => c.UserName == userName);
            user.Password = EncryptTool.Decrypt(user.Password);
            return Task.FromResult<TUser>(user);
        }

        #endregion

        #region IUserLockoutStore

        public Task<DateTimeOffset> GetLockoutEndDateAsync(TUser user)
        {
            DateTimeOffset dateTimeOffset;
            Check.NotNull(user, "user");
            if (user.LockoutEndDateUtc.HasValue)
            {
                DateTime? lockoutEndDateUtc = user.LockoutEndDateUtc;
                dateTimeOffset = new DateTimeOffset(DateTime.SpecifyKind(lockoutEndDateUtc.Value, DateTimeKind.Utc));
            }
            else
            {
                dateTimeOffset = new DateTimeOffset();
            }
            return Task.FromResult<DateTimeOffset>(dateTimeOffset);
        }

        public Task SetLockoutEndDateAsync(TUser user, DateTimeOffset lockoutEnd)
        {
            Check.NotNull(user, "user");
            var nullable = lockoutEnd == DateTimeOffset.MinValue ? null : new DateTime?(lockoutEnd.UtcDateTime);
            user.LockoutEndDateUtc = nullable;
            return Task.FromResult<int>(_dbcontext.SaveChanges());
        }

        public Task<int> IncrementAccessFailedCountAsync(TUser user)
        {
            Check.NotNull(user, "user");
            user.AccessFailedCount = user.AccessFailedCount + 1;
            _dbcontext.SaveChanges();
            return Task.FromResult<int>(user.AccessFailedCount);
        }

        public Task ResetAccessFailedCountAsync(TUser user)
        {
            Check.NotNull(user, "user");
            user.AccessFailedCount = 0;
            return Task.FromResult<int>(_dbcontext.SaveChanges());
        }

        public Task<int> GetAccessFailedCountAsync(TUser user)
        {
            Check.NotNull(user, "user");
            return Task.FromResult<int>(user.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(TUser user)
        {
            Check.NotNull(user, "user");
            return Task.FromResult<bool>(user.LockoutEnabled);
        }

        public Task SetLockoutEnabledAsync(TUser user, bool enabled)
        {
            Check.NotNull(user, "user");
            user.LockoutEnabled = enabled;
            return Task.FromResult<int>(_dbcontext.SaveChanges());
        }

        #endregion

        #region IUserPasswordStore

        public Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            Check.NotNull(user, "user");
            user.Password = passwordHash;
            return Task.FromResult<int>(0);
        }

        public Task<string> GetPasswordHashAsync(TUser user)
        {
            Check.NotNull(user, "user");
            return Task.FromResult<string>(user.Password);
        }

        public Task<bool> HasPasswordAsync(TUser user)
        {
            return Task.FromResult<bool>(user.Password != null);
        }

        #endregion
    }
}
