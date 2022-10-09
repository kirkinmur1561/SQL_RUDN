using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Lab_2.Model
{
    [Table("Games")]
    public class Game:IEquatable<Game>
    {
        [Key]
        public int Id { get; set; }        
        public int User_Id { get; set; }
        public int Score { get; set; }
        public DateTime Time { get; set; }     
        public virtual User User { get; set; }


        public bool Equals(Game other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && User_Id == other.User_Id && Score == other.Score && Time.Equals(other.Time);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Game) obj);
        }

        public override int GetHashCode() =>
            ToString().GetHashCode();
        

        public override string ToString() =>
            $"{Id} {User_Id} {Score} {Time.ToString("g")}";

    }
}