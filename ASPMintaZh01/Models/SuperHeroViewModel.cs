using ASPMintaZh01.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPMintaZh01.Models
{
    public class SuperHeroViewModel
    {
        [Required(ErrorMessage = "Kötelező nevet adni!")]
        [MaxLength(ErrorMessage = "Maximum 20 karakter lehet!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kötelező erőt adni!")]
        [Range(1, 10, ErrorMessage = "1-10 közti egész számot várunk!")]
        public int Power { get; set; }

        [Required(ErrorMessage = "Kötelező sebességet adni!")]
        [Range(1, 10, ErrorMessage = "1-10 közti egész számot várunk!")]
        public int Speed { get; set; }

        [Range(1, 10, ErrorMessage = "1-10 közti egész számot várunk!")]
        public int Magic { get; set; }

        [Required]
        [SideValidation(new string[] { "light", "dark" })]
        public string Side { get; set; }
        public IFormFile ImageToUpload { get; set; }
    }
}
