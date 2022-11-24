using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Lab_4.Models.Unions;

namespace Lab_4.Models
{
    [Table("GroupOfStudents")]
    public class GroupOfStudent
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Student> Students { get; set; } = new();
        [JsonIgnore]
        public List<UStudentGroup> StudentGroups { get; set; } = new();
        [JsonIgnore]
        public List<Lesson> Lessons { get; set; } = new();
        [JsonIgnore]
        public List<ULessonGroup> ULessonGroups { get; set; } = new();
    }
}