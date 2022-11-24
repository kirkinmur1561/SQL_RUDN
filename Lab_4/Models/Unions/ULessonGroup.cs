using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_4.Models.Unions
{
    [Table("ULessonsAndGroups")]
    public class ULessonGroup
    {
        [Key]
        public int Id { get; set; }
        
        public int IdLesson { get; set; }
        public Lesson Lesson { get; set; }
        
        public int IdGroup { get; set; }
        public virtual GroupOfStudent GroupOfStudent { get; set; }
    }
}