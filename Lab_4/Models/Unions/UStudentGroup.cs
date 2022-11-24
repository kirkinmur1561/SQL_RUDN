using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_4.Models.Unions
{
    [Table("UStudentsAndGroups")]
    public class UStudentGroup
    {
        [Key]
        public int Id { get; set; }
        
        public int IdStudent { get; set; }
        public virtual Student Student { get; set; }
        
        public int IdGroup { get; set; }
        public virtual GroupOfStudent GroupOfStudent { get; set; }
    }
}