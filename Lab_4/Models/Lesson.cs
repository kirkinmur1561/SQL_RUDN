using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Lab_4.Models.Unions;

namespace Lab_4.Models
{
    [Table("Lessons")]
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public double Hour { get; set; }
        [JsonIgnore]
        public List<GroupOfStudent> GroupOfStudents { get; set; } = new();
        [JsonIgnore]
        public List<ULessonGroup> ULessonGroups { get; set; } = new();
        [JsonIgnore]
        public List<Student> Students { get; set; } = new();
        [JsonIgnore]
        public List<UStudentLesson> StudentLessons { get; set; } = new();
        [JsonIgnore]
        public List<Total> Totals { get; set; } = new();
    }
}