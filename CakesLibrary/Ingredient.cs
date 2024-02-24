using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakesLibrary.Models
{
    [Table("ingredients")]
    public class Ingredient
    {
        [Column("ingredients_id")]
        [Key]
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get;  set; }

        public Ingredient ()
        {
         
        }

        

    }
}
