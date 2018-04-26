using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDiary.Models
{
    public class Diary
    {
        /// <summary>
        /// 编号
        /// </summary>
        [DisplayName("Id")]
        public int Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [DisplayName("Title"), Required]
        public string Title { get; set; }

        /// <summary>
        /// 日记内容
        /// </summary>
        [DisplayName("Content"), Required]
        public string Content { get; set; }

        /// <summary>
        /// 发布日期
        /// </summary>
        [DisplayName("PubDate"),DataType(DataType.Date)]//时间类型
        public DateTime? PubDate { get; set; }

        [DisplayName("UserId")]
        public int UserId { get; set; }//当前用户编号

        [DisplayName("User")]
        public virtual User User { get; set; }//当前用户的日记对象，外键类的使用，virtual表示预加载
        //表示的是Diary可以直接通过打点找到该属性
    }
}