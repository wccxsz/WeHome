using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeHome.Data.Store;
using WeHome.Entities;
using WeHome.Framework.Tools;

namespace WeHome.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddRole()
        {
            var roleStore = new RoleStore();
            roleStore.CreateAsync(new Role()
            {
                Name = "Mother",
                CreateTime = DateTime.Now
            });
        }

        [TestMethod]
        public void TestMethod1()
        {
            var user = new User()
            {
                AccessFailedCount = 0,
                ConsecutiveNumber = 0,
                Email = "duan@126.com",
                EmailConfirmed = false,
                EmployeeName = "段玉梅",
                Icon = "",
                IsDisabled = false,
                IsLocked = false,
                LockoutEnabled = true,
                LockoutEndDateUtc = DateTime.Now.AddDays(-1),
                Password = "18678399843",
                PhoneNumber = "18678399843",
                PhoneNumberConfirmed = false,
                SCore = 0,
                UserName = "duanyumei",
                Roles = new List<Role>(5)
            };
            user.Roles.Add(new Role() {Name = "Mother", CreateTime = DateTime.Now});
            var userStore = new UserStore<User, int>();
            userStore.CreateAsync(user);
        }

        [TestMethod]
        public void SendEmail()
        {
            Email.SendMail("密码重置邮件", "403033546@qq.com");
        }
    }
}
