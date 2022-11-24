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
            Exam = 0,       //экзамен
            Offset = 1,     //зачет
            Test = 2        // контрольная работа
        }
        
        public E_EM TypeOfEM { get; set; }
    }
}