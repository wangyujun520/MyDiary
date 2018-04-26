using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDiary.Models
{
    public class User
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("UserName"), Required]//Required是非空
        public string UserName { get; set; }

        [DisplayName("PassWord"), Required,DataType(DataType.Password)]//密码不允许为空，datatype的验证类型，当前类型显示成password，这样用户在页面输入密码的时候就不会以名文的方式显示当前密码了
        public string PassWord { get; set; }

        [DisplayName("Diaries")]
        public virtual List<Diary> Diaries { get; set; }//关联了某个用户下所有的日记,virtual预加载
    }
}