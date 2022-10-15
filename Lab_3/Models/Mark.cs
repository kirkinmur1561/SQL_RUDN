using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_3.Models
{
    [Table("Marks")]
    public class Mark
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public byte Mark_ { get; set; }
        public string Subject { get; set; }
    }
}