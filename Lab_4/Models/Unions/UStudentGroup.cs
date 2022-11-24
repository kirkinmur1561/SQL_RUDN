using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lab_4.Models.Unions
{
    [Table("UStudentsAndGroups")]
    public class UStudentGroup
    {
        [Key]
        public int Id { get; set; }
        
        public int IdStudent { get; set; }
        [JsonIgnore]
        public virtual Student Student { get; set; }
        
        public int IdGroup { get; set; }
        [JsonIgnore]
        public virtual GroupOfStudent GroupOfStudent { get; set; }
    }
}