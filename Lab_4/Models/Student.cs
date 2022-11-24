using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using Lab_4.Models.Unions;
using Microsoft.VisualBasic;

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

        [JsonIgnore]
        public List<Lesson> Lessons { get; set; } = new();
        [JsonIgnore]
        public List<UStudentLesson> StudentLessons { get; set; } = new();
        [JsonIgnore]
        public List<GroupOfStudent> GroupOfStudents { get; set; } = new();
        [JsonIgnore]
        public List<UStudentGroup> StudentGroups { get; set; } = new();
        [JsonIgnore]
        public List<Total> Totals { get; set; } = new();

        public override string ToString() =>
            string.Join("\t",
                "Name:", Name,
                "Active group:", string.Join(", ", GroupOfStudents.Select(s => s.Name)),
                "Avg score:", Math.Round(Totals.Average(a => a.Score), 2));

    }
}