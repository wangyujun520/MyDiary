using MyDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDiary.Controllers
{
    public class HomeController : Controller
    {
        //实例化DiaryDB数据库
        DiaryDB db = new DiaryDB();


        public ActionResult Index()
        {
            //实例化一个空集合
            var diaries = new List<Diary>();
            //判断用户是否已经登录
            if (Session["User"]!=null)
            {
                //说明已登录，进行一个查找，根据用户的编号进行查找
                var userId = ((User)Session["User"]).Id;//获取用户ID
                //查找所有的日记
                //根据已登录用户查找该用户下所有的日记
                diaries = db.Diaries.Where(d => d.UserId == userId).ToList();
            }
            return View(diaries);
        }
        /// <summary>
        /// 根据id进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Remove(int id)
        {
            //定义变量
            var diary = db.Diaries.FirstOrDefault(d => d.Id == id);//查找要删除的编号是否存在
            //如果存在进行删除
            db.Diaries.Remove(diary);//将要删除的对象移除
            //保存提交到数据库
            db.SaveChanges();
            //返回到首页
            return RedirectToAction("Index","Home");//在视图中进行展示
        }

        /// <summary>
        /// 跳转到添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Diary diary)
        {
            //如果session等于null会出现错误，所以需要追加一个判断
            if (Session["User"]==null)
            {
                return RedirectToAction("Login","Account");//如果session的值为空，那就返回到登录页面
            }
            diary.PubDate = DateTime.Now;//设置发布时间为当前时间
            diary.UserId = ((User)Session["User"]).Id;//这个UserId来自session
            //添加方法
            db.Diaries.Add(diary);
            //保存数据
            db.SaveChanges();
            //跳转回首页面
            return RedirectToAction("Index", "Home");
        }

    }
}