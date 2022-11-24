using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_4.Models
{
    [Table("EvaluationMethods")]
    public class EvaluationMethod
    {
        [Key]
        public int Id { get; set; }
        
        public enum E_EM
        {
            Exam,       //экзамен
            Offset,     //зачет
            Test      // контрольная работа
        }
        
        public E_EM TypeOfEM { get; set; }
    }
}