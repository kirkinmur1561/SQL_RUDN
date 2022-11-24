using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lab_4.Models.Unions
{
    [Table("ULessonsAndGroups")]
    public class ULessonGroup
    {
        [Key]
        public int Id { get; set; }
        
        public int IdLesson { get; set; }
        [JsonIgnore]
        public Lesson Lesson { get; set; }
        
        public int IdGroup { get; set; }
        [JsonIgnore]
        public virtual GroupOfStudent GroupOfStudent { get; set; }
    }
}