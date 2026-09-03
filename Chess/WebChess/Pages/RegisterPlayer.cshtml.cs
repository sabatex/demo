using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebChess.Pages
{
    public class RegisterPlayerModel : PageModel
    {
        [BindProperty]
        [Display(Name ="Ім'я:")]
        [Required]
        [MinLength(2,ErrorMessage ="Імя має бути довше 2 символів")]
        [RegularExpression(@"\D.*",ErrorMessage = "Імя не відповідає вимогам!")]
        public string Name { get; set; }
        public string SurName { get; set; }
        public void OnGet()
        {

        }

        public void OnPost(string surName)
        {
            if (!ModelState.IsValid)
            {
                return;
            }



            SurName = surName;
        }
    }
}