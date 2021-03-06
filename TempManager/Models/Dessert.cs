using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FoodManager.Models
{
    public class Dessert
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter date added.")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Please enter a Name for your dessert.")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
