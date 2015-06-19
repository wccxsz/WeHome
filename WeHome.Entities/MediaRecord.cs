using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeHome.Framework.Enums;

namespace WeHome.Entities
{
    [Table("T_MediaRecord")]
    public class MediaRecord
    {
        [Column("MediaRecordID")]
        public int Id { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        [Column("MediaType")]
        public MediaType MediaType { get; set; }

        /// <summary>
        /// 文件访问路径
        /// </summary>
        [Column("MediaUrl")]
        [MaxLength(500)]
        public string MediaUrl { get; set; }

        /// <summary>
        /// 拍摄时间
        /// </summary>
        [Column("MakeDate")]
        public DateTime MakeDate { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        [Column("CreateTime")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 文件描述
        /// </summary>
        [Column("MediaDes")]
        public string MediaDescription { get; set; }

        public virtual ICollection<Baby> Babies { get; set; }

        [Column("Creator")]
        public int CreateUserId { get; set; }

        [ForeignKey("CreateUserId")]
        public virtual User CreateUser { get; set; }
    }
}
