using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_3.Models
{
    [Table("Customers")]
    public class Customer:IEquatable<Customer>
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public bool IsTradeIn { get; set; } = false;
        public int Buy { get; set; }

        public bool Equals(Customer other) =>
            GetHashCode() == other.GetHashCode();
        public override int GetHashCode() =>
            CustomerId;


        public override string ToString() =>
            $"{nameof(CustomerId)}: {CustomerId}, {nameof(Name)}: {Name}, {nameof(IsTradeIn)}: {IsTradeIn}, {nameof(Buy)}: {Buy}";

    }
}