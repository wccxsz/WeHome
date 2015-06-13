using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;

namespace WeHome.Entities
{
    [Table("T_Role")]
    public class Role : IRole<int>
    {
        [Column("F_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("F_RoleName"), MaxLength(100)]
        public string Name { get; set; }

        [Column("F_CreateTime")]
        public DateTime CreateTime { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

