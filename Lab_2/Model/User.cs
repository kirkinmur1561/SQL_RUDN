using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_2.Model
{
    [Table("Users")]
    public class User:IEquatable<User>
    {
        [Key]/*Первичный ключ он обязателен для систему ORM*/
        public int User_Id { get; set; }
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [Required]/*Атрибут информатущий систему, что данное свойство обязательное для заполнения*/
        public string Name { get; set; }

        /// <summary>
        /// Пол пользователя. Default value is true. Формат bool был выбран потому что существует только 2 биологических гендера у человека, что как раз подходит под формат bool. Если значение true - муж, если false - жен.
        /// </summary>
        [Required] /*Атрибут информатущий систему, что данное свойство обязательное для заполнения*/
        public bool Sex { get; set; } = true;
        
        /// <summary>
        /// Возраст. Формат byte выбран потому что данный формат имеет диапозон от 0 до 255 вкл, а как раз возраст человека входит в этот диапозон.
        /// </summary>
        [Required]/*Атрибут информатущий систему, что данное свойство обязательное для заполнения*/
        public byte Old { get; set; }
        
        /// <summary>
        /// Сумма очков.
        /// </summary>
        [Required]/*Атрибут информатущий систему, что данное свойство обязательное для заполнения*/
        public int Score { get; set; }
        
        /// <summary>
        /// Набор игр.
        /// </summary>
        public List<Game> InitGame { get; set; } = new List<Game>();

        public bool Equals(User other) =>
            other != null && GetHashCode() == other.GetHashCode();        

        public override int GetHashCode() => 
            ToString().GetHashCode();

        public override bool Equals(object obj) =>
            Equals(obj as User);

        public override string ToString() =>
            $"{User_Id}\t{Name}\t{Sex}\t{Old}\t{Score}";

    }
}