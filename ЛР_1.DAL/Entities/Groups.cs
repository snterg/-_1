using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ЛР_1.DAL.Entities
{
    public class Groups
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        // Навигационное свойство 1-ко-многим
        [InverseProperty("Group")]
        public List<Course> Students { get; set; }
    }
}
