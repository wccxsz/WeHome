using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeHome.Framework.Enums;

namespace WeHome.Entities
{
    [Table("T_Baby")]
    public class Baby
    {
        /// <summary>
        /// 宝贝Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("F_BabyID")]
        public int Id { get; set; }

        /// <summary>
        /// 宝贝姓名
        /// </summary>
        [Column("F_BabyName")]
        [MaxLength(50)]
        public string BabyName { get; set; }

        /// <summary>
        /// 宝贝唯一编号
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// 宝贝小名
        /// </summary>
        [Column("F_NickName")]
        [MaxLength(50)]
        public string NickName { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [Column("F_Birthday")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 生日阴历Or阳历
        /// </summary>
        [Column("F_BirthDateType")]
        public BirthDateType BirthDateType { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Column("F_Sexuality")]
        public Sexuality Sexuality { get; set; }

        /// <summary>
        /// 出生体重
        /// </summary>
        [Column("F_Weight")]
        public decimal Weight { get; set; }

        /// <summary>
        /// 出生时身高
        /// </summary>
        [Column("F_Stature")]
        public decimal Stature { get; set; }

        /// <summary>
        /// 婴儿出生健康状况
        /// </summary>
        [Column("F_HealthState")]
        public HealthState HealthState { get; set; }

        /// <summary>
        /// 婴儿简况状况描述
        /// </summary>
        [Column("F_HealthDescription")]
        public string HealthDescription { get; set; }

        [Column("F_FatherID")]
        public int FatherId { get; set; }

        [Column("F_MotherID")]
        public int MotherId { get; set; }

        /// <summary>
        /// 爸爸
        /// </summary>
        [ForeignKey("FatherId")]
        public virtual User Father { get; set; }

        /// <summary>
        /// 妈妈
        /// </summary>
        [ForeignKey("MotherId")]
        public virtual User Mother { get; set; }

        /// <summary>
        /// 相关的视频和照片
        /// </summary>
        public virtual ICollection<MediaRecord> MediaRecords { get; set; }
    }
}
