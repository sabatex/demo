using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPage.Data
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Імя Прізвище ПоБатькові")]
        [Required]
        [MinLength(10,ErrorMessage ="Мінімальна довжина 10 символів")]
        public string Name { get; set; }
        [Display(Name = "Школа")]
        public School School { get; set; }
        public int SchoolId { get; set; }
    }
}
