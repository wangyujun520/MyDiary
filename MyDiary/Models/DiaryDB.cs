using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyDiary.Models
{
    public class DiaryDB:DbContext
    {
        //映射两张表
        public DbSet<User> Users { get; set; }//用户存到数据库的表
        public DbSet<Diary> Diaries { get; set; }//日记表
    }
}