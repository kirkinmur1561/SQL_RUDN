using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lab_4.Models.Unions;

namespace Lab_4.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string NumOfStudent { get; set; } //студ б

        public List<Lesson> Lessons { get; set; } = new();
        public List<UStudentLesson> StudentLessons { get; set; } = new();
        
        public List<GroupOfStudent> GroupOfStudents { get; set; } = new();
        public List<UStudentGroup> StudentGroups { get; set; } = new();
        
        public List<Total> Totals { get; set; } = new();
    }
}