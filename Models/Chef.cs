using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefNDishes.Models{
    public class Chef{
        [Key]
        public int ChefId {get;set;}
        [Required]
        [MinLength(2)]
        public string FirstName{get;set;}

        [Required]
        [MinLength(2)]
        public string LastName{get;set;}

        [Required]
        // [Range(typeof(DateTime), "01/01/1900", "01/01/2003", ErrorMessage = "Valid dates for the Property {0} between {1} and {2}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth{get;set;}


        public DateTime CreatedAt{get;set;} = DateTime.Now;
        public DateTime UpdatedAt{get;set;} = DateTime.Now;
        public List<Dish> DishList {get;set;}
    }
}