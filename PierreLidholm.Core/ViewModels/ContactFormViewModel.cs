using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PierreLidholm.Core.ViewModels
{
    public class ContactFormViewModel
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Maxlängden är 30 tecken.")]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Ange en korrekt emailadress!")]
        public string Email { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Maxlängden är 30 tecken.")]
        public string Subject { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Maxlängden är 500 tecken!")]
        public string Comnment { get; set; }
        
    }
}
