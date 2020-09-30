using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace First.DTOs
{
    public class PersonCreationDTO
    {
        [Required]
        [StringLength(120)]
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IFormFile Picture { get; set; }
    }
}
