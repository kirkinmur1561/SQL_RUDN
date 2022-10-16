using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_3.Models
{
    [Table("Students")]
    public class Student:IEquatable<Student>
    {
        public Student()
        {
        }
       

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        /// <summary>
        /// Пол по умолчанию муж
        /// </summary>
        public bool Sex { get; set; } = true;
        public byte Old { get; set; }
        public List<Mark> Marks { get; set; } = new List<Mark>();

        public bool Equals(Student other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Student) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override string ToString() =>
            $"{Id}\t{Name}\t{Sex}\t{Old}";

    }
}