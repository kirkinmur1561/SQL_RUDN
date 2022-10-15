using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_3.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        /// <summary>
        /// Пол по умолчанию муж
        /// </summary>
        public bool Sex { get; set; } = true;
        public byte Old { get; set; }
        public List<Mark> Marks { get; set; } = new List<Mark>();
    }
}