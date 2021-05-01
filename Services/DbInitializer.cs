using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ЛР_1.DAL.Data;
using ЛР_1.DAL.Entities;

namespace ЛР_1.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)

        {

            // создать БД, если она еще не создана
            context.Database.EnsureCreated();

            //проверка наличия групп объектов
            if (!context.Groups.Any())
            {
                context.Groups.AddRange(
                new List<Groups>
                {
                new Groups {GroupName="Программное обеспечение информационных систем"},
                    new Groups {GroupName="Web-дизайн и компьютерная графика"},
                new Groups {GroupName="Тестирование программного обеспечения"},

                });
                await context.SaveChangesAsync();

            }
            //проверка наличия объектов
            if (!context.Students.Any())
            {
                context.Students.AddRange(
                new List<Course>
                {

                         new Course{Firstname="Иван", Lastname="Иванов", Sr_ball=8.7, GroupId=1, Image="ПОИС.jpg"},
                 new Course{Firstname="Петр", Lastname="Смирнов", Sr_ball=10, GroupId=1, Image="ПОИС.jpg"},
                  new Course{Firstname="Симон", Lastname="Головацкий", Sr_ball=5.77, GroupId=1, Image="ПОИС.jpg"},
                   new Course{Firstname="Иоанн", Lastname="Маляваныч", Sr_ball=4.765, GroupId=2, Image="WEB-Дизайн.png"},
                  new Course{Firstname="Олеся", Lastname="Шостка", Sr_ball=9.7, GroupId=2, Image="WEB-Дизайн.png"},
                  new Course{Firstname="Игорь", Lastname="Слуцкий", Sr_ball=10, GroupId=3, Image="prog_test.jpg"}});
                await context.SaveChangesAsync();
            }

            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
               

            }
        }
    }
}
