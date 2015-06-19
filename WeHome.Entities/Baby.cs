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
        [Column("BabyID")]
        public int Id { get; set; }

        /// <summary>
        /// 宝贝姓名
        /// </summary>
        [Column("BabyName")]
        [MaxLength(50)]
        public string BabyName { get; set; }

        /// <summary>
        /// 宝贝唯一编号
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// 宝贝小名
        /// </summary>
        [Column("NickName")]
        [MaxLength(50)]
        public string NickName { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [Column("Birthday")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 生日阴历Or阳历
        /// </summary>
        [Column("BirthDateType")]
        public BirthDateType BirthDateType { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Column("Sexuality")]
        public Sexuality Sexuality { get; set; }

        /// <summary>
        /// 出生体重
        /// </summary>
        [Column("Weight")]
        public decimal Weight { get; set; }

        /// <summary>
        /// 出生时身高
        /// </summary>
        [Column("Stature")]
        public decimal Stature { get; set; }

        /// <summary>
        /// 婴儿出生健康状况
        /// </summary>
        [Column("HealthState")]
        public HealthState HealthState { get; set; }

        /// <summary>
        /// 婴儿简况状况描述
        /// </summary>
        [Column("HealthDescription")]
        public string HealthDescription { get; set; }

        [Column("FatherID")]
        public int FatherId { get; set; }

        [Column("MotherID")]
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
