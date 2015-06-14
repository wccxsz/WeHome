using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeHome.Framework.Enums;

namespace WeHome.Entities
{
    public class MediaRecord
    {
        [Column("F_MediaRecordID")]
        public int Id { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        [Column("F_MediaType")]
        public MediaType MediaType { get; set; }

        /// <summary>
        /// 文件访问路径
        /// </summary>
        [Column("F_MediaUrl")]
        [MaxLength(500)]
        public string MediaUrl { get; set; }

        /// <summary>
        /// 拍摄时间
        /// </summary>
        [Column("F_MakeDate")]
        public DateTime MakeDate { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        [Column("F_CreateTime")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 文件描述
        /// </summary>
        [Column("F_MediaDes")]
        public string MediaDescription { get; set; }

        public virtual ICollection<Baby> Babies { get; set; }

        [Column("F_Creator")]
        public int CreateUserId { get; set; }

        [ForeignKey("CreateUserId")]
        public virtual User CreateUser { get; set; }
    }
}
