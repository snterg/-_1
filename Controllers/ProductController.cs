using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ЛР_1.DAL.Entities;
using ЛР_1.Extensions;
using ЛР_1.Models;
using ЛР_1.DAL.Data;
using Microsoft.Extensions.Logging;

namespace ЛР_1.Controllers
{
    public class ProductController : Controller
    {
        //public List<Course> _student;
        //List<Groups> _Groupsstud;
        int _pageSize;
        ApplicationDbContext _context;
        private ILogger _logger;
        public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
        {
            _pageSize = 3;
            _context = context;
            _logger = logger;
            //SetupData();

        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo)
        {
            var groupName = group.HasValue?_context.Groups.Find(group.Value)?.GroupName:"all groups";
            _logger.LogInformation($"info: group={groupName}, page={pageNo}");
            var studfiltr = _context.Students.Where(c => !group.HasValue || c.GroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.Groups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;
            //return View(ListViewModel<Course>.GetModel(studfiltr, pageNo,_pageSize));
           
            var model = ListViewModel<Course>.GetModel(studfiltr, pageNo, _pageSize);
            //if (Request.Headers["x-requested-with"].ToString().ToLower().Equals("xmlhttprequest"))
            //    return PartialView("_Listpartial", model);
            if (Request.IsAjaxRequest())
                return PartialView("_Listpartial", model);
            else
                return View(model);
        }

        //private void SetupData()
        //{
        //    _Groupsstud = new List<Groups>
        //    {
        //    new Groups{ GroupId=1, GroupName="Программное обеспечение информационных систем"},
        //    new Groups{ GroupId=2, GroupName="Web-дизайн и компьютерная графика"},
        //    new Groups{ GroupId=3, GroupName="Тестирование программного обеспечения"},
        //    };
        //    _student = new List<Course>
        //    {
        //        new Course{ studId=1,Firstname="Иван", Lastname="Иванов", Sr_ball=8.7, GroupId=1, Image="ПОИС.jpg"},
        //         new Course{ studId=2,Firstname="Петр", Lastname="Смирнов", Sr_ball=10, GroupId=1, Image="ПОИС.jpg"},
        //          new Course{ studId=3,Firstname="Симон", Lastname="Головацкий", Sr_ball=5.77, GroupId=1, Image="ПОИС.jpg"},
        //           new Course{ studId=4,Firstname="Иоанн", Lastname="Маляваныч", Sr_ball=4.765, GroupId=2, Image="WEB-Дизайн.png"},
        //          new Course{ studId=5,Firstname="Олеся", Lastname="Шостка", Sr_ball=9.7, GroupId=2, Image="WEB-Дизайн.png"},
        //          new Course{ studId=6,Firstname="Игорь", Lastname="Слуцкий", Sr_ball=10, GroupId=3, Image="prog_test.jpg"}
        //    };
        //}
    }
}
