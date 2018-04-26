using MyDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDiary.Controllers
{
    public class AccountController : Controller
    {
        //需要根据用户名和密码查找数据库，所以需要追加映射类DiaryDB
        DiaryDB db = new DiaryDB();//实例化

        //注销
        public ActionResult Logoff()
        {
            Session.Clear();//清空session，或者用Session.Remove();
            //从新跳转到网站的登录页面
            return RedirectToAction("Login", "Account");//控制器在后面，动作方法在前面
        }

        //登录
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            //根据用户名和密码查找当前用户    
            var item = db.Users.FirstOrDefault(u => u.UserName == user.UserName && u.PassWord == user.PassWord);
            if (item!=null)//代表在数据库里根据用户名和密码查找到了当前对象
            {
                Session["User"] = item;//将对象存放在session中
                //登录成功，跳转到首页
                return RedirectToAction("Index","Home");
            }
            ModelState.AddModelError("", "Login Error");//登录失败，自定义错误消息
            return View(user);//登录失败返回当前页，将user对象返回过去让用户再次登录
        }

        //注册
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            //先判断该用户名是否已经存在，所以做一次查找
            if (db.Users.FirstOrDefault(u=>u.UserName==user.UserName)!=null)
            {
                //证明该用户已经存在，追加一个错误消息
                ModelState.AddModelError("", "该用户已被注册！");
                return View(user);
            }
            //添加用户，user对象
            db.Users.Add(user);
            //保存信息，提交到数据库
            db.SaveChanges();
            //重新跳转到登录页面
            return RedirectToAction("Login","Account");//用户就可以再一次登录了
        }

    }
}