using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ЛР_1.DAL.Entities;
namespace ЛР_1.Controllers
{
    public class ProductController : Controller
    {
        List<Course> _student;
        List<Groups> _Groupsstud;

        public ProductController()
        {
            SetupData();
        }

        public IActionResult Index()
        {
            return View(_student);
        }

        private void SetupData()
        {
            _Groupsstud = new List<Groups>
            { 
            new Groups{ GroupId=1, GroupName="Программное обеспечение информационных систем"},
            new Groups{ GroupId=2, GroupName="Web-дизайн и компьютерная графика"},
            new Groups{ GroupId=3, GroupName="Тестирование программного обеспечения"},
            };
            _student = new List<Course>
            {
                new Course{ studId=1,Firstname="Иван", Lastname="Иванов", Sr_ball=8.7, GroupId=1, Image="ПОИС.jpg"},
                 new Course{ studId=2,Firstname="Петр", Lastname="Смирнов", Sr_ball=10, GroupId=1, Image="ПОИС.jpg"},
                  new Course{ studId=3,Firstname="Симон", Lastname="Головацкий", Sr_ball=5.77, GroupId=1, Image="ПОИС.jpg"},
                   new Course{ studId=4,Firstname="Иоанн", Lastname="Маляваныч", Sr_ball=4.765, GroupId=2, Image="WEB-Дизайн.png"},
                  new Course{ studId=5,Firstname="Олеся", Lastname="Шостка", Sr_ball=9.7, GroupId=2, Image="WEB-Дизайн.png"},
                  new Course{ studId=6,Firstname="Игорь", Lastname="Слуцкий", Sr_ball=10, GroupId=3, Image="prog_test.jpg"}
            };
        }
    }
}
