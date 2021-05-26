using System.ComponentModel.DataAnnotations;

namespace ЛР_1.DAL.Entities
{
    public class Course
    {
        [Key]
        public int studId { get; set; } // id 
        public string Firstname { get; set; } // имя
        public string Lastname { get; set; } // фамилия
        public double Sr_ball { get; set; } // ср.балл
        public string Image { get; set; } // имя файла изображения

        // Навигационные свойства

        public int GroupId { get; set; }
        public Groups Group { get; set; }
    }
}
