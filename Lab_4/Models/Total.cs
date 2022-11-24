using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lab_4.Models
{
    [Table("Totals")]
    public class Total
    {
        [Key]
        public int Id { get; set; }
        
        public int Score { get; set; }
        
        public EvaluationMethod.E_EM EEm { get; set; }
        
        public DateTime Date { get; set; }

        public int IdLesson { get; set; }
        [JsonIgnore]
        public virtual Lesson Lesson { get; set; }

        public int IdStudent { get; set; }
        [JsonIgnore]
        public virtual Student Student { get; set; }
    }
}