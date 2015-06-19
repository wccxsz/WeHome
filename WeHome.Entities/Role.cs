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
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("RoleName"), MaxLength(100)]
        public string Name { get; set; }

        [Column("CreateTime")]
        public DateTime CreateTime { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

