using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using WeHome.Data.Context;
using WeHome.Entities;
using WeHome.Framework.Tools;

namespace WeHome.Data.Store
{
    public class RoleStore : IRoleStore<Role, int>
    {
        private readonly WeHomeContext _dbcontext = new WeHomeContext();

        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        public Task CreateAsync(Role role)
        {
            Check.NotNull(role, "role");
            _dbcontext.Roles.Add(role);
            return Task.FromResult<int>(_dbcontext.SaveChanges());
        }

        public Task UpdateAsync(Role role)
        {
            Check.NotNull(role, "role");
            _dbcontext.Roles.AddOrUpdate(role);
            return Task.FromResult<int>(_dbcontext.SaveChanges());
        }

        public Task DeleteAsync(Role role)
        {
            Check.NotNull(role, "role");
            _dbcontext.Roles.Remove(role);
            return Task.FromResult(_dbcontext.SaveChanges());
        }

        public Task<Role> FindByIdAsync(int roleId)
        {
            var role = _dbcontext.Roles.Find(roleId);
            return Task.FromResult<Role>(role);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            Check.NotEmpty(roleName, "roleName");
            var role = _dbcontext.Roles.FirstOrDefault(c => c.Name == roleName);
            return Task.FromResult<Role>(role);
        }
    }
}
