using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_4.Models.Unions
{
    [Table("UStudentLessons")]
    public class UStudentLesson
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}