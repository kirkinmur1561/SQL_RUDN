using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lab_4.Models.Unions;

namespace Lab_4.Models
{
    [Table("GroupOfStudents")]
    public class GroupOfStudent
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> Students { get; set; } = new();
        public List<UStudentGroup> StudentGroups { get; set; } = new();

        public List<Lesson> Lessons { get; set; } = new();
        public List<ULessonGroup> ULessonGroups { get; set; } = new();
    }
}