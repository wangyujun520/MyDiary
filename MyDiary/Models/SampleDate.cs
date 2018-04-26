using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.Entity;

namespace MyDiary.Models
{
    public class SampleDate:DropCreateDatabaseAlways<DiaryDB>//每次总是删除并重建数据库
    {
        protected override void Seed(DiaryDB context)
        {
            context.Users.Add(new User
            {
                UserName = "zhangsan",
                PassWord = "zhangsan",
                Diaries = new List<Diary>()
                {
                    new Diary{Title="Title01",Content="Content01",PubDate=DateTime.Now},
                    new Diary{Title="Title02",Content="Content02",PubDate=DateTime.Now},
                    new Diary{Title="Title03",Content="Content03",PubDate=DateTime.Now}
                }
            });

            context.Users.Add(new User
            {
                UserName = "lisi",
                PassWord = "lisi",
                Diaries = new List<Diary>()
                {
                    new Diary{Title="Title04",Content="Content04",PubDate=DateTime.Now},
                    new Diary{Title="Title05",Content="Content05",PubDate=DateTime.Now},
                    new Diary{Title="Title06",Content="Content06",PubDate=DateTime.Now}
                }
            });

        }
    }
}