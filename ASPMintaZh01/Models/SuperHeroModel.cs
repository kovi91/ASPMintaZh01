using ASPMintaZh01.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPMintaZh01.Models
{
    public class SuperHeroModel
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
        [SideValidation(new string[] { "jó", "gonosz" })]
        public string Side { get; set; }
        public byte[] Image { get; set; }
        public string ContentType { get; set; }

        public int Health { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
