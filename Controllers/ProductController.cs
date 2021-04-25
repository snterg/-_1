using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ЛР_1.DAL.Entities;
using ЛР_1.Models;
namespace ЛР_1.Controllers
{
    public class ProductController : Controller
    {
        public List<Course> _student;
        List<Groups> _Groupsstud;
        int _pageSize;

        public ProductController()
        {
            _pageSize = 3;
            SetupData();
        }

        public IActionResult Index(int? group,int pageNo = 1)
        {
            var studfiltr = _student.Where(c => !group.HasValue || c.GroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _Groupsstud;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;
            return View(ListViewModel<Course>.GetModel(studfiltr, pageNo,_pageSize));
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
