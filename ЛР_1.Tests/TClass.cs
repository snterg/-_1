using System.Collections.Generic;
using ЛР_1.DAL.Data;
using ЛР_1.DAL.Entities;

namespace ЛР_1.Tests
{
    public class TClass
    {
        public static List<Course> GetStudList()
        {
            return new List<Course>
{
new Course{ studId=1,GroupId=1},
new Course{ studId=2,GroupId=1},
new Course{ studId=3,GroupId=1},
new Course{ studId=4,GroupId=2},
new Course{ studId=5,GroupId=2},
new Course{ studId=6,GroupId=3}
};
        }
        public static IEnumerable<object[]> Params()
        {
            // 1-я страница, кол. объектов 3, id первого объекта 1
            yield return new object[] { 1, 3, 1 };
            // 2-я страница, кол. объектов 2, id первого объекта 4
            yield return new object[] { 2, 2, 4 };
        }

        public static void FillContext(ApplicationDbContext context)
        {
            context.Groups.Add(new Groups
            { GroupName = "fake group" });
            context.AddRange(new List<Course>
{
new Course{ studId=1, GroupId=1},
new Course{ studId=2, GroupId=1},
new Course{ studId=3, GroupId=2},
new Course{ studId=4, GroupId=2},
new Course{ studId=5, GroupId=3}
});
            context.SaveChanges();
        }
    }
}
