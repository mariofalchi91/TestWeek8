using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "inserire nome!")]
        [MaxLength(5, ErrorMessage = "Max 50 characters")]
        [Display(Name = "Code")]
        public string Nome { get; set; }
    }
}
