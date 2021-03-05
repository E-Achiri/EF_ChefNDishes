using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefNDishes.Models{
    public class Dish{
        [Key]
        public int DishId {get;set;}
        [Required]
        [MinLength(2)]
        public string NameOfDish{get;set;}

        [Required]
        public int Calories {get;set;}

        [Required]
        [Range(1,5)]
        public int Tastiness {get;set;}

        [Required]
        public string Description{get;set;}

    //     [Required]
    //     [Display(Name = "Date")]
    //     [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    //     [Range(typeof(DateTime), "01/01/1900", "01/01/2003",  
    // ErrorMessage = "Valid dates for the Property {0} between {1} and {2}")]
    //     [DataType(DataType.Date)]

        [Required]
        public int ChefId{get;set;}
        public Chef TheChef{get;set;}


        public DateTime CreatedAt{get;set;} = DateTime.Now;
        public DateTime UpdatedAt{get;set;} = DateTime.Now;

    }
}