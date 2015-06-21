using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;

namespace WeHome.Entities
{
    [Table("T_Users")]
    public class User : IUser<int>
    {
        /// <summary>
        /// 账号ID
        /// </summary>
        [Column("UserID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 账号名
        /// </summary>
        [Index("Index_UserName", IsUnique = true)]
        [MaxLength(100)]
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 人员姓名
        /// </summary>
        [Column("EmployeeName"), MaxLength(50), Required]
        public string EmployeeName { get; set; }

        /// <summary>
        /// 用户Email
        /// </summary>
        [Column("Email"), DataType(DataType.EmailAddress, ErrorMessage = "邮件地址无效"), MaxLength(50), Required]
        [Index("Index_Email", IsUnique = true)]
        public string Email { get; set; }

        /// <summary>
        /// 邮箱是否确认
        /// </summary>
        [Column("EmailConfirmed")]
        public bool EmailConfirmed { get; set; }

        /// <summary>
        /// 账号密码
        /// </summary>
        [Column("Password"), Required, DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Column("PhoneNumber"), Required, DataType(DataType.PhoneNumber), MaxLength(20)]
        [Index("Index_PhoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 手机号确认
        /// </summary>
        [Column("PhoneNumberConfirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        /// 登录失败次数
        /// </summary>
        [Column("AccessFailedCount"), DefaultValue(0)]
        public int AccessFailedCount { get; set; }

        /// <summary>
        /// 是否启用账号锁定功能
        /// </summary>
        [Column("LockoutEnabled")]
        public bool LockoutEnabled { get; set; }

        /// <summary>
        /// 账号锁定截止时间
        /// </summary>
        [Column("LockoutEndDateUtc")]
        public DateTime? LockoutEndDateUtc { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        [Column("IsLocked")]
        public bool IsLocked { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        [Column("IsDisabled")]
        public bool IsDisabled { get; set; }

        /// <summary>
        /// 账号积分
        /// </summary>
        [Column("Score")]
        public int SCore { get; set; }

        /// <summary>
        /// 连续登陆天数,默认值为0
        /// </summary>
        [Column("ConsecutiveNumber")]
        public int ConsecutiveNumber { get; set; }

        /// <summary>
        ///个人头像
        /// </summary>
        [Column("Icon"), MaxLength(255)]
        public string Icon { get; set; }

        /// <summary>
        /// 用户所属角色
        /// </summary>
        public virtual IList<Role> Roles { get; set; }
    }
}
